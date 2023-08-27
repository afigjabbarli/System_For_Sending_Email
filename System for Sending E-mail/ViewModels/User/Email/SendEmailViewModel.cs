using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace System_for_Sending_E_mail.ViewModels.User.Email
{
    public class SendEmailViewModel
    {
        [Required(ErrorMessage = "This field cannot be empty! Please enter subject...")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Subject must be between 5 and 50 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "This field cannot be empty! Please enter content...")]
        [StringLength(600, MinimumLength = 25, ErrorMessage = "Content must be between 25 and 600 characters")]
        [RegularExpression("^[a-zA-Z0-9.,!?\\-'\"() ]+$", ErrorMessage = "The content you included is wrong!")]
        public string Content { get; set; }
        [Required(ErrorMessage = "This field cannot be empty! Please enter recipients...")]
        [IsUniqueEmail]
        [ValidateRecipients(ErrorMessage = "Invalid recipient email address")]
        [MaxRecipients(5, ErrorMessage = "Maximum of 5 recipients allowed")]
        public string Recipients { get; set; }

    }

    public class ValidateRecipientsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {

                var recipients = ((string)value).Split(',').Select(r => r.Trim());

                foreach (var recipient in recipients)
                {
                    if (!IsValidEmail(recipient))
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }
            }

            return ValidationResult.Success;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

    public class MaxRecipientsAttribute : ValidationAttribute
    {
        private readonly int _maxRecipients;

        public MaxRecipientsAttribute(int maxRecipients)
        {
            _maxRecipients = maxRecipients;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var recipients = ((string)value).Split(',').Select(r => r.Trim());

                if (recipients.Count() > _maxRecipients)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
    public class IsUniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
               var recipients = ((string)value).Split(',').Select(r => r.Trim()).ToArray();
               if (recipients.Length != recipients.Distinct().Count())
               {
                return new ValidationResult(ErrorMessage = "Email cannot be duplicated!");
               }
              

            }
            return ValidationResult.Success;
        }
    }




}



