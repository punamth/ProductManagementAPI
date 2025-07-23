using AutoMapper;
using ProductManagementAPI.Application.DTOs.ProductGroups;
using ProductManagementAPI.Application.Interfaces;
using ProductManagementAPI.Application.Interfaces.Repositories;
using ProductManagementAPI.Domain.Entities;

public class ProductGroupService : IProductGroupService
{
    private readonly IProductGroupRepository _repository;
    private readonly IMapper _mapper;

    public ProductGroupService(IProductGroupRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductGroupDto>> GetAllAsync()
    {
        var groups = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductGroupDto>>(groups);
    }

    public async Task<ProductGroupDto?> GetByIdAsync(int id)
    {
        var group = await _repository.GetByIdAsync(id);
        return group == null ? null : _mapper.Map<ProductGroupDto>(group);
    }

    public async Task<ProductGroupDto> CreateAsync(CreateProductGroupDto dto)
    {
        var group = _mapper.Map<ProductGroup>(dto);
        group.CreatedAt = DateTime.UtcNow;
        await _repository.AddAsync(group);
        return _mapper.Map<ProductGroupDto>(group);
    }

    public async Task<bool> UpdateAsync(int id, UpdateProductGroupDto dto)
    {
        var group = await _repository.GetByIdAsync(id);
        if (group == null) return false;
        _mapper.Map(dto, group);
        await _repository.UpdateAsync(group);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var group = await _repository.GetByIdAsync(id);
        if (group == null) return false;
        await _repository.DeleteAsync(id);
        return true;
    }
}