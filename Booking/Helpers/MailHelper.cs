using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieBooking.Model.Entities;
using System.Net.Mail;
using System.Net;

namespace MovieBooking.MVC.Helpers
{
    public class MailHelper
    {
        public static void Send(string toEmailAddress, string fromEmailAddress, string subject, string message, string smtpServer)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(toEmailAddress);
                msg.From = new MailAddress(fromEmailAddress);
                msg.Subject = subject;
                msg.Body = message;
                msg.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient(smtpServer);
                //smtp.UseDefaultCredentials = false;
                //NetworkCredential crdntl = new NetworkCredential("smoneyan@gmail.com", "xxxx");
                //smtp.Credentials = crdntl;

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(msg);
            }catch(Exception ex){

            }

        }
    }
}
