using ProductManagementAPI.Domain.Entities;
using ProductManagementAPI.Application.DTOs.ProductCategories;
using ProductManagementAPI.Application.Interfaces.Repositories;
using ProductManagementAPI.Application.Interfaces;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _repository;

    public ProductCategoryService(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductCategoryDto>> GetAllAsync()
    {
        var categories = await _repository.GetAllAsync();
        return categories.Select(c => new ProductCategoryDto
        {
            Id = c.Id,
            GroupId = c.GroupId,
            Name = c.Name,
            Description = c.Description,
            CreatedAt = c.CreatedAt
        });
    }

    public async Task<ProductCategoryDto?> GetByIdAsync(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        if (category == null) return null;

        return new ProductCategoryDto
        {
            Id = category.Id,
            GroupId = category.GroupId,
            Name = category.Name,
            Description = category.Description,
            CreatedAt = category.CreatedAt
        };
    }

    public async Task<ProductCategoryDto> CreateAsync(CreateProductCategoryDto dto)
    {
        var category = new ProductCategory
        {
            GroupId = dto.GroupId,
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(category);

        return new ProductCategoryDto
        {
            Id = category.Id,
            GroupId = category.GroupId,
            Name = category.Name,
            Description = category.Description,
            CreatedAt = category.CreatedAt
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateProductCategoryDto dto)
    {
        var category = await _repository.GetByIdAsync(id);
        if (category == null) return false;

        if (dto.GroupId.HasValue) category.GroupId = dto.GroupId.Value;
        if (dto.Name != null) category.Name = dto.Name;
        if (dto.Description != null) category.Description = dto.Description;

        await _repository.UpdateAsync(category);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        if (category == null) return false;

        await _repository.DeleteAsync(id);
        return true;
    }
}
