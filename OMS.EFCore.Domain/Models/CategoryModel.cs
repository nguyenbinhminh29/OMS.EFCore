using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Domain.Models
{
    public class CategoryModel
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        /// <summary>
        /// A - Active, I - Inactive, D - Delete
        /// </summary>
        public string? Status { get; set; }
    }
}
