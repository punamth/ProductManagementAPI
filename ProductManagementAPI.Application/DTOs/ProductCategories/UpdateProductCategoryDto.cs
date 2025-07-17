namespace ProductManagementAPI.Application.DTOs.ProductCategories
{
    public class UpdateProductCategoryDto
    {
        public int? GroupId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}