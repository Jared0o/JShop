namespace JShop.Infrastructure.Dto.Category
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        public CategoryResponse(int id, string name, string? description, bool isActive)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
        }
    }
}
