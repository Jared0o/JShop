namespace JShop.Infrastructure.Dto.Brand
{
    public class BrandRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        public BrandRequest(string name, string? description, bool isActive)
        {
            Name = name;
            Description = description;
            IsActive = isActive;
        }
    }
}
