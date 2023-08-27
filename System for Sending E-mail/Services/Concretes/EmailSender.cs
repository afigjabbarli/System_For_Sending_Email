using MailKit.Net.Smtp;
using MimeKit;
using System_for_Sending_E_mail.Database.Models;
using System_for_Sending_E_mail.Services.Abstracts;
using System_for_Sending_E_mail.Services.EmailService;

namespace System_for_Sending_E_mail.Services.Concretes
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfiguration;

        public EmailSender(EmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }
        public void SendEmail(Email email)
        {
            var message = CreateEmailMessage(email);

            Send(message);
        }

        private MimeMessage CreateEmailMessage(Email email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Jabbarli Afig", "afigtj@code.edu.az"));
            var toAddresses = new List<MailboxAddress>();
            foreach (var recipient in email.Recipients)
            {
                toAddresses.Add(new MailboxAddress(recipient, "afigtj@code.edu.az"));
            }

            message.To.AddRange(toAddresses);
           
            message.Subject = email.Title;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = email.Content };

            return message;
        }

        private void Send(MimeMessage mailMessage)
        {
            using(var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfiguration.UserName, _emailConfiguration.Password);

                    client.Send(mailMessage);
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
