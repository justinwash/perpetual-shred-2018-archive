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
                optionsBuilder.UseSqlServer(@"Server=tcp:perpetualshred20180102115742dbserver.database.windows.net,1433;Initial Catalog=PerpetualShred20180102115742_db;Persist Security Info=False;User ID=Trifectuh;Password=***REMOVED***;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
