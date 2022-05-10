using JShop.Infrastructure.Dto.Tax;

namespace JShop.Infrastructure.Services.Interfaces
{
    public interface ITaxService
    {
        public Task CreateTaxAsync(TaxRequest request, string userEmail);
        public Task UpdateTaxAsync(int id, TaxRequest request, string userEmail);
        public Task DeleteTaxAsync(int taxId, string userEmail);
        public Task<TaxResponse> GetTaxAsync(int id);
        public Task<IReadOnlyList<TaxResponse>> GetAllTaxAsync();
    }
}
