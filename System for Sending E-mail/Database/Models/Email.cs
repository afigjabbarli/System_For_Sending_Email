namespace System_for_Sending_E_mail.Database.Models
{
    public class Email
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Content { get; set; } 
        public string[] Recipients { get; set; }
        public DateTime DateSent { get; set; } = DateTime.UtcNow;
    }
}
