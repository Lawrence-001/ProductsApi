using Products.Api.Models;

namespace Products.Api.Data
{
    public interface ICompanyRepo
    {
        
        IEnumerable<Company> GetCompanies();
        Company GetCompanyById(int id);
        Company AddCompany(Company company);
        Company UpdateCompany(int id,Company company);
        Company DeleteCompany(int id);  
    }
}
