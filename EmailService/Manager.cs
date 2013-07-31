using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Net.Mail;

namespace EmailService
{
    public class Manager
    {

        public static void SendEmail(string toAddress, string subject, string message)
        {
            string host = ConfigurationManager.AppSettings["EmailServerHost"];
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["EmailServerPort"]);
            string domain = ConfigurationManager.AppSettings["EmailServerDomain"];
            string username = ConfigurationManager.AppSettings["EmailServerUsername"];
            string password = ConfigurationManager.AppSettings["EmailServerPassword"];
            string fromEmailAddress = ConfigurationManager.AppSettings["EmailFromAddress"];

           

            MailMessage mailMessage = new MailMessage(fromEmailAddress, toAddress);
            mailMessage.Subject = subject;
            //string queryString = "apkey=" + Convert.ToString(2);

            mailMessage.Body = message;
            mailMessage.IsBodyHtml = false;

            System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(username, password, domain);

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = host;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Port = port;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = networkCredential;

            smtpClient.Send(mailMessage);

        }


    }
}
