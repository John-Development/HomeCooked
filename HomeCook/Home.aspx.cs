using HomeCook;
using HomeCook.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeCooked
{
    public partial class Home : Page
    {
        private User logedUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            logedUser = (User)Session["logedUser"];
            Euro.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Name.Text != "" && !Name.Text.Contains("TU PUTO NOMBRE"))
            {
                Euro.Visible = true;
            }
            else
            {
                Name.Text = "TU PUTO NOMBRE";
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login");
        }
    }
}