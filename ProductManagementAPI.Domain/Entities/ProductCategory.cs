namespace ProductManagementAPI.Domain.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public ProductGroup? Group { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}