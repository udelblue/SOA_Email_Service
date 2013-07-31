using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmailService
{
   
    [ServiceContract]
    public interface ISMTPEmail
    {

        [OperationContract]
        bool Sendmail(string toAddress, string subject, string message);

        [OperationContract]
        bool SendMail(Email email);

        
    }




    

    [DataContract]
    public class Email
    {
        string toAddress = "noreply@mail.com";
        string subject = "Hello";
        string message = " ";

      [DataMember]
        public string ToAddress
        {
            get { return toAddress; }
            set { toAddress = value; }
        }

        [DataMember]
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }


          [DataMember]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }


}
