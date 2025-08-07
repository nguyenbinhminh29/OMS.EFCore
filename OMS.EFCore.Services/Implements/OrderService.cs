using Microsoft.EntityFrameworkCore;
using OMS.EFCore.Domain.Entities;
using OMS.EFCore.Domain.Models;
using OMS.EFCore.Repositories.Interfaces;
using OMS.EFCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Services.Implements
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            this._repository = repository;
        }

        public async Task<Order> AddAsync(OrderModel order)
        {
            var model = new Order()
            {
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                DiscountAmount = order.DiscountAmount,
                CollectedAmount = order.CollectedAmount,
                PayableAmount = order.PayableAmount,
                IsCancelled = order.IsCancelled,
                Status = string.IsNullOrEmpty(order.Status) ? string.Empty : order.Status,
                Remark = order.Remark,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Items = order.Items.Select((i, index) => new OrderItem()
                {
                    OrderItemId = index + 1,
                    ProductId = i.ProductId,
                    DiscountAmount = i.DiscountAmount,
                    DiscountPercent = i.DiscountPercent,
                    LineAmount = i.LineAmount,
                    OpenQty = i.OpenQty,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    UOM = i.UOM
                }).ToList(),
            };

            return await _repository.AddAsync(model);
        }

        public async Task<IEnumerable<Order>> GetAllAsync(bool headerOnly)
        {
            return await _repository.GetAllAsync(headerOnly);
        }

        public async Task<IEnumerable<Order>> GetAsync(DateTime? fromDate, DateTime? toDate, int? customerId)
        {
            var orders = await _repository.GetAllAsync(true);
            if (orders.Any())
            {
                if (fromDate.HasValue)
                {
                    orders = orders.Where(o => o.OrderDate.Date >= fromDate.Value.Date).ToList();
                }
                if (toDate.HasValue)
                {
                    orders = orders.Where(o => o.OrderDate.Date <= toDate.Value.Date).ToList();
                }
                if (customerId.HasValue && customerId.Value != 0)
                {
                    orders = orders.Where(o => o.CustomerId == customerId).ToList();
                }

                return orders;
            }
            else return null;
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
