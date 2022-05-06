using JShop.Core.Entities.Common;
using JShop.Core.Entities.Identity;

namespace JShop.Core.Entities
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public User? CreatedBy { get; set; }
        public User? UpdatedBy { get; set; }

        public IEnumerable<Product>? Products { get; set; }

        /// <summary>
        /// For EFCORE
        /// </summary>
        private Category()
        {

        }
        public Category(string name, string? description, bool isActive)
        {
            Name = name;
            Description = description;
            IsActive = isActive;
        }
    }
}
