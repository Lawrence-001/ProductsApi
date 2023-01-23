using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Products.Api.Data;
using Products.Api.DTOs.Company;
using Products.Api.Models;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepo _repo;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Company>> GetCompanies()
        {
            return Ok(_repo.GetCompanies());

        }

        [HttpGet("{id}")]
        public ActionResult<Company> GetCompanyById(int id)
        {
            var result = _repo.GetCompanyById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Company> AddCompany([FromBody] CompanyCreateDto company)
        {
            var result = _mapper.Map<Company>(company);
            _repo.AddCompany(result);
            return CreatedAtAction(nameof(GetCompanyById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public ActionResult<Company> UpdateCompany(int id,[FromBody] CompanyUpdateDto company)
        {
            var result = _repo.GetCompanyById(id);
            if (result != null)
            {
                var comp = _mapper.Map<Company>(company);
                _repo.UpdateCompany(id, comp);

                return Ok(comp);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult<Company> DeleteCompany(int id)
        {
            var result = _repo.GetCompanyById(id);
            if (result!=null)
            {
                return Ok(_repo.DeleteCompany(id));
            }
            return NotFound();
        }
    }
}
