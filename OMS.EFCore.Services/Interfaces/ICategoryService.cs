using OMS.EFCore.Domain.Entities;
using OMS.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<PaginationResults<Category>> GetAllAsync(int skip, int take);
        Task<Category?> GetByIdAsync(int id);
        Task<Category> CreateAsync(CategoryModel category);
        Task<bool> UpdateAsync(int id, CategoryModel category);
        Task<bool> DeleteAsync(int id);
    }
}
