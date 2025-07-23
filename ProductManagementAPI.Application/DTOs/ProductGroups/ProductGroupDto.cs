namespace ProductManagementAPI.Application.DTOs.ProductGroups
{
    public class ProductGroupDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}