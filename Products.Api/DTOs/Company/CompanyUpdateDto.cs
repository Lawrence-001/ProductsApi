using System.ComponentModel.DataAnnotations;

namespace Products.Api.DTOs.Company
{
    public class CompanyUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
