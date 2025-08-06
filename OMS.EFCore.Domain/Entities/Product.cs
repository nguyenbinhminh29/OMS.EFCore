using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string ForeignName { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        [MaxLength(1)]
        public string Status { get; set; }  // A - Active, I - Inactive, D - Delete


        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
