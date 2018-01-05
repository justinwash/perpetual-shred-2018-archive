using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShredCrawl
{
    public partial class PerpetualShredContext_0b395b83_09f4_4116_97c6_eb6c19f89ae2Context : DbContext
    {
        public virtual DbSet<WebVid> WebVid { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
				Database=PerpetualShredContext-0b395b83-09f4-4116-97c6-eb6c19f89ae2;
                Trusted_Connection=True;");
                Console.WriteLine("using Local DB");
            }
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
