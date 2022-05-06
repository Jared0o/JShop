using JShop.Infrastructure.Dto.Tax;

namespace JShop.Infrastructure.Services.Interfaces
{
    public interface ITaxService
    {
        public Task CreateTax(TaxRequest request, string userEmail);
        public Task UpdateTax(int id, TaxRequest request, string userEmail);
        public Task DeleteTax(int taxId, string userEmail);
        public Task<TaxResponse> GetTax(int tax);
        public Task<IReadOnlyList<TaxResponse>> GetAllTax();
    }
}
