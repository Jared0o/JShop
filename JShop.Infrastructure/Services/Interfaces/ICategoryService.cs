using JShop.Infrastructure.Dto.Category;

namespace JShop.Infrastructure.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task CreateAsync(CategoryRequest request, string userEmail);
        public Task UpdateAsync(int id, CategoryRequest request, string userEmail);
        public Task DeleteAsync(int CategoryId, string userEmail);
        public Task<CategoryResponse> GetAsync(int id);
        public Task<IReadOnlyList<CategoryResponse>> GetAllAsync();
    }
}
