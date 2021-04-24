using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Events
{
    [DebuggerDisplay("Email = {Email}; Name = {Name}")]
    sealed class UserEmailContainAdressEventArgs : EventArgs
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
