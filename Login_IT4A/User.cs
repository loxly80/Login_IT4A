using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_IT4A
{
    public class User
    {
        public string Name { get; }
        public string Password { get; }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
