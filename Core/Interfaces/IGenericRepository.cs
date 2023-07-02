

using Core.Entities;
using Core.Specefications;

namespace Core.Interfaces
{
    public interface  IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>>ListAllAsync();
        Task<T>GetEntityWithSpec(ISpecefications<T> spec);
        Task<IReadOnlyList<T>>ListAsync(ISpecefications<T> spec);
        Task<int> CountAsync(ISpecefications<T> spec);
    }
}