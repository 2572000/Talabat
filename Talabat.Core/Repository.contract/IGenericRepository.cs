using Talabat.Core.Entities;
using Talabat.Core.Specification;

namespace Talabat.Core.Repository.contract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T?> GetByIdWithSpecAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec);

        //Task<T> AddAsync(T entity);
        //Task UpdateAsync(T entity);
        //Task DeleteAsync(T entity);
    }
}
