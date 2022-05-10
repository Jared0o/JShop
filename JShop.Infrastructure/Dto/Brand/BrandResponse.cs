namespace JShop.Infrastructure.Dto.Brand
{
    public class BrandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        public BrandResponse(int id, string name, string? description, bool isActive)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
        }
    }
}
