namespace System_for_Sending_E_mail.ViewModels.User.Email
{
    public class DetailsEmailViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string[] Recipients { get; set; }

        public DateTime DateSent { get; set; } = DateTime.Now;
    }
}
