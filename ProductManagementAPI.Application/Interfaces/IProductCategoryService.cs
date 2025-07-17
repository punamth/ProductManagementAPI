using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManagementAPI.Domain.Entities;
using ProductManagementAPI.Application.DTOs.ProductCategories;

public interface IProductCategoryService
{
    Task<IEnumerable<ProductCategoryDto>> GetAllAsync();
    Task<ProductCategoryDto?> GetByIdAsync(int id);
    Task<ProductCategoryDto> CreateAsync(CreateProductCategoryDto dto);
    Task<bool> UpdateAsync(int id, UpdateProductCategoryDto dto);
    Task<bool> DeleteAsync(int id);
}