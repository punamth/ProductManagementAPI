namespace ProductManagementAPI.Application.DTOs.ProductGroups
{
    public class CreateProductGroupDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}