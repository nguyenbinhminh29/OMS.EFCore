using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [MaxLength(100)]
        public string? FullName { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        [MaxLength(150)]
        public string? Address { get; set; }

        /// <summary>
        /// A - Active, I - Inactive, D - Delete
        /// </summary>
        [MaxLength(1)]
        public string? Status { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [MaxLength(250)]
        public string? Remark { get; set; }
    }
}
