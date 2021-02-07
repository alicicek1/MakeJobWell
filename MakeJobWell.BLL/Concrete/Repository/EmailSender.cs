using MakeJobWell.BLL.Abstract.IRepository;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MakeJobWell.BLL.Concrete.Repository
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration configuration;
        public EmailSender(IConfiguration conf)
        {
            configuration = conf;
        }
        public async Task Sender(string firstName, string mail, Guid activationCode)
        {
            var apiKey = configuration.GetSection("APIs")["SendGridAPI"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("m_a_l_i_188@hotmail.com", "Example User");
            var subject = "Make Job Well Activation Code";
            var to = new EmailAddress($"{mail}");
            //var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = string.Format("<!DOCTYPE html><html><head><title>Make Job Well</title></head><body><h2>Hello {0},</h2><p>Click to activate your account<a href='http://localhost:59143/Login/ActiveUser/{1}'> link.</a></p></body></html>", firstName, activationCode);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
