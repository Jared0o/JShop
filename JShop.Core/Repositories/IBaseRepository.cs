using JShop.Core.Entities.Common;

namespace JShop.Core.Repositories
{
    public interface IBaseRepository<T> where T : AuditableEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
