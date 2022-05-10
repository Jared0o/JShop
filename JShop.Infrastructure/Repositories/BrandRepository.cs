using JShop.Core.Entities;
using JShop.Core.Repositories;
using JShop.Infrastructure.Data;

namespace JShop.Infrastructure.Repositories
{
    internal class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        public BrandRepository(JShopContext context) : base(context)
        {
        }
    }
}
