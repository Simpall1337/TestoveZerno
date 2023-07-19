using System.Collections.Generic;
using System.Reflection.Emit;
using TestZerno.Models;
using Microsoft.EntityFrameworkCore;
namespace TestZerno
{
    public class DataBaseContext : DbContext
    {
        private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.UseSqlServer("Server=localhost\\SASHASQL;Database=Zerno;Trusted_Connection=true;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>().Property(x => x.RecordDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<Table>().HasKey(x => x.Id);
            modelBuilder.Entity<Table>().Property(x => x.Id).ValueGeneratedOnAdd();
        }

        public DbSet<Table> table { get; set; }


    }

    
}
