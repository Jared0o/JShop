using JShop.Infrastructure.Dto.Brand;
using JShop.Infrastructure.Dto.Category;
using JShop.Infrastructure.Dto.Tax;

namespace JShop.Infrastructure.Dto.Product
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public TaxResponse? Tax { get; set; }
        public string? Description { get; set; }
        public BrandResponse Brand { get; set; }
        public bool IsActive { get; set; }
        public CategoryResponse? Category { get; set; }
        public int InStock { get; set; }
        public float Price { get; set; }
        public string? Sku { get; set; }

        public ProductResponse(int id, string name, string slug, TaxResponse? tax, string? description, BrandResponse brand, bool isActive, CategoryResponse? category, int inStock, float price, string? sku)
        {
            Id = id;
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
