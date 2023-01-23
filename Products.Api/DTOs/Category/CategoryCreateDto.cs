using System.ComponentModel.DataAnnotations;

namespace Products.Api.DTOs.Category
{
    public class CategoryCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
