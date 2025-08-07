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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            this._repository = repository;
        }

        public async Task<Customer> CreateAsync(CustomerModel customer)
        {
            var model = new Customer()
            {
                FullName = string.IsNullOrEmpty(customer.FullName) ? string.Empty : customer.FullName,
                Email = string.IsNullOrEmpty(customer.Email) ? string.Empty : customer.Email,
                PhoneNumber = string.IsNullOrEmpty(customer.PhoneNumber) ? string.Empty : customer.PhoneNumber,
                Address = string.IsNullOrEmpty(customer.Address) ? string.Empty : customer.Address,
                Remark = string.IsNullOrEmpty(customer.Remark) ? string.Empty : customer.Remark,
                Status = string.IsNullOrEmpty(customer.Status) ? string.Empty : customer.Status,
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

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PaginationResults<Customer>> GetAllAsync(int skip, int take)
        {
            var customers = await _repository.GetAllAsync();
            return new PaginationResults<Customer>(
                [.. customers.Select(customer => new Customer()
                {
                    CustomerId = customer.CustomerId
                }).Skip(skip).Take(take)], take, customers.Count()
                );
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, CustomerModel customer)
        {
            var model = await _repository.GetByIdAsync(id);
            if (model == null) return false;

            model.FullName = string.IsNullOrEmpty(customer.FullName) ? model.FullName : customer.FullName;
            model.Email = string.IsNullOrEmpty(customer.Email) ? model.Email : customer.Email;
            model.PhoneNumber = string.IsNullOrEmpty(customer.PhoneNumber) ? model.PhoneNumber : customer.PhoneNumber;
            model.Address = string.IsNullOrEmpty(customer.Address) ? model.Address : customer.Address;
            model.Remark = string.IsNullOrEmpty(customer.Remark) ? model.Remark : customer.Remark;
            model.Status = string.IsNullOrEmpty(customer.Status) ? model.Status : customer.Status;
            model.ModifiedDate = DateTime.Now;

            await _repository.UpdateAsync(model);
            return true;
        }
    }
}
