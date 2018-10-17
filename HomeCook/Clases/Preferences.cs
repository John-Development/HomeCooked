using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCook.Clases
{
    public class Preferences
    {
        private Dictionary<string, bool> prefs = new Dictionary<string, bool>();

        public Preferences()
        {
            prefs.Add("shellfish", false);
            prefs.Add("gluten", false);
            prefs.Add("lactose", false);
        }

        public Preferences(List<KeyValuePair<string, bool>> alergs)
        {
            foreach(KeyValuePair<string, bool> alerg in alergs)
            {
                prefs.Add(alerg.Key, alerg.Value);
            }
        }

        public Preferences(string str)
        {
            prefs = JsonConvert.DeserializeObject<Dictionary<string, bool>>(str);
        }

        public void SetPref(string key, bool value)
        {
            prefs[key] = value;
        }

        public bool GetPref(string key)
        {
            return prefs[key];
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(prefs);
        }
    }
}