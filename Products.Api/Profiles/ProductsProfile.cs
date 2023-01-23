using AutoMapper;
using Products.Api.DTOs.Product;
using Products.Api.Models;

namespace Products.Api.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
