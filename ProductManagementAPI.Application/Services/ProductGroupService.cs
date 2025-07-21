using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Domain.Entities;
using ProductManagementAPI.Infrastructure.Data;
using ProductManagementAPI.Application.DTOs.ProductGroups;
using ProductManagementAPI.Application.Interfaces;

public class ProductGroupService : IProductGroupService
{
    private readonly AppDbContext _context;

    public ProductGroupService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductGroupDto>> GetAllAsync()
    {
        return await _context.ProductGroups
            .Select(g => new ProductGroupDto
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description,
                CreatedAt = g.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<ProductGroupDto?> GetByIdAsync(int id)
    {
        var group = await _context.ProductGroups.FindAsync(id);
        if (group == null) return null;

        return new ProductGroupDto
        {
            Id = group.Id,
            Name = group.Name,
            Description = group.Description,
            CreatedAt = group.CreatedAt
        };
    }

    public async Task<ProductGroupDto> CreateAsync(CreateProductGroupDto dto)
    {
        var group = new ProductGroup
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };
        _context.ProductGroups.Add(group);
        await _context.SaveChangesAsync();

        return new ProductGroupDto
        {
            Id = group.Id,
            Name = group.Name,
            Description = group.Description,
            CreatedAt = group.CreatedAt
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateProductGroupDto dto)
    {
        var group = await _context.ProductGroups.FindAsync(id);
        if (group == null) return false;

        if (dto.Name != null) group.Name = dto.Name;
        if (dto.Description != null) group.Description = dto.Description;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var group = await _context.ProductGroups.FindAsync(id);
        if (group == null) return false;

        _context.ProductGroups.Remove(group);
        await _context.SaveChangesAsync();
        return true;
    }
}