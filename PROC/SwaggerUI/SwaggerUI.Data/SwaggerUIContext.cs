using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwaggerUI.Domain.Email;
using SwaggerUI.Domain.TestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerUI.Data
{
    //Reverse existing DB to EF
    //PM> scaffold-dbcontext -provider Microsoft.EntityFrameworkCore.SqlServer -connection
    //"data source=MCTWF-APPDB;initial catalog=Shenyi;integrated security=True;MultipleActiveResultSets=True"
    public class SwaggerUIContext : DbContext
    {
        public DbSet<EmailMessage> EmailMessage { get; set; }
        //public DbSet<Company> Company { get; set; }
        //public DbSet<Employee> Employee { get; set; }

        public SwaggerUIContext(DbContextOptions<SwaggerUIContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=MCTWF-APPDB;initial catalog=Shenyi;integrated security=True;MultipleActiveResultSets=True")
                    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name//,
                                                                                            //DbLoggerCategory.Database.Transaction.Name
                    },
                        LogLevel.Information)
                    .EnableSensitiveDataLogging();
            }
        }

        /// <summary>
        /// Fluent API has more options than data annotation
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here
            modelBuilder.Entity<EmailMessage>()
                .ToTable("EmailMessages");
            //Cannot create a relationship between 'EmailMessage.ToAddresses' and 'EmailAddress.EmailMessage'
            //because a relationship already exists between 'EmailMessage.FromAddresses' and 'EmailAddress.EmailMessage'.
            //modelBuilder.Entity<EmailMessage>()
            //    .HasMany(c => c.FromAddresses)
            //    .WithOne(e => e.EmailMessage);
            //modelBuilder.Entity<EmailAddress>()
            //    .HasOne(c => c.EmailMessage)
            //    .WithMany(e => e.ToAddresses);
            base.OnModelCreating(modelBuilder);
        }
    }
}
