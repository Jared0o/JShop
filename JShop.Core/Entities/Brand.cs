using JShop.Core.Entities.Common;
using JShop.Core.Entities.Identity;

namespace JShop.Core.Entities
{
    public class Brand : AuditableEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public User? CreatedBy { get; set; }
        public User? UpdatedBy { get; set; }

        #pragma warning disable CS8618
        /// <summary>
        /// For EFCORE
        /// </summary>
        private Brand()
        {

        }

        public Brand(string name, string? description, bool isActive)
        {
            Name = name;
            Description = description;
            IsActive = isActive;
        }

    }
}
