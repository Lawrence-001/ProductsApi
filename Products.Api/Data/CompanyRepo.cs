using Products.Api.Models;

namespace Products.Api.Data
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly ApiDbContext _context;

        public CompanyRepo(ApiDbContext context)
        {
            _context = context;
        }
        public Company AddCompany(Company company)
        {
            if (company != null)
            {
                _context.Companies.Add(company);
                _context.SaveChanges();
                return company;
            }
            return null;
        }

        public Company DeleteCompany(int id)
        {
            var result = _context.Companies.FirstOrDefault(c => c.Id == id);
            if (result != null)
            {
                _context.Companies.Remove(result);
                _context.SaveChanges();
                return result;
            }
            return null;
        }

        public IEnumerable<Company> GetCompanies()
        {
            return _context.Companies.ToList();
        }

        public Company GetCompanyById(int id)
        {
            return _context.Companies.FirstOrDefault(c => c.Id == id);

        }

        public Company UpdateCompany(int id, Company company)
        {
            var result = _context.Companies.FirstOrDefault(c => c.Id == id);
            if (result != null)
            {
                result.Name = company.Name;

                _context.Companies.Update(result);
                _context.SaveChanges();
                return result;
            }
            return null;
        }
    }
}
