using Microsoft.AspNetCore.Identity;

namespace PerpetualShred.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ShredUser : IdentityUser
    {
        public string Favorites { get; set; }
    }
}

