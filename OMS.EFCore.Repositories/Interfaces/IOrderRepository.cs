using OMS.EFCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync(bool headerOnly);
        Task<Order?> GetByIdAsync(int id);
        Task<Order> AddAsync(Order order);
    }
}
