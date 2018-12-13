using HomeCook.Clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HomeCook
{
    public partial class Chats : Page
    {
        private User logedUser;
        private List<Chat> chats;
        private Extras extras = new Extras();
        //private JObject jsonChat;
        //private Chat chat;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Logued uer
            logedUser = (User)Session["logedUser"];
            //Busca los chats que haya abiertos de ese usuario
            if (logedUser != null)
                ListarChats(chats = Extras.GetChats(logedUser));
            else
                Response.Redirect("/Login");

        }

        protected void Chat_click(object sender, EventArgs e)
        {

            //activate or deactivate the advert
            int id = int.Parse(((LinkButton)sender).ID);
            //bool active = Extras.IsAdvertActive(id);
            Session["chatID"] = id;
            Chat chat = Extras.GetChat(id);

            //Lee el objeto chat e interpreta el campo mensaje 
            //Session["jsonChat"] = JsonConvert.DeserializeObject<JObject>(((Chat)Session["chat"]).Data);
            //jsonChat = JsonConvert.DeserializeObject<JObject>(chat.Data);

            /**
             * {
             * "Messages": 0,
             * "History":[ From older to newer
             *      {
             *      "from": "",
             *      "message": ""
             *      },
             *      {
             *      "from": "",
             *      "message": ""
             *      },
             *      {
             *      "from": "",
             *      "message": ""
             *      },
             *      {
             *      "from": "",
             *      "message": ""
             *      }
             * ]
             * }
             * 
             */
            
            for (int i = 0; i < int.Parse(((JObject)chat.Data).GetValue("Messages").ToString()); i++)
            {
                HtmlGenericControl msgDiv = new HtmlGenericControl("div");
                msgDiv.Style.Add(HtmlTextWriterStyle.Height, "20px");
                msgDiv.Style.Add("max-width", "400px");
                msgDiv.Style.Add(HtmlTextWriterStyle.Margin, "5px");
                if (((JObject)((JArray)((JObject)chat.Data).GetValue("History"))[i]).GetValue("from").ToString() == logedUser.Username)
                {
                    msgDiv.Style.Add("background-color", "aliceblue");
                    msgDiv.Style.Add("float", "right");
                }
                else
                {
                    msgDiv.Style.Add("background-color", "antiquewhite");
                    msgDiv.Style.Add("float", "left");
                }
                msgDiv.InnerText = ((JObject)((JArray)((JObject)chat.Data).GetValue("History"))[i]).GetValue("message").ToString();

                messages.Controls.Add(msgDiv);
            }
        }

        private void ListarChats(List<Chat> userChats)
        {
            /**
            <LinkButton id="advertElement" style="height: 50px; width: 200px">
                <div style="width: 200px; height: 50px; float:left" >
                    <div style="height: 30px;" id="advert"> Anuncio </div>
                    <div style="height: 20px;" id="vendor"> Vendedor </div>
                </div>
            </LinkButton>
            */

            for (int i = 0; i < userChats.Count; i++)
            {

                //Elemento
                LinkButton elementLinkButton = new LinkButton();
                elementLinkButton.Style.Add(HtmlTextWriterStyle.Height, "40px");
                elementLinkButton.Style.Add(HtmlTextWriterStyle.Width, "200px");
                elementLinkButton.Click += new EventHandler(Chat_click);
                elementLinkButton.ID = userChats[i].ChatID.ToString();

                HtmlGenericControl elementDiv = new HtmlGenericControl("div");
                elementDiv.Style.Add(HtmlTextWriterStyle.Height, "40px");
                elementDiv.Style.Add(HtmlTextWriterStyle.Width, "200px");
                elementDiv.Style.Add(HtmlTextWriterStyle.Margin, "5px");
                elementDiv.Style.Add("background-color", "aliceblue");

                HtmlGenericControl div1 = new HtmlGenericControl("div");
                div1.Style.Add(HtmlTextWriterStyle.Height, "20px");
                div1.Style.Add(HtmlTextWriterStyle.Width, "200px");
                div1.InnerText = (userChats[i].Vendor == logedUser.Username) ? userChats[i].Buyer : userChats[i].Vendor;

                HtmlGenericControl div2 = new HtmlGenericControl("div");
                div2.Style.Add(HtmlTextWriterStyle.Height, "20px");
                div2.Style.Add(HtmlTextWriterStyle.Width, "200px");
                div2.InnerText = Extras.GetAdvert(userChats[i].AdvertID).Name;

                //Jerarquía elementDiv
                elementDiv.Controls.Add(elementLinkButton);

                elementLinkButton.Controls.Add(div1);
                elementLinkButton.Controls.Add(div2);

                chatList.Controls.Add(elementDiv);
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            //Incrementa el campo de numero de mensajes y agrega a la lista de historial el nuevo mensaje
            Chat chat = Extras.GetChat(((Chat)Session["chatID"]).ChatID);

            JObject jsonChat = JsonConvert.DeserializeObject<JObject>(chat.Data);
            int msgCant = (int)JsonConvert.DeserializeObject<JObject>(chat.Data).GetValue("Messages");
            JArray history = (JArray)JsonConvert.DeserializeObject<JObject>(chat.Data)["History"];
            history.Add(new JObject()
            {
                { "from", logedUser.Username },
                { "message", message.Text }
            });

            chat.Data = (string)jsonChat;
            Extras.UpdateChat(chat);

            HtmlGenericControl msgDiv = new HtmlGenericControl("div");
            msgDiv.Style.Add(HtmlTextWriterStyle.Height, "20px");
            msgDiv.Style.Add("max-width", "400px");
            msgDiv.Style.Add(HtmlTextWriterStyle.Margin, "5px");
            msgDiv.Style.Add("background-color", "aliceblue");
            msgDiv.Style.Add("float", "right");
            msgDiv.InnerText = message.Text;

            messages.Controls.Add(msgDiv);
        }
    }
}