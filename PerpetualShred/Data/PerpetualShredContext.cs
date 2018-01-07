using Microsoft.EntityFrameworkCore;

namespace PerpetualShred.Models
{
    public class PerpetualShredContext : DbContext
    {
        public PerpetualShredContext (DbContextOptions<PerpetualShredContext> options)
            : base(options)
        {
        }

        public DbSet<WebVid> WebVid { get; set; }
    }
}
