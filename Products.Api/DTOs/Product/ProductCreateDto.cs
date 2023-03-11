using System.ComponentModel.DataAnnotations;

namespace Products.Api.DTOs.Product
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string PictureName { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }

    public class ProductWithCategories
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string PictureName { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
