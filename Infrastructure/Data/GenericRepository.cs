

using Core.Entities;
using Core.Interfaces;
using Core.Specefications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetEntityWithSpec(ISpecefications<T> spec)
        {
            return await ApplySpecefications(spec).FirstOrDefaultAsync();
        }

      

        public async Task<IReadOnlyList<T>> ListAsync(ISpecefications<T> spec)
        {
            return await ApplySpecefications(spec).ToListAsync();
        }
        public async Task<int> CountAsync(ISpecefications<T> spec)
        {
            return await ApplySpecefications(spec).CountAsync();
        }
        private IQueryable<T> ApplySpecefications(ISpecefications<T> spec)
        {
            return SpeceficationsEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

       
    }
}