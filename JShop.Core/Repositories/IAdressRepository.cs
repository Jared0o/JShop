using JShop.Core.Entities;
using JShop.Core.Entities.Identity;

namespace JShop.Core.Repositories
{
    public interface IAdressRepository : IBaseRepository<Adress>
    {
        Task<IReadOnlyList<Adress>> GetUserAdressesAsync(User user);
        Task<Adress> GetUserAdressByIdAsync(User user, int adressId);
    }
}
