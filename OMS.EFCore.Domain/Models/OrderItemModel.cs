using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Domain.Models
{
    public class OrderItemModel
    {
        public int ProductId { get; set; }

        public decimal Quantity { get; set; }

        public string? UOM { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal OpenQty { get; set; }    // using for delivery

        public decimal DiscountPercent { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal LineAmount { get; set; }
    }
}
