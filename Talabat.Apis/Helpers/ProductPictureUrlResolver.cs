using AutoMapper;
using Talabat.Apis.DTOs;
using Talabat.Core.Entities;

namespace Talabat.Apis.Helpers
{
    public class ProductPictureUrlResolver(IConfiguration _configuration)
              : IValueResolver<Product, ProductToReturnDto, string>
    {

        public string Resolve(
            Product source,
            ProductToReturnDto destination,
            string destMember,
            ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["ApiBaseUrl"]}{source.PictureUrl}";
            }

            return string.Empty;
        }
    }
}
