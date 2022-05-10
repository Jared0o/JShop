using JShop.Core.Entities.Common;
using JShop.Core.Repositories;
using JShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JShop.Infrastructure.Repositories
{
    internal class BaseRepository<T> : IBaseRepository<T> where T : AuditableEntity
    {
        protected readonly JShopContext _context;

        public BaseRepository(JShopContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
        }

        public  async Task UpdateAsync(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
