namespace JShop.Infrastructure.Dto.Category
{
    public class CategoryRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        public CategoryRequest(string name, string? description, bool isActive)
        {
            Name = name;
            Description = description;
            IsActive = isActive;
        }
    }
}
