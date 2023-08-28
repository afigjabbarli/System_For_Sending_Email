namespace System_for_Sending_E_mail.Services.Abstracts
{
    public interface IEMailService
    {
        Task SendMessageAsync(string[] Recipients, string Subject, string Body, bool isBodyHTML = true, string From = null, string DisplayName = null);
        Task SendMessageAsync(string Recipient, string Subject, string Body, bool isBodyHTML, string From, string DisplayName);
    }
}
