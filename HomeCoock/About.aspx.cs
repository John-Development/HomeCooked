using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

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
            var fromAddress = new MailAddress("homecooked.notify@gmail.com", "HomeCooked");
            var toAddress = new MailAddress("con.j.de.soria@gmail.com", "Juan Antonio");
            string fromPassword = Password.Text;
            string subject = "Mensaje de prueba";
            string body = Message.Text;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}