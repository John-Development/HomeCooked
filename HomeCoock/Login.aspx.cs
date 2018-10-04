using HomeCoock.Clases;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMatrix.Data;

namespace HomeCoock
{
    public partial class Login : Page
    {
        private User logedUser = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            
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

                //var db = Database.Open("DB");
                ////var insertCommand = "INSERT INTO Usuarios (Username, Password, Email) VALUES(@0, @1, @2)";
                //var insertCommand = "SELECT * FROM Usuarios WHERE Username='@0' AND Password='@1'";
                //logedUser = db.QuerySingle(insertCommand, user.Text, password.Text);
            }
            if (logedUser != null)
            {
                Response.Redirect("/Home");
            }
        }
    }
}