using System.Linq.Expressions;
using Talabat.Core.Entities;

namespace Talabat.Core.Specification
{
    public interface ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T,bool>>? Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; }

        //Expression<Func<T, object>>? OrderBy { get; }
        //Expression<Func<T, object>>? OrderByDescending { get; }
        //int Take { get; }
        //int Skip { get; }
        //bool IsPagingEnabled { get; }
    }
}
