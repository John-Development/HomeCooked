using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeCoocked
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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