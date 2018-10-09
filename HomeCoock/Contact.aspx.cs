using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeCook
{
    public partial class Contact : Page
    {
        private User logedUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            logedUser = (User)Session["logedUser"];
        }
    }
}