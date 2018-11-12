using HomeCook.Clases;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeCoock
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Click(object sender, EventArgs e)
        {
            if (user.Text != "" && email.Text != "" && password.Text != "" && location.Text != "")
            {
                Preferences prefs = new Preferences();
                prefs.SetPref("shellfish", shellfish.Checked);
                prefs.SetPref("gluten", gluten.Checked);
                prefs.SetPref("lactose", lactose.Checked);
                try
                {
                    Extras.Register(user.Text, email.Text, password.Text, location.Text, prefs);
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
        }
    }
}