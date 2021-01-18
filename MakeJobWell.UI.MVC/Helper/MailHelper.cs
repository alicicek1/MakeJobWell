using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Helper
{
    public class MailHelper
    {
        public static bool SendActivationCode(string firstName, string mail, Guid activationCode)
        {
            MailMessage message = new MailMessage();
            message.To.Add(mail);
            message.Subject = "Make Job Well Activation Code";
            message.IsBodyHtml = true;
            //message.CC.Add(new MailAddress("malicicek1@gmail.com"));
            message.Body = string.Format("<!DOCTYPE html><html><head><title>Make Job Well</title></head><body><h2>Hello {0},</h2><p>Click to activate your account<a href='http://localhost:59143/Login/ActiveUser/{1}'> link.</a></p></body></html>", firstName, activationCode);
            message.From = new MailAddress("m_a_l_i_188@hotmail.com", "Make Job Well");


            //SMTP
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Host = "smtp.live.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            NetworkCredential credential = new NetworkCredential("m_a_l_i_188@hotmail.com", "mali181920");
            client.Credentials = credential;
            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
