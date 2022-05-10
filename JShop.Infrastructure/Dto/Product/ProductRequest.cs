namespace JShop.Infrastructure.Dto.Product
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public int? TaxId { get; set; }
        public string? Description { get; set; }
        public int? BrandId { get; set; }
        public bool IsActive { get; set; }
        public int? CategoryId { get; set; }
        public int InStock { get; set; }
        public float Price { get; set; }
        public string? Sku { get; set; }

        public ProductRequest(string name, int? taxId, string? description, int? brandId, bool isActive, int? categoryId, int inStock, float price, string? sku)
        {
            Name = name;
            TaxId = taxId;
            Description = description;
            BrandId = brandId;
            IsActive = isActive;
            CategoryId = categoryId;
            InStock = inStock;
            Price = price;
            Sku = sku;
        }
    }
}
