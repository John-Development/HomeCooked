using HomeCook.Clases;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HomeCook
{
    public partial class Perfil : Page
    {
        private User logedUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                logedUser = (User)Session["logedUser"];
                if (logedUser == null)
                    Response.Redirect("/Login", false);
                else
                {
                    user.Text = logedUser.Username;
                    email.Text = logedUser.Email;
                    location.Text = logedUser.Location;
                    shellfish.Checked = logedUser.Preferences.GetPref("shellfish");
                    gluten.Checked = logedUser.Preferences.GetPref("gluten");
                    lactose.Checked = logedUser.Preferences.GetPref("lactose");
                }
            }
            catch
            {
                Response.Redirect("/Home", false);
            }
        }



        protected void SaveCanges_Click(object sender, EventArgs e)
        {
            if (password.Text != "" && passRepeat.Text != "")
            {
                Preferences prefs = new Preferences();
                prefs.SetPref("shellfish", shellfish.Checked);
                prefs.SetPref("gluten", gluten.Checked);
                prefs.SetPref("lactose", lactose.Checked);
                try
                {
                    Extras.ModifyUser(logedUser);
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(SqliteException))
                    {

                    }
                }

            }
            //else if ()
            //{

            //}

            Bitmap image = new Bitmap(System.Drawing.Image.FromStream(Request.Files["profilePic"].InputStream));
        }

        protected void DropOut_Click(object sender, EventArgs e)
        {
            if (passDelete.Text == logedUser.Password)
            {
                Extras.DeleteUser(logedUser);
                Response.Redirect("/Home");
            }

            //ScriptManager.RegisterStartupScript(this, GetType(), "1", "showmodalpopup1();", true);
        }
    }
}