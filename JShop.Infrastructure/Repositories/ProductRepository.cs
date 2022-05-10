using JShop.Core.Entities;
using JShop.Core.Repositories;
using JShop.Infrastructure.Data;

namespace JShop.Infrastructure.Repositories
{
    internal class ProductRepository : BaseRepository<Product>, IProductReposiotry
    {
        public ProductRepository(JShopContext context) : base(context)
        {
        }
    }
}
