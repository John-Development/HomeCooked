using HomeCook.Clases;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMatrix.Data;

namespace HomeCook
{
    public partial class Login : Page
    {
        private User logedUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["logedUser"];
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Home");
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (user.Text != "" && password.Text != null)
            {
                logedUser = Extras.Login(user.Text, password.Text);
            }
            if (logedUser != null)
            {
                Session["logedUser"] = logedUser;
                Response.Redirect("/Home");
            }
        }
    }
}