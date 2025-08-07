﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Domain.Models
{
    public class CustomerModel
    {
        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        /// <summary>
        /// A - Active, I - Inactive, D - Delete
        /// </summary>
        public string? Status { get; set; }

        public string? Remark { get; set; }
    }
}
