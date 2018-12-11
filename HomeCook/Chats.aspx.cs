using HomeCook.Clases;
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
            //int id = int.Parse(((Button)sender).Parent.ID);
            //bool active = Extras.IsAdvertActive(id);
            //Extras.ModifyAdvert(id, !active);
            //((Button)sender).Text = active ? "Activar anuncio" : "Desactivar anuncio";
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
    }
}