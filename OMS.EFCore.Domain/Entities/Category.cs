using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OMS.EFCore.Domain.Entities
{
    public class Category
    {
        public int CateId { get; set; }

        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        /// <summary>
        /// A - Active, I - Inactive, D - Delete
        /// </summary>
        [MaxLength(1)]
        public string? Status { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
