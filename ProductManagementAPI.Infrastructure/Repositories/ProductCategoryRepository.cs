using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Application.Interfaces.Repositories;
using ProductManagementAPI.Domain.Entities;
using ProductManagementAPI.Infrastructure.Data;

namespace ProductManagementAPI.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductCategory?> GetByIdAsync(int id)
        {
            return await _context.ProductCategories
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            return await _context.ProductCategories
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task AddAsync(ProductCategory category)
        {
            await _context.ProductCategories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductCategory category)
        {
            _context.ProductCategories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.ProductCategories
                .FirstOrDefaultAsync(x => x.Id == id);

            if (category != null)
            {
                _context.ProductCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}