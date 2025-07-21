using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Domain.Entities;
using ProductManagementAPI.Infrastructure.Data;
using ProductManagementAPI.Application.DTOs.ProductCategories;
using ProductManagementAPI.Application.Interfaces;

public class ProductCategoryService : IProductCategoryService
{
    private readonly AppDbContext _context;

    public ProductCategoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductCategoryDto>> GetAllAsync()
    {
        return await _context.ProductCategories
            .Select(c => new ProductCategoryDto
            {
                Id = c.Id,
                GroupId = c.GroupId,
                Name = c.Name,
                Description = c.Description,
                CreatedAt = c.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<ProductCategoryDto?> GetByIdAsync(int id)
    {
        var category = await _context.ProductCategories.FindAsync(id);
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
        _context.ProductCategories.Add(category);
        await _context.SaveChangesAsync();

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
        var category = await _context.ProductCategories.FindAsync(id);
        if (category == null) return false;

        if (dto.GroupId.HasValue) category.GroupId = dto.GroupId.Value;
        if (dto.Name != null) category.Name = dto.Name;
        if (dto.Description != null) category.Description = dto.Description;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _context.ProductCategories.FindAsync(id);
        if (category == null) return false;

        _context.ProductCategories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }
}