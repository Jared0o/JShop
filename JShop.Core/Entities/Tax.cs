using JShop.Core.Entities.Common;
using JShop.Core.Entities.Identity;

namespace JShop.Core.Entities
{
    public class Tax : AuditableEntity
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public User? CreatedBy { get; set; }
        public User? UpdatedBy { get; set; }

        /// <summary>
        /// For EFCORE
        /// </summary>
        private Tax()
        {

        }

        public Tax(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
