using System_for_Sending_E_mail.Services.Abstracts;
using System_for_Sending_E_mail.Services.Concretes;

namespace System_for_Sending_E_mail.Services.EmailService
{
    public class EmailSettingsService
    {
        public IConfiguration Configuration { get; set; }
        public EmailSettingsService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var emailConfiguration = Configuration.GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfiguration);
           
        }
    }
}
