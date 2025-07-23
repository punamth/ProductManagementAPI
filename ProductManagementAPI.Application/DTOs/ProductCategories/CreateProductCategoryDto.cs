using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Application.DTOs.ProductCategories
{
    public class CreateProductCategoryDto
    {
        [Required]
        public int GroupId { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public required string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}