using System_for_Sending_E_mail.Database.Models;

namespace System_for_Sending_E_mail.Services.Abstracts
{
    public interface IEmailSender
    {
        void SendEmail(Email email);   
    }
}
