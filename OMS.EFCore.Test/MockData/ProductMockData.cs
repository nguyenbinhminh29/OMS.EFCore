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
                new Product()
                {
                    ProductId = 1,
                    Name = "Item1",
                    ForeignName = "Sản phẩm 1",
                    CategoryId = 1,
                    Status = "A",
                },
                new Product()
                {
                    ProductId = 2,
                    Name = "Item2",
                    ForeignName = "Sản phẩm 2",
                    CategoryId = 1,
                    Status = "A",
                },
                new Product()
                {
                    ProductId = 3,
                    Name = "Item3",
                    ForeignName = "Sản phẩm 2",
                    CategoryId = 2,
                    Status = "A",
                },
            };
        }
    }
}
