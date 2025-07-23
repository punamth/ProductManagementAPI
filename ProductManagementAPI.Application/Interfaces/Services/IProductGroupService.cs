using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManagementAPI.Domain.Entities;
using ProductManagementAPI.Application.DTOs.ProductGroups;

namespace ProductManagementAPI.Application.Interfaces
{
    public interface IProductGroupService
    {
        Task<IEnumerable<ProductGroupDto>> GetAllAsync();
        Task<ProductGroupDto?> GetByIdAsync(int id);
        Task<ProductGroupDto> CreateAsync(CreateProductGroupDto dto);
        Task<bool> UpdateAsync(int id, UpdateProductGroupDto dto);
        Task<bool> DeleteAsync(int id);
    }
}