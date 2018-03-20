using Microsoft.AspNetCore.Identity;

namespace PerpetualShred.Data.Identity
{
    public class ShredIdentityUser : IdentityUser
    {
        public string Favorites { get; set; }
    }
}