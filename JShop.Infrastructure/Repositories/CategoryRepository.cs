using JShop.Core.Entities;
using JShop.Core.Repositories;
using JShop.Infrastructure.Data;

namespace JShop.Infrastructure.Repositories
{
    internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(JShopContext context) : base(context)
        {
        }
    }
}
