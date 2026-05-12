using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repository.contract;
using Talabat.Core.Specification.ProductSpecification;

namespace Talabat.Apis.Controllers
{

    public class ProductController(IGenericRepository<Product> _genericRepo) : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> Get()
        {
            var products = await _genericRepo.GetAllWithSpecAsync(new ProductSpecification());
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var product = await _genericRepo.GetByIdWithSpecAsync(new ProductSpecification(id));
            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}
