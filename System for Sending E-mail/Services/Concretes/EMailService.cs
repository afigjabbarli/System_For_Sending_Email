using System.Net;
using System.Net.Mail;
using System.Text;
using System_for_Sending_E_mail.Services.Abstracts;

namespace System_for_Sending_E_mail.Services.Concretes
{
    public class EMailService : IEMailService
    {
       

        public async Task SendMessageAsync(string Recipient, string Subject, string Body, bool isBodyHTML, string From, string DisplayName)
        {
            await SendMessageAsync(new[] { Recipient }, Subject, Body, isBodyHTML, From, DisplayName);
        }
        public async Task SendMessageAsync(string[] Recipients, string Subject, string Body, bool isBodyHTML, string From, string DisplayName)
        {
            MailMessage message = new MailMessage();
            message.IsBodyHtml = isBodyHTML;
            foreach (string Recipient in Recipients)
                message.To.Add(Recipient);
            message.Subject = Subject;
            message.Body = Body;
            message.From = new(From, DisplayName, Encoding.UTF8);


            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(From, "****");
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Host = "smtp.yandex.ru";
            await smtpClient.SendMailAsync(message);


        }

    }
}
