using JShop.Core.Entities.Common;
using JShop.Core.Entities.Identity;

namespace JShop.Core.Entities
{
    public class Order : AuditableEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public Adress Adress { get; set; }

        public IEnumerable<Product>? Products { get; set; }


        /// <summary>
        /// For EFCORE
        /// </summary>
        private Order()
        {

        }
        public Order(User user, Adress adress)
        {
            User = user;
            Adress = adress;
        }
    }
}
