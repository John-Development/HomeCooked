using HomeCook.Clases;
using Microsoft.Data.Sqlite;
using System;
using System.Web.UI;

namespace HomeCook
{
    public partial class Perfil : Page
    {
        private User logedUser;
        Preferences prefs = new Preferences();

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
                    if (location.Text == "")
                        location.Text = logedUser.Location;
                    //if (shellfish.Checked == logedUser.Preferences.GetPref("shellfish"))
                    prefs.SetPref("shellfish", shellfish.Checked = logedUser.Preferences.GetPref("shellfish"));
                    //if (gluten.Checked == logedUser.Preferences.GetPref("gluten"))
                    prefs.SetPref("gluten", gluten.Checked = logedUser.Preferences.GetPref("gluten"));
                    //if (lactose.Checked == logedUser.Preferences.GetPref("lactose"))
                    prefs.SetPref("lactose", lactose.Checked = logedUser.Preferences.GetPref("lactose"));
                }
            }
            catch
            {
                Response.Redirect("/Home", false);
            }
        }



        protected void SaveCanges_Click(object sender, EventArgs e)
        {
            User newValue = logedUser;

            if (password.Text != "" && passRepeat.Text != "")
                newValue.Password = password.Text;

            newValue.Preferences = prefs;

            if (location.Text != "")
                newValue.Location = location.Text;

            try
            {
                Extras.ModifyUser(newValue);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(SqliteException))
                {

                }
            }
            //else if ()
            //{

            //}

            //Bitmap image = new Bitmap(System.Drawing.Image.FromStream(Request.Files["profilePic"].InputStream));
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["logedUser"] = null;
            Response.Redirect("/Home");
        }

        protected void DropOut_Click(object sender, EventArgs e)
        {
            if (passDelete.Text == logedUser.Password)
            {
                Extras.DeleteUser(logedUser);
                Session["logedUser"] = null;
                Response.Redirect("/Home");
            }

            //ScriptManager.RegisterStartupScript(this, GetType(), "1", "showmodalpopup1();", true);
        }

        protected void Shellfish_CheckedChanged(object sender, EventArgs e)
        {
            shellfish.Checked = !shellfish.Checked;
            prefs.SetPref("shellfish", !shellfish.Checked);
        }

        protected void Gluten_CheckedChanged(object sender, EventArgs e)
        {
            gluten.Checked = !gluten.Checked;
            prefs.SetPref("gluten", gluten.Checked);
        }

        protected void Lactose_CheckedChanged(object sender, EventArgs e)
        {
            lactose.Checked = !lactose.Checked;
            prefs.SetPref("lactose", lactose.Checked);
        }
    }
}