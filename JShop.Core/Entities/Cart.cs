using JShop.Core.Entities.Common;
using JShop.Core.Entities.Identity;

namespace JShop.Core.Entities
{
    public class Cart : AuditableEntity
    {
        public User User { get; set; }

        public IEnumerable<Product>? Products { get; set; }

        /// <summary>
        /// For EFCORE
        /// </summary>
        private Cart()
        {

        }
        public Cart(User user)
        {
            User = user;
        }
    }
}
