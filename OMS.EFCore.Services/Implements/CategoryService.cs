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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            this._repository = repository;
        }
        public async Task<Category> CreateAsync(CategoryModel category)
        {
            var model = new Category()
            {
                Name = string.IsNullOrEmpty(category.Name) ? string.Empty : category.Name,
                Description = string.IsNullOrEmpty(category.Description) ? string.Empty : category.Description,
                Status = string.IsNullOrEmpty(category.Status) ? string.Empty : category.Status,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };

            return await _repository.AddAsync(model);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool result = false;
            try
            {
                var model = await _repository.GetByIdAsync(id);
                if (model == null) return false;
                await _repository.DeleteAsync(id);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PaginationResults<Category>> GetAllAsync(int skip, int take)
        {
            var categories = await _repository.GetAllAsync();
            return new PaginationResults<Category>(
                categories.Select(product => new Category()
                {
                    CateId = product.CateId
                }).Skip(skip).Take(take).ToList(), take, categories.Count()
                );
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, CategoryModel category)
        {
            var model = await _repository.GetByIdAsync(id);
            if (model == null) return false;

            model.Name = string.IsNullOrEmpty(category.Name) ? model.Name : category.Name;
            model.Description = string.IsNullOrEmpty(category.Description) ? model.Description : category.Description;
            model.Status = string.IsNullOrEmpty(category.Status) ? model.Status : category.Status;
            model.ModifiedDate = DateTime.Now;

            await _repository.UpdateAsync(model);
            return true;
        }
    }
}
