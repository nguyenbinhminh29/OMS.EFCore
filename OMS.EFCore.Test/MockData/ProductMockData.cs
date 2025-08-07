using OMS.EFCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Test.MockData
{
    public class ProductMockData
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new()
                {
                    ProductId = 1,
                    Name = "Item1",
                    ForeignName = "Sản phẩm 1",
                    CategoryId = 1,
                    Status = "A",
                },
                new()
                {
                    ProductId = 2,
                    Name = "Item2",
                    ForeignName = "Sản phẩm 2",
                    CategoryId = 1,
                    Status = "A",
                },
                new()
                {
                    ProductId = 3,
                    Name = "Item3",
                    ForeignName = "Sản phẩm 2",
                    CategoryId = 2,
                    Status = "A",
                },
            };
        }

        public static List<Category> GetCategories()
        {
            return
            [
                new Category { CateId = 1, Name = "Cate_01", Description = "Phân loại 01", Status = "A", CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                new Category { CateId = 2, Name = "Cate_02", Description = "Phân loại 02", Status = "A", CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                new Category { CateId = 3, Name = "Cate_03", Description = "Phân loại 03", Status = "A", CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
            ];
        }
    }
}
