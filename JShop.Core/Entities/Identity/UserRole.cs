using Microsoft.AspNetCore.Identity;

namespace JShop.Core.Entities.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        #pragma warning disable CS8618
        public User User { get; set; }
        public Role Role { get; set; }
    }
}