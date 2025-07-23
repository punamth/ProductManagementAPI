using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Application.DTOs.ProductCategories
{
    public class UpdateProductCategoryDto
    {
        public int? GroupId { get; set; }

        [StringLength(200, MinimumLength = 1)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}