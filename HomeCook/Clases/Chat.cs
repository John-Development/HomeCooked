using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCook.Clases
{
    class Chat
    {

        public int ChatID { get; }

        public int AdvertID { get; }

        public string Vendor { get; }

        public string Buyer { get; }

        public bool State { get; set; }

        public DateTime Date { get; set; }

        public int Quantity { get; set; }

        public string Rank { get; set; }

        public string Data { get; set; }

        public Chat()
        {

        }

        public Chat(int chatID, int advertID, string vendor, string buyer, bool state, DateTime date, int quantity, string ranking, string data)
        {
            ChatID = chatID;
            AdvertID = advertID;
            Vendor = vendor;
            Buyer = buyer;
            State = state;
            Date = date;
            Quantity = quantity;
            Rank = ranking;
            Data = data;
        }

        public Chat(int advertID, string vendor, string buyer, bool state, DateTime date, int quantity, string ranking, string data)
        {
            AdvertID = advertID;
            Vendor = vendor;
            Buyer = buyer;
            State = state;
            Date = date;
            Quantity = quantity;
            Rank = ranking;
            Data = data;
        }

        public static implicit operator Chat(string v)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}