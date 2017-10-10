using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PerpetualShred.Models
{
    public class PerpetualShredContext : DbContext
    {
        public PerpetualShredContext (DbContextOptions<PerpetualShredContext> options)
            : base(options)
        {
        }

        public DbSet<PerpetualShred.Models.WebVid> WebVid { get; set; }
    }
}
