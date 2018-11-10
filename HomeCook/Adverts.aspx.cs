using HomeCook.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HomeCook
{
    public partial class Adverts : Page
    {
        private User logedUser;
        private List<Advert> userAdverts;

        protected void Page_Load(object sender, EventArgs e)
        {
            logedUser = (User)Session["logedUser"];

            if (logedUser == null)
                Response.Redirect("/Login");
            else
            {
                //Load list of user adverts
                userAdverts = Extras.GetAdverts(logedUser);
                //Add items to interface
                ListarAnuncios(userAdverts);
            }
        }

        protected void NewAdvert_Click(object sender, EventArgs e)
        {
            if (logedUser != null)
                Response.Redirect("/CreateAdvert");
            else
                Response.Redirect("/Login");
        }
        
        protected void Button1_click(object sender, EventArgs e)
        {
            //activate or deactivate the advert
            int id = int.Parse(((Button)sender).Parent.ID);
            bool active = Extras.IsAdvertActive(id);
            Extras.ModifyAdvert(id, active);
            ((Button)sender).Text = active ? "Activar anuncio" : "Desactivar anuncio";
        }
        
        protected void Button2_click(object sender, EventArgs e)
        {
            //Remove from database the advert
            int id = int.Parse(((Button)sender).Parent.ID);
            Extras.DeleteAdvert(id);
            Response.Redirect("/Adverts");
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
                alergDiv.InnerHtml = Preferences(userAdverts[i].Preferences);

                //Botones
                HtmlGenericControl bloque2_2Div = new HtmlGenericControl("div");
                bloque2_2Div.Style.Add("width", "150px");
                bloque2_2Div.Style.Add("height", "100px");
                bloque2_2Div.Style.Add("float", "right");
                bloque2_2Div.ID = userAdverts[i].ID.ToString();

                Button b1Div = new Button();
                b1Div.Attributes["class"] = "btn btn-primary";
                b1Div.Click += new EventHandler(Button1_click);
                b1Div.Attributes["style"] = "height:50px; width: 150px";
                b1Div.Text = userAdverts[i].Active ? "Desactivar anuncio" : "Activar anuncio";

                Button b2Div = new Button();
                b2Div.Attributes["class"] = "btn btn-primary";
                b2Div.Click += new EventHandler(Button2_click);
                b2Div.Attributes["style"] = "height:50px; width: 150px; background-color: crimson";
                b2Div.Text = "Borrar anuncio";

                //Jerarquía
                elementDiv.Controls.Add(bloque1Div);
                bloque1Div.Controls.Add(imgDiv);
                bloque1Div.Controls.Add(nameDiv);
                elementDiv.Controls.Add(bloque2Div);
                bloque2Div.Controls.Add(bloque2_1Div);
                bloque2_1Div.Controls.Add(descDiv);
                bloque2_1Div.Controls.Add(alergDiv);
                bloque2Div.Controls.Add(bloque2_2Div);
                bloque2_2Div.Controls.Add(b1Div);
                bloque2_2Div.Controls.Add(b2Div);

                elements.Controls.Add(elementDiv);
            }
        }

        private string Preferences(Preferences preferencias)
        {
            string res = "Este producto ";

            res = !preferencias.GetPref("shellfish") && !preferencias.GetPref("gluten") && !preferencias.GetPref("lactose") ?
                res + " no contiene ningún alérgeno, " : res + " contiene ";

            if (preferencias.GetPref("shellfish"))
            {
                res = res + "marisco, ";
            }
            if (preferencias.GetPref("gluten"))
            {
                res = res + "gluten, ";
            }
            if (preferencias.GetPref("lactose"))
            {
                res = res + "lactosa, ";
            }

            res = res.Substring(0, res.Count() - 2);
            res = res + ".";
            return res;
        }
    }
}