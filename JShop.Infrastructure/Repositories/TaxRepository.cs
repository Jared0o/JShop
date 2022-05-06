using JShop.Core.Entities;
using JShop.Core.Repositories;
using JShop.Infrastructure.Data;

namespace JShop.Infrastructure.Repositories
{
    internal class TaxRepository : BaseRepository<Tax>, ITaxRepository
    {
        public TaxRepository(JShopContext context) : base(context)
        {
        }
    }
}
