using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Talabat.Apis.DTOs;
using Talabat.Core.Entities;
using Talabat.Core.Repository.contract;
using Talabat.Core.Specification.ProductSpecification;

namespace Talabat.Apis.Controllers
{

    public class ProductController(IGenericRepository<Product> _genericRepo,IMapper _mapper) : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> Get()
        {
            var products = await _genericRepo.GetAllWithSpecAsync(new ProductSpecification());
            return Ok(_mapper.Map<IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var product = await _genericRepo.GetByIdWithSpecAsync(new ProductSpecification(id));
            if (product == null) return NotFound();
            return Ok(_mapper.Map<ProductToReturnDto>(product));
        }
    }
}
