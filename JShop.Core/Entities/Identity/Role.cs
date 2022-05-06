using Microsoft.AspNetCore.Identity;

namespace JShop.Core.Entities.Identity
{
    #pragma warning disable CS8618
    public class Role : IdentityRole<int>
    {        
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
