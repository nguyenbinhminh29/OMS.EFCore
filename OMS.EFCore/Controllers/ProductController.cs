using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMS.EFCore.Domain.Entities;
using OMS.EFCore.Domain.Models;
using OMS.EFCore.Services.Interfaces;

namespace OMS.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this._productService = productService;
            this._categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAllAsync());
        }

        [HttpGet("Paged")]
        public async Task<IActionResult> GetAll(int? skip, int? take)
        {
            if (skip.HasValue && take.HasValue)
            {
                return Ok(await _productService.GetAllAsync(skip.Value, take.Value));
            }
            return Ok(await _productService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductModel product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!string.IsNullOrEmpty(product.Status) && (product.Status != "A" && product.Status != "I" && product.Status != "D"))
            {
                return BadRequest("Status must be one of the 3 values A, I, D");
            }
            if (product.CategoryId == null)
            {
                return BadRequest("Please select category for product.");
            }
            Category? cate = await _categoryService.GetByIdAsync(product.CategoryId.Value);
            if (cate == null)
            {
                return BadRequest("Category id not found.");
            }

            var created = await _productService.CreateAsync(product);
            return CreatedAtAction(nameof(Get), new { id = created.ProductId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductModel product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _productService.UpdateAsync(id, product);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
