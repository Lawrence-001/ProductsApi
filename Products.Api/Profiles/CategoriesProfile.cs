using AutoMapper;
using Products.Api.DTOs.Category;
using Products.Api.Models;

namespace Products.Api.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<CategoryCreateDto, Category>();
        }
    }
}
