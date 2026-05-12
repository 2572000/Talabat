using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities;
using Talabat.Core.Specification;

namespace Talabat.Infrastructure
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;

            // Apply filter (WHERE clause)
            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria);


            query = spec.Includes.Aggregate(query,
            (current, include) => current.Include(include));
           
            return query;
        }
    }
}
