using Talabat.Core.Entities;

namespace Talabat.Core.Specification.ProductSpecification
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        // Get All Products
        public ProductSpecification()
            : base()
        {
            AddInclude(p => p.Brand);
            AddInclude(p => p.Category);
        }

        // Get Product By Id
        public ProductSpecification(int id)
            : base(p => p.Id == id)
        {
            AddInclude(p => p.Brand);
            AddInclude(p => p.Category);
        }
    }
}
