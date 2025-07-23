using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Application.Interfaces.Repositories;
using ProductManagementAPI.Domain.Entities;
using ProductManagementAPI.Infrastructure.Data;

namespace ProductManagementAPI.Infrastructure.Repositories
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        private readonly AppDbContext _context;

        public ProductGroupRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductGroup?> GetByIdAsync(int id)
        {
            return await _context.ProductGroups
                .Include(g => g.Categories)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<ProductGroup>> GetAllAsync()
        {
            return await _context.ProductGroups
                .Include(g => g.Categories)
                .OrderBy(g => g.Name)
                .ToListAsync();
        }

        public async Task AddAsync(ProductGroup group)
        {
            await _context.ProductGroups.AddAsync(group);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductGroup group)
        {
            _context.ProductGroups.Update(group);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var group = await _context.ProductGroups.FindAsync(id);
            if (group != null)
            {
                _context.ProductGroups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }
    }
}
