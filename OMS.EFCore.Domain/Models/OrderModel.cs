using OMS.EFCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Domain.Models
{
    public class OrderModel
    {
        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal CollectedAmount { get; set; }

        public decimal PayableAmount { get; set; }

        /// <summary>
        /// O - Open, C - Completed, H - Holding
        /// </summary>
        public string? Status { get; set; }

        public bool IsCancelled { get; set; } = false;

        public string? Remark { get; set; }

        public ICollection<OrderItemModel>? Items { get; set; }
    }
}
