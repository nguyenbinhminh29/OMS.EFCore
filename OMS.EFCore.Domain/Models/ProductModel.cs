﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Domain.Models
{
    public class ProductModel
    {
        public string? Name { get; set; }

        public string? ForeignName { get; set; }

        public decimal? Price { get; set; }

        public int? CategoryId { get; set; }

        public string? Status { get; set; }  // A - Active, I - Inactive, D - Delete

    }
}
