using OMS.EFCore.Domain.Entities;
using OMS.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsync(bool headerOnly);
        Task<IEnumerable<Order>> GetAsync(DateTime? fromDate, DateTime? toDate, int? customerId);
        Task<Order?> GetByIdAsync(int id);
        Task<Order> AddAsync(OrderModel order);
    }
}
