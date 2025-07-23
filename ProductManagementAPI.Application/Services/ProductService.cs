using AutoMapper;
using ProductManagementAPI.Application.DTOs.Products;
using ProductManagementAPI.Application.Interfaces;
using ProductManagementAPI.Application.Interfaces.Repositories;
using ProductManagementAPI.Domain.Entities;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return null;
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        product.CreatedAt = DateTime.UtcNow;
        await _productRepository.AddAsync(product);
        return _mapper.Map<ProductDto>(product);
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
