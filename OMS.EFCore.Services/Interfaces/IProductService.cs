using OMS.EFCore.Domain.Entities;
using OMS.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<PaginationResults<Product>> GetAllAsync(int skip, int take);
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(ProductModel product);
        Task<bool> UpdateAsync(int id, ProductModel product);
        Task<bool> DeleteAsync(int id);
    }
}
