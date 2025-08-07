using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMS.EFCore.Domain.Models;
using OMS.EFCore.Services.Interfaces;
using OMS.EFCore.Helper;

namespace OMS.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _customerService.GetByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerModel customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!string.IsNullOrEmpty(customer.Status) && (customer.Status != "A" && customer.Status != "I" && customer.Status != "D"))
            {
                return BadRequest("Status must be one of the 3 values A, I, D.");
            }

            if (!string.IsNullOrEmpty(customer.Email) && !customer.Email.IsValidEmail())
            {
                return BadRequest("Email is not in correct format.");
            }

            if (!string.IsNullOrEmpty(customer.PhoneNumber) && !customer.PhoneNumber.IsValidPhoneNumber())
            {
                return BadRequest("PhoneNumber is not in correct format.");
            }

            var created = await _customerService.CreateAsync(customer);
            return CreatedAtAction(nameof(Get), new { id = created.CustomerId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerModel customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!string.IsNullOrEmpty(customer.Email) && !customer.Email.IsValidEmail())
            {
                return BadRequest("Email is not in correct format.");
            }

            if (!string.IsNullOrEmpty(customer.PhoneNumber) && !customer.PhoneNumber.IsValidPhoneNumber())
            {
                return BadRequest("PhoneNumber is not in correct format.");
            }

            var result = await _customerService.UpdateAsync(id, customer);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _customerService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
