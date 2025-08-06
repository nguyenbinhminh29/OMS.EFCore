using Microsoft.EntityFrameworkCore;
using OMS.EFCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Data
{
    public class OMSEFCoreDbContext : DbContext, IOMSEFCoreDbContext
    {
        public OMSEFCoreDbContext(DbContextOptions<OMSEFCoreDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
