using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmailService
{

    public class SMTPEmail : ISMTPEmail
    {
     

    

        public bool Sendmail(string toAddress, string subject, string message)
        {
            bool sent = true;

            try
            {
                Manager.SendEmail(toAddress, subject, message);
            }
            catch (Exception ex)
            {

                sent = false;
            }

            return sent;

        }

        public bool SendMail(Email email)
        {
            bool sent = true;

            try
            {
                Manager.SendEmail(email.ToAddress, email.Subject, email.Message);
            }
            catch (Exception ex)
            {

                sent = false;
            }

            return sent;

        }

        
    }
}
