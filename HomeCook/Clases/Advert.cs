using Newtonsoft.Json;
using System;

namespace HomeCook.Clases
{
    class Advert
    {
        public int ID { get; set; }

        public string ImageUri { get; set; }

        public string Name { get; set; }

        public string Details { get; set; }

        public int Portions { get; set; }

        public User Owner { get; set; }

        public Preferences Preferences { get; set; }

        public bool Active { get; set; }

        public Advert()
        {

        }

        public Advert(int id, string name, string details, User user, string imageUri, int portions, Preferences pref, bool active)
        {
            ID = id;
            Name = name;
            Details = details;
            Owner = user;
            ImageUri = imageUri;
            Portions = portions;
            Preferences = pref;
            Active = active;
        }

        public static implicit operator Advert(string v)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}