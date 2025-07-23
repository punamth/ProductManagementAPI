using ProductManagementAPI.Domain.Entities;

namespace ProductManagementAPI.Application.Interfaces.Repositories
{
    public interface IProductCategoryRepository
    {
        Task<ProductCategory?> GetByIdAsync(int id);
        Task<IEnumerable<ProductCategory>> GetAllAsync();
        Task AddAsync(ProductCategory category);
        Task UpdateAsync(ProductCategory category);
        Task DeleteAsync(int id);
    }
}
