using HomeCook.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            }
        }

        protected void NewAdvert_Click(object sender, EventArgs e)
        {
            if (logedUser != null)
                Response.Redirect("/CreateAdvert");
            else
                Response.Redirect("/Login");
        }
    }
}