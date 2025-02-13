using System;

namespace LoginSystem
{
    public class LoginEntry
    {
        public string Username { get; private set; }
        public DateTime DataOra { get; private set; }

        public LoginEntry(string username, DateTime dataOra)
        {
            Username = username;
            DataOra = dataOra;
        }
    }
}

