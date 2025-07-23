using ProductManagementAPI.Domain.Entities;
using ProductManagementAPI.Application.DTOs.ProductCategories;
using ProductManagementAPI.Application.Interfaces.Repositories;
using ProductManagementAPI.Application.Interfaces;
using AutoMapper;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _repository;
    private readonly IMapper _mapper;

    public ProductCategoryService(IProductCategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductCategoryDto>> GetAllAsync()
    {
        var categories = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductCategoryDto>>(categories);
    }

    public async Task<ProductCategoryDto?> GetByIdAsync(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        if (category == null) return null;

        return _mapper.Map<ProductCategoryDto>(category);
    }

    public async Task<ProductCategoryDto> CreateAsync(CreateProductCategoryDto dto)
    {
        var category = _mapper.Map<ProductCategory>(dto);
        category.CreatedAt = DateTime.UtcNow;
        await _repository.AddAsync(category);
        return _mapper.Map<ProductCategoryDto>(category);
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
