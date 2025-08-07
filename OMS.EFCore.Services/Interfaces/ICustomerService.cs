using OMS.EFCore.Domain.Entities;
using OMS.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<PaginationResults<Customer>> GetAllAsync(int skip, int take);
        Task<Customer?> GetByIdAsync(int id);
        Task<Customer> CreateAsync(CustomerModel customer);
        Task<bool> UpdateAsync(int id, CustomerModel customer);
        Task<bool> DeleteAsync(int id);
    }
}
