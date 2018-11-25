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
            string id = null;
            //User user = (User)Session["logedUser"];
            try
            {
                id = Request.QueryString["id"].ToString();
                Extras.VerifyAccount(id);
            }
            catch { }
        }

        protected void NewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Register");
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Session["logedUser"] = logedUser;
            if (logedUser != null)
                Response.Redirect("/Home");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            logedUser = Extras.Login(user.Text, password.Text);
            args.IsValid = (logedUser != null);
        }
    }
}