using HomeCook.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeCook
{
    public partial class About : Page
    {
        private User logedUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            logedUser = (User)Session["logedUser"];
        }

        protected void Send_Click(object sender, EventArgs e)
        {
            
        }
    }
}