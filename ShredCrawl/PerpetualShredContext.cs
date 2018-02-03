using System;
using Microsoft.EntityFrameworkCore;

namespace ShredCrawl
{
    public sealed class PerpetualShredContext : DbContext
    {
        public DbSet<WebVid> WebVid { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebVid>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });
        }
    }
}
