using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Products.Api.Data;
using Products.Api.DTOs.Category;
using Products.Api.Models;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepo _repo;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return Ok(_repo.GetCategories());
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var result = _repo.GetCategoryById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Category> AddCategory([FromBody] CategoryCreateDto category)
        {
            if (category != null)
            {
                var result = _mapper.Map<Category>(category);
                var cat = _repo.AddCategory(result);
                return CreatedAtAction(nameof(GetCategoryById), new { id = cat.Id }, cat);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult<Category> UpdateCategory(int id, [FromBody]CategoryCreateDto categoryUpdateDto)
        {
            var result = _repo.GetCategoryById(id);
            if (result != null)
            {
                var categoryToUpdate = _mapper.Map<Category>(categoryUpdateDto);
                _repo.UpdateCategory(id, categoryToUpdate);
                return Ok(categoryToUpdate);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<Category> DeleteCategory(int id)
        {
            var result = _repo.GetCategoryById(id);
            if (result != null)
            {
                return _repo.DeleteCategory(id);
            }
            return NotFound();
        }
    }
}
