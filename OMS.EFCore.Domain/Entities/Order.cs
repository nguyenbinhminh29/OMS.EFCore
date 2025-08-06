using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal CollectedAmount { get; set; }

        public decimal PayableAmount { get; set; }

        [MaxLength(1)]
        public string Status { get; set; } // O - Open, C - Completed, H - Holding

        public bool IsCancelled { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [MaxLength(250)]
        public string Remark { get; set; }
    }
}
