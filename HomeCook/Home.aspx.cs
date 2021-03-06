﻿using HomeCook;
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

namespace HomeCooked
{
    public partial class Home : Page
    {
        private User logedUser;
        private List<Advert> globalAdverts;
        private Extras extras = new Extras();

        protected void Page_Load(object sender, EventArgs e)
        {
            logedUser = (User)Session["logedUser"];

            string name = Request.QueryString["nombre"]?.ToString();
            //bool alerg = (Request.QueryString["alerg"]?.ToString() == "true");
            //string location = Request.QueryString["localizacion"]?.ToString();

            if (name != null)
            {

            }

            //try
            //{
            //    //Load list of user adverts
            //    globalAdverts = (logedUser != null) ? Extras.GetAdverts(logedUser.Username) : Extras.GetAdverts();
            //    //Add items to interface
            //    ListarAnuncios(globalAdverts);
            //}
            //catch
            //{
            //    //Load list of user adverts
            //    globalAdverts = (logedUser != null) ? Extras.GetAdverts(logedUser.Username) : Extras.GetAdverts();
            //    //Add items to interface
            //    ListarAnuncios(globalAdverts);
            //}

            //Load list of user adverts
            globalAdverts = (logedUser != null) ? Extras.SortAdverts(Extras.GetAdverts(logedUser.Username), logedUser, "location") : Extras.GetAdverts();
            //Add items to interface
            ListarAnuncios(globalAdverts);
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login");
        }

        protected void Advert_click(object sender, EventArgs e)
        {
            //Abre un chat con el vendedor.
            if (logedUser != null)
            {
                //Lee el id del anuncio
                int id = int.Parse(((LinkButton)sender).ID);
                Advert adv = Extras.GetAdvert(id);

                //Crea la entrada en la tabla de chats
                JObject data = new JObject
                {
                    { "Messages", 0 },
                    { "History", new JArray() }
                };

                Extras.CreateChat(new Chat(id, adv.Owner.Username, logedUser.Username, true, DateTime.Now, adv.Portions, adv.Owner.Rank, JsonConvert.SerializeObject(data)));

                //Luego redirige a la página de chats
                Response.Redirect("/Chats");
            }
            else
                Response.Redirect("/Login");
        }

        private void ListarAnuncios(List<Advert> userAdverts)
        {
            /**
            <div id="advertElement" style="height: 100px; width: 700px">
                <div style="width: 100px; height: 100px; float:left" >
                    <div style="height: 60px;" id="image"> imagen </div>
                    <div style="height: 40px;" id="name"> nombre </div>
                </div>
                <div style="width: 600px; height:100px; float: right">
                    <div style="width: 450px; height:100px; float:left">
                        <div style="height:60px" id="description"> decripcion </div>
                        <div style="height:40px" id="alerglist"> alérgenos </div>
                    </div>
                    <div style="width: 150px; height: 100px; float: right">
                        <button class="btn btn-primary" style="height:50px; width: 150px" id="activate"> Activar anuncio </button>
                        <button class="btn btn-primary" style="height:50px; width: 150px" id="remove"> Borrar anuncio </button>
                    </div>
                </div>
            </div>
            */

            for (int i = 0; i < userAdverts.Count; i++)
            {

                //Elemento
                LinkButton elementLinkButton = new LinkButton();
                elementLinkButton.Style.Add(HtmlTextWriterStyle.Height, "100px");
                elementLinkButton.Style.Add(HtmlTextWriterStyle.Width, "700px");
                elementLinkButton.Click += new EventHandler(Advert_click);
                elementLinkButton.ID = userAdverts[i].ID.ToString();

                HtmlGenericControl elementDiv = new HtmlGenericControl("div");
                elementDiv.Style.Add(HtmlTextWriterStyle.Height, "100px");
                elementDiv.Style.Add(HtmlTextWriterStyle.Width, "700px");
                elementDiv.Style.Add("margin", "0 0 25px 100px");

                //Foto y nombre
                HtmlGenericControl bloque1Div = new HtmlGenericControl("div");
                bloque1Div.Style.Add(HtmlTextWriterStyle.Height, "100px");
                bloque1Div.Style.Add(HtmlTextWriterStyle.Width, "100px");
                bloque1Div.Style.Add("float", "left");
                bloque1Div.Style.Add(HtmlTextWriterStyle.BackgroundColor, "azure");

                HtmlGenericControl imgDiv = new HtmlGenericControl("div");
                imgDiv.Style.Add("height", "60px");
                //imgDiv.innerHTML = infoJson[i].ImageUri;

                HtmlGenericControl nameDiv = new HtmlGenericControl("div");
                nameDiv.Style.Add("height", "40px");
                nameDiv.InnerHtml = userAdverts[i].Name;

                //Descripcion y alergenos aliceblue
                HtmlGenericControl bloque2Div = new HtmlGenericControl("div");
                bloque2Div.Style.Add("width", "600px");
                bloque2Div.Style.Add("height", "100px");
                bloque2Div.Style.Add("float", "right");
                bloque2Div.Style.Add("background-color", "aliceblue");

                HtmlGenericControl bloque2_1Div = new HtmlGenericControl("div");
                bloque2_1Div.Style.Add("width", "450px");
                bloque2_1Div.Style.Add("height", "100px");
                bloque2_1Div.Style.Add("float", "left");

                HtmlGenericControl descDiv = new HtmlGenericControl("div");
                descDiv.Style.Add("height", "60px");
                descDiv.InnerHtml = userAdverts[i].Details;

                HtmlGenericControl alergDiv = new HtmlGenericControl("div");
                alergDiv.Style.Add("height", "40px");
                alergDiv.InnerHtml = extras.Preferences(userAdverts[i].Preferences);

                //Chef
                HtmlGenericControl bloque2_2Div = new HtmlGenericControl("div");
                bloque2_2Div.Style.Add("width", "150px");
                bloque2_2Div.Style.Add("height", "100px");
                bloque2_2Div.Style.Add("float", "right");
                bloque2_2Div.InnerText = userAdverts[i].Owner.Username.ToString();

                //Jerarquía elementDiv
                elementDiv.Controls.Add(elementLinkButton);
                elementLinkButton.Controls.Add(bloque1Div);
                bloque1Div.Controls.Add(imgDiv);
                bloque1Div.Controls.Add(nameDiv);
                elementLinkButton.Controls.Add(bloque2Div);
                bloque2Div.Controls.Add(bloque2_1Div);
                bloque2_1Div.Controls.Add(descDiv);
                bloque2_1Div.Controls.Add(alergDiv);
                bloque2Div.Controls.Add(bloque2_2Div);
                //bloque2_2Div.Controls.Add(b2Div);

                elements.Controls.Add(elementDiv);
            }
        }
    }
}