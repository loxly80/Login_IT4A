using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Login_IT4A
{
    public class SqlRepository
    {
        Dictionary<string, User> users = new Dictionary<string, User>()
        {
            { "admin", new User("admin","admin") },
            { "user", new User("user","user") },
            { "guest", new User("guest","guest") },
            { "jirka", new User("jirka","jirka") },
            { "petr", new User("petr","petr") }
        };
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Login_A;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "select * from Users";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User(reader["Name"].ToString()
                                             , (byte[])reader["PasswordHash"]
                                             , (byte[])reader["PasswordSalt"])
                                );
                        }
                    }
                }
                sqlConnection.Close();
            }
            return users;
        }

        public List<User> GetUsers(string searchString)
        {
            List<User> users = new List<User>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "select * from Users where Name like @Search";
                    cmd.Parameters.AddWithValue("Search", "%" + searchString + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User(reader["Name"].ToString()
                                             , (byte[])reader["PasswordHash"]
                                             , (byte[])reader["PasswordSalt"])
                                );
                        }
                    }
                }
                sqlConnection.Close();
            }
            return users;
        }

        public User? GetUser(string username)
        {
            User? user = null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "select * from Users where Name=@Name";
                    cmd.Parameters.AddWithValue("Name", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User(reader["Name"].ToString(), (byte[])reader["PasswordHash"], (byte[])reader["PasswordSalt"]);
                        }
                    }
                }
                sqlConnection.Close();
            }
            return user;
        }

        public void SaveUser(User user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "update Users set PasswordSalt=@Salt, PasswordHash=@Hash where Name=@Name";
                    cmd.Parameters.AddWithValue("Salt", user.PasswordSalt);
                    cmd.Parameters.AddWithValue("Hash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("Name", user.Name);
                    cmd.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }

        public void CreateUser(User user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "insert into Users(Name,PasswordHash,PasswordSalt) values(@Name,@Hash,@Salt)";
                    cmd.Parameters.AddWithValue("Salt", user.PasswordSalt);
                    cmd.Parameters.AddWithValue("Hash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("Name", user.Name);
                    cmd.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }

        public void DeleteUser(User user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "delete from Users where Name=@Name";
                    cmd.Parameters.AddWithValue("Name", user.Name);
                    cmd.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }

        public void DeleteUser(string userName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "delete from Users where Name=@Name";
                    cmd.Parameters.AddWithValue("Name", userName);
                    cmd.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }

        public void ConvertUsersToHashed()
        {
            var users = GetUsers();
            foreach (var user in users)
            {
                SaveUser(user);
            }
        }
    }
}
