using Microsoft.AspNetCore.Identity;

namespace JShop.Core.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        #pragma warning disable CS8618
        public string Name { get; set; }  
        
        public IEnumerable<UserRole> UserRoles { get; set; }
        public IEnumerable<Order>? Orders { get; set; }
    }
}