namespace ProductManagementAPI.Application.DTOs.Products
{
    public class CreateProductDto
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public required string Sku { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? Description { get; set; }
    }

}
