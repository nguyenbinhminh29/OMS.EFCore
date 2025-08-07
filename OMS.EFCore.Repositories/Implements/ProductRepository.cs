using Microsoft.EntityFrameworkCore;
using OMS.EFCore.Data;
using OMS.EFCore.Domain.Entities;
using OMS.EFCore.Domain.Models;
using OMS.EFCore.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Repositories.Implements
{
    public class ProductRepository : IProductRepository
    {
        private readonly IOMSEFCoreDbContext _dbContext;

        public ProductRepository(IOMSEFCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.Include(c => c.Category).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _dbContext.Products.Include(c => c.Category).FirstOrDefaultAsync(x => x.ProductId == id);
        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
