using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) :base(options)
        {

        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Platform>()
                .HasMany(p => p.Commands)
                .WithOne(p => p.Platform!)
                .HasForeignKey(p => p.PlatformId);
            
            modelBuilder
                .Entity<Command>()
                .HasOne(p => p.Platform)
                .WithMany(p => p.Commands)
                .HasForeignKey(p => p.PlatformId);

            modelBuilder.Entity<Platform>().HasData(
                new Platform { Id = 1, Name = ".NET 5", LicenseKey = "1111111" },
                new Platform { Id = 2, Name = "Docker", LicenseKey = "2222222" },
                new Platform { Id = 3, Name = "Windows", LicenseKey = "3333333" },
                new Platform { Id = 4, Name = "Ubuntu", LicenseKey = "4444444" },
                new Platform { Id = 5, Name = "Kubernetes", LicenseKey = "5555555" },
                new Platform { Id = 6, Name = "RedHat", LicenseKey = "666666" }
            );

            modelBuilder.Entity<Command>().HasData(
                new Command { Id = 1, HowTo = "HowTo .NET 5", CommandLine= "CommandLine1", PlatformId = 1 },
                new Command { Id = 2, HowTo = "HowTo Docker", CommandLine= "CommandLine2", PlatformId = 2 },
                new Command { Id = 3, HowTo = "HowTo Windows", CommandLine= "CommandLine3", PlatformId = 3 },
                new Command { Id = 4, HowTo = "HowTo Ubuntu", CommandLine= "CommandLine4", PlatformId = 4 },
                new Command { Id = 5, HowTo = "HowTo Kubernetes", CommandLine= "CommandLine5", PlatformId = 5 },
                new Command { Id = 6, HowTo = "HowTo RedHat1", CommandLine= "CommandLine6", PlatformId = 6 },
                new Command { Id = 7, HowTo = "HowTo RedHat2", CommandLine= "CommandLine7", PlatformId = 6 },
                new Command { Id = 8, HowTo = "HowTo RedHat3", CommandLine= "CommandLine8", PlatformId = 6 },
                new Command { Id = 9, HowTo = "HowTo RedHat4", CommandLine= "CommandLine9", PlatformId = 6 },
                new Command { Id = 10, HowTo = "HowTo .NET 5-1", CommandLine= "CommandLine10", PlatformId = 1 },
                new Command { Id = 11, HowTo = "HowTo .NET 5-2", CommandLine= "CommandLine11", PlatformId = 1 }
            );
        }
    }
}