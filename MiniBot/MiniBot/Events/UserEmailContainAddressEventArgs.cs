using System;
using System.Diagnostics;

namespace MiniBot.Events
{
    [DebuggerDisplay("Email = {Email}; Name = {Name}")]
    sealed class UserEmailContainAddressEventArgs : EventArgs
    {
        public string Email { get; }

        public string Name { get; }

        public UserEmailContainAddressEventArgs(string email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}
