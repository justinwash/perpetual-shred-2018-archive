
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
            optionsBuilder.UseSqlServer("Server=localhost;Database=PerpetualShredContext;User Id=SA;Password=Trif3ctuh");
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
