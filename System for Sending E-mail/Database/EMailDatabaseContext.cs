
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System_for_Sending_E_mail.Database.Models;

namespace System_for_Sending_E_mail.Database
{
    public class EMailDatabaseContext : DbContext
    {
        public EMailDatabaseContext(DbContextOptions<EMailDatabaseContext> options)
       : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Email> Emails { get; set; }
     
    }
}
