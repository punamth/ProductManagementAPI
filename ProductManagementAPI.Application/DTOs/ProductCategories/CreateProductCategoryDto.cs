namespace ProductManagementAPI.Application.DTOs.ProductCategories
{
    public class CreateProductCategoryDto
    {
        public int GroupId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}