using JShop.Infrastructure.Dto.Product;

namespace JShop.Infrastructure.Services.Interfaces
{
    public interface IProductService
    {
        public Task CreateAsync(ProductRequest request, string userEmail);
        public Task UpdateAsync(int id, ProductRequest request, string userEmail);
        public Task DeleteAsync(int id, string userEmail);
        public Task<ProductResponse> GetAsync(int id);
        public Task<IReadOnlyList<ProductResponse>> GetAllAsync();
    }
}
