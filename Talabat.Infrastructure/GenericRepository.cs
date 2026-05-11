using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities;
using Talabat.Core.Repository.contract;
using Talabat.Infrastructure.Data;

namespace Talabat.Infrastructure
{
    public class GenericRepository<T>(StoreContext _context) : IGenericRepository<T> where T : BaseEntity
    {
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
