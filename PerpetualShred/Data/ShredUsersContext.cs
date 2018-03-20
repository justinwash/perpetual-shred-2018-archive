
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PerpetualShred.Models;

namespace PerpetualShred.Data
{
    public class ShredUsersContext : IdentityDbContext<ShredUser>
    {
        public ShredUsersContext(DbContextOptions<ShredUsersContext> options)
            : base(options)
        {
            
        }
    }
}