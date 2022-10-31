using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Login_IT4A
{
    public class User
    {
        public string Name { get; }
        public byte[] PasswordHash { get; internal set; }
        public byte[] PasswordSalt { get; internal set; }

        public User(string name, string password)
        {
            Name = name;
            CreatePasswordHash(password);
        }

        public User(string name, byte[] passwordHash, byte[] passwordSalt)
        {
            Name = name;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public bool VerifyPassword(string text)
        {
            byte[] hash;
            using (var hmac = new HMACSHA512(PasswordSalt))
            {
                hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(text));
            }           
            return hash.SequenceEqual(PasswordHash);
        }

        private void CreatePasswordHash(string password)
        {
            using(var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public void ChangePassword(string password)
        {
            CreatePasswordHash(password);
        }

        public string[] ToStringArray()
        {
            return new string[] { Name, "" };
        }

        public ListViewItem ToListViewItem()
        {
            return new ListViewItem(ToStringArray());
        }
    }
}
