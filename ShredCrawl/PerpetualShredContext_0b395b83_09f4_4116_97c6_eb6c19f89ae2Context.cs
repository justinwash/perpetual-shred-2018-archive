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
            optionsBuilder.UseSqlServer(@"Server=tcp:perpetualshred20180102115742dbserver.database.windows.net,1433;
                Initial Catalog=PerpetualShred20180102115742_db;Persist Security Info=False;
                User ID=Trifectuh;Password=***REMOVED***;MultipleActiveResultSets=False;
                Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            Console.WriteLine(@"using Remote DB");
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
