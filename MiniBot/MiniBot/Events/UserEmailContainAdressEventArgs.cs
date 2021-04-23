using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Events
{
    class UserEmailContainAdressEventArgs : EventArgs
    {
        public string Email { get; }

        public string Name { get; }

        public UserEmailContainAdressEventArgs(string email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}
