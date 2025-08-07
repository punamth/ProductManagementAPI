namespace ProductManagementAPI.Application.DTOs.Products
{
    public class UpdateProductDto
    {
        public int? CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Sku { get; set; }
        public decimal? Price { get; set; }
        public int? StockQuantity { get; set; }
        public string? Description { get; set; }
    }
}