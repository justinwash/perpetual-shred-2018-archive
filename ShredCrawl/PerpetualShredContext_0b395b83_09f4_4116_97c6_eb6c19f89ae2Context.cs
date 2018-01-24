using System;
using Microsoft.EntityFrameworkCore;

namespace ShredCrawl
{
    public sealed class PerpetualShredContext_0B395B8309F4411697C6Eb6C19F89Ae2Context : DbContext
    {
        public DbSet<WebVid> WebVid { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
				Database=PerpetualShredContext-0b395b83-09f4-4116-97c6-eb6c19f89ae2;
                Trusted_Connection=True;");}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebVid>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });
        }
    }
}
