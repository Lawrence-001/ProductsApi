using System.ComponentModel.DataAnnotations;

namespace Products.Api.DTOs.Company
{
    public class CompanyCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
