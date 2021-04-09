using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Entities
{
    sealed class User
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Adress { get; set; }

        internal string GetNameOfUser(User user)
        {
            Console.WriteLine("Please input your name: ");
            return user.Name = Console.ReadLine();
        }
    }
}
