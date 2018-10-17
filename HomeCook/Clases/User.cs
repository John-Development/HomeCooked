
using System;

namespace HomeCook.Clases
{
    class User
    {
        public string Username { get; }

        public string Password { get; }

        public string Email { get; }

        public string Location { get; set; }

        public string Image { get; set; }

        public string Contact { get; set; }

        public Preferences Preferences { get; set; }

        public string Rank { get; set; }

        public User(string user, string pass, string email, string loc, Preferences prefs)
        {
            Username = user;
            Password = pass;
            Email = email;
            Location = loc;
            Preferences = prefs;
        }

        public static implicit operator User(string v)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}