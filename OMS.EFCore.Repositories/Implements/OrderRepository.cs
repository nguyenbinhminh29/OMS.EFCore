using Microsoft.EntityFrameworkCore;
using OMS.EFCore.Data;
using OMS.EFCore.Domain.Entities;
using OMS.EFCore.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Repositories.Implements
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IOMSEFCoreDbContext _dbContext;

        public OrderRepository(IOMSEFCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> AddAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllAsync(bool headerOnly)
        {
            if (headerOnly)
            {
                return await _dbContext.Orders.ToListAsync();
            }
            return await _dbContext.Orders.Include(o => o.Items).ToListAsync();
        }

        public Task<IEnumerable<Order>> GetAllHeaderAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _dbContext.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.OrderId == id);
        }
    }
}
