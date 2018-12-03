using HomeCook.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeCook
{
    public partial class CreateAdvert : Page
    {
        private User logedUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            logedUser = (User)Session["logedUser"];
        }

        protected void CreateAdvert_Click(object sender, EventArgs e)
        {
            Preferences prefs = new Preferences();
            prefs.SetPref("shellfish", shellfish.Checked);
            prefs.SetPref("gluten", gluten.Checked);
            prefs.SetPref("lactose", lactose.Checked);

            if (name.Text != "" && details.Text != "" && porciones.Text != "")
            {
                Extras.CreateAdvert(name.Text, details.Text, prefs, logedUser, int.Parse(porciones.Text), "");
                Response.Redirect("/Adverts");
            }

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Adverts");
        }
    }
}