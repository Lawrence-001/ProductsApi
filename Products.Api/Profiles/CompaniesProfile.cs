using AutoMapper;
using Products.Api.DTOs.Company;
using Products.Api.Models;

namespace Products.Api.Profiles
{
    public class CompaniesProfile: Profile
    {
        public CompaniesProfile()
        {
            CreateMap<CompanyCreateDto, Company>();
            CreateMap<CompanyUpdateDto, Company>();
        }
    }
}
