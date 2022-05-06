using JShop.Core.Entities.Identity;

namespace JShop.Core.Entities.Common
{
    public abstract class AuditableEntity
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
