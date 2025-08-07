using OMS.EFCore.Data;
using OMS.EFCore.Domain.Entities;
using OMS.EFCore.Domain.Models;
using OMS.EFCore.Repositories.Interfaces;
using OMS.EFCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Services.Implements
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            this._repository = repository;
        }

        public async Task<Product> CreateAsync(ProductModel product)
        {
            var model = new Product()
            {
                Name = string.IsNullOrEmpty(product.Name) ? string.Empty : product.Name,
                ForeignName = string.IsNullOrEmpty(product.ForeignName) ? string.Empty : product.ForeignName,
                Price = product.Price ?? 0,
                CategoryId = product.CategoryId ?? -1,
                Status = string.IsNullOrEmpty(product.Status) ? string.Empty : product.Status,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };

            return await _repository.AddAsync(model);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            if (model == null) return false;
            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PaginationResults<Product>> GetAllAsync(int skip, int take)
        {
            var products = await _repository.GetAllAsync();
            return new PaginationResults<Product>(
                [.. products.Select(product => new Product()
                {
                    ProductId = product.ProductId
                }).Skip(skip).Take(take)], take, products.Count()
                );
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, ProductModel product)
        {
            var model = await _repository.GetByIdAsync(id);
            if (model == null) return false;

            model.Name = string.IsNullOrEmpty(product.Name) ? model.Name : product.Name;
            model.ForeignName = string.IsNullOrEmpty(product.ForeignName) ? model.ForeignName : product.ForeignName;
            model.Price = product.Price ?? model.Price;
            model.CategoryId = product.CategoryId ?? model.CategoryId;
            model.Status = string.IsNullOrEmpty(product.Status) ? model.Status : product.Status;
            model.ModifiedDate = DateTime.Now;

            await _repository.UpdateAsync(model);
            return true;
        }
    }
}
