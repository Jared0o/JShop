using JShop.Core.Entities.Common;
using JShop.Core.Entities.Identity;

namespace JShop.Core.Entities
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public Tax? Tax { get; set; }
        public string? Description { get; set; }
        public Brand? Brand { get; set; }
        public bool IsActive { get; set; }
        public Category? Category { get; set; }
        public int InStock { get; set; }
        public float Price { get; set; }
        public string? Sku { get; set; }

        public User? CreatedBy { get; set; }
        public User? UpdatedBy { get; set; }

        public IEnumerable<Cart>? Carts { get; set; }
        public IEnumerable<Order>? Orders { get; set; }

        /// <summary>
        /// For EFCORE
        /// </summary>
        private Product()
        {

        }
        public Product(string name, string slug, Tax? tax, string? description, Brand? brand, bool isActive, Category? category, int inStock, float price, string? sku)
        {
            Name = name;
            Slug = slug;
            Tax = tax;
            Description = description;
            Brand = brand;
            IsActive = isActive;
            Category = category;
            InStock = inStock;
            Price = price;
            Sku = sku;
        }


    }
}