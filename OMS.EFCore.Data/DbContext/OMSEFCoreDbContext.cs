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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<Category>(c =>
            {
                c.Property(x => x.Name).IsRequired();
                c.HasKey(x => x.CateId);
                c.HasData(
                    new Category { CateId = 1, Name = "Cate_01", Description = "Phân loại 01", Status = "A", CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Category { CateId = 2, Name = "Cate_02", Description = "Phân loại 02", Status = "A", CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Category { CateId = 3, Name = "Cate_03", Description = "Phân loại 03", Status = "A", CreateDate = DateTime.Now, ModifiedDate = DateTime.Now }
                    );
            });

            modelBuilder.Entity<Product>().HasOne(s => s.Category).WithMany(s => s.Products).HasForeignKey(s => s.CategoryId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>().HasKey(p => p.CustomerId);
            modelBuilder.Entity<Order>().HasKey(p => p.OrderId);
            modelBuilder.Entity<OrderItem>().HasKey(p => new { p.OrderItemId, p.OrderId, p.ProductId });


            base.OnModelCreating(modelBuilder);
        }
    }
}
