using System;
using System.Diagnostics;

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
