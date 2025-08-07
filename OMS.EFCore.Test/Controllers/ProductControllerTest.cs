using Microsoft.AspNetCore.Mvc;
using Moq;
using OMS.EFCore.Controllers;
using OMS.EFCore.Services.Interfaces;
using OMS.EFCore.Test.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using OMS.EFCore.Repositories.Interfaces;
using OMS.EFCore.Services.Implements;

namespace OMS.EFCore.Test.Controllers
{
    public class ProductControllerTest
    {
        [Fact]
        public async Task ProductController_GetProductAll_ReturnOkStatus()
        {
            // Arrange

            Mock<IProductRepository> productRepository = new();
            productRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(ProductMockData.GetProducts());

            Mock<ICategoryRepository> categoryRepository = new();
            categoryRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(ProductMockData.GetCategories());

            IProductService productService = new ProductService(productRepository.Object);
            ICategoryService categoryService = new CategoryService (categoryRepository.Object);

            ProductController productController = new(productService, categoryService);

            // Action
            var result = (OkObjectResult)await productController.GetAll();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task ProductController_GetProductById_ReturnNotFoundStatus()
        {
            // Arrange

            Mock<IProductRepository> productRepository = new();
            productRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(ProductMockData.GetProducts());

            Mock<ICategoryRepository> categoryRepository = new();
            categoryRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(ProductMockData.GetCategories());

            IProductService productService = new ProductService(productRepository.Object);
            ICategoryService categoryService = new CategoryService(categoryRepository.Object);

            ProductController productController = new(productService, categoryService);

            // Action
            var result = (NotFoundResult)await productController.Get(9);

            // Assert
            result.StatusCode.Should().Be(404);
        }
    }
}
