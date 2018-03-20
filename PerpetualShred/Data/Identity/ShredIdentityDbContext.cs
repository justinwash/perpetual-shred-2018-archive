using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PerpetualShred.Data.Identity

{
    public class ShredIdentityDbContext 
        : IdentityDbContext<ShredIdentityUser, ShredIdentityRole, string>
    {
        public ShredIdentityDbContext(DbContextOptions<ShredIdentityDbContext> options)
            : base(options)
        { }
    }
}