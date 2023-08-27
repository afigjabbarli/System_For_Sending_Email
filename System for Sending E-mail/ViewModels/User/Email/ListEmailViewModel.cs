namespace System_for_Sending_E_mail.ViewModels.User.Email
{
    public class ListEmailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string[] Recipients { get; set; }
        public DateTime DateSent { get; set; }
    }
}
