using ProductManagementAPI.Application.DTOs.Products;
using ProductManagementAPI.Application.Interfaces;
using ProductManagementAPI.Application.Interfaces.Repositories;
using ProductManagementAPI.Domain.Entities;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            CategoryId = p.CategoryId,
            Name = p.Name,
            Sku = p.Sku,
            Price = p.Price,
            StockQuantity = p.StockQuantity,
            Description = p.Description,
            CreatedAt = p.CreatedAt
        });
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return null;

        return new ProductDto
        {
            Id = product.Id,
            CategoryId = product.CategoryId,
            Name = product.Name,
            Sku = product.Sku,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            Description = product.Description,
            CreatedAt = product.CreatedAt
        };
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto dto)
    {
        var product = new Product
        {
            CategoryId = dto.CategoryId,
            Name = dto.Name,
            Sku = dto.Sku,
            Price = dto.Price,
            StockQuantity = dto.StockQuantity,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };

        await _productRepository.AddAsync(product);

        return new ProductDto
        {
            Id = product.Id,
            CategoryId = product.CategoryId,
            Name = product.Name,
            Sku = product.Sku,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            Description = product.Description,
            CreatedAt = product.CreatedAt
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return false;

        if (dto.CategoryId.HasValue) product.CategoryId = dto.CategoryId.Value;
        if (dto.Name != null) product.Name = dto.Name;
        if (dto.Sku != null) product.Sku = dto.Sku;
        if (dto.Price.HasValue) product.Price = dto.Price.Value;
        if (dto.StockQuantity.HasValue) product.StockQuantity = dto.StockQuantity.Value;
        if (dto.Description != null) product.Description = dto.Description;

        await _productRepository.UpdateAsync(product);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return false;

        await _productRepository.DeleteAsync(id);
        return true;
    }
}
