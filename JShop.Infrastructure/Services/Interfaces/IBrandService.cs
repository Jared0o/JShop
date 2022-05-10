using JShop.Infrastructure.Dto.Brand;

namespace JShop.Infrastructure.Services.Interfaces
{
    public interface IBrandService
    {
        public Task CreateBrandAsync(BrandRequest request, string userEmail);
        public Task UpdateBrandAsync(int id, BrandRequest request, string userEmail);
        public Task DeleteBrandAsync(int id, string userEmail);
        public Task<BrandResponse> GetBrandAsync(int id);
        public Task<IReadOnlyList<BrandResponse>> GetAllBrandAsync();
    }
}
