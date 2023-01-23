using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Products.Api.Data;
using Products.Api.DTOs.Product;
using Products.Api.Models;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _repo;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_repo.GetProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var result = _repo.GetProductById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Product> AddProduct([FromBody]ProductCreateDto product)
        {
            if (product != null)
            {
                var p = _mapper.Map<Product>(product);
                var result = _repo.AddProduct(p);
                return CreatedAtAction(nameof(GetProductById), new { id = result.Id }, result);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(int id, [FromBody]ProductCreateDto productUpdateDto)
        {
            var prod = _repo.GetProductById(id);
            if (prod != null)
            {
                var result = _mapper.Map<Product>(productUpdateDto);
                _repo.UpdateProduct(id,result);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            var p = _repo.GetProductById(id);
            if (p != null)
            {
                return Ok(_repo.DeleteProduct(id));
            }
            return NotFound();
        }
    }
}
