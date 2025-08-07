using ProductManagementAPI.Domain.Entities;

namespace ProductManagementAPI.Application.Interfaces.Repositories
{
    public interface IProductGroupRepository
    {
        Task<ProductGroup?> GetByIdAsync(int id);
        Task<IEnumerable<ProductGroup>> GetAllAsync();
        Task AddAsync(ProductGroup group);
        Task UpdateAsync(ProductGroup group);
        Task DeleteAsync(int id);
    }
}
