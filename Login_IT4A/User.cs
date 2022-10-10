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
        public string Password { get; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public bool VerifyPassword(string text)
        {
            return Password == text;
        }

        public void CreatePasswordHash(string password)
        {
            using(var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
