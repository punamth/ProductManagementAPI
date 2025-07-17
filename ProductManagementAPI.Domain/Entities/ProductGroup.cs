namespace ProductManagementAPI.Domain.Entities
{
    public class ProductGroup
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property
        public ICollection<ProductCategory> Categories { get; set; } = new List<ProductCategory>();
    }
}