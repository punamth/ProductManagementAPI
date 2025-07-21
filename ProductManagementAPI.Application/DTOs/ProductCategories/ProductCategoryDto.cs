namespace ProductManagementAPI.Application.DTOs.ProductCategories
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}