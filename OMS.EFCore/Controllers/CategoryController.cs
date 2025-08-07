using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMS.EFCore.Domain.Models;
using OMS.EFCore.Services.Interfaces;

namespace OMS.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        [HttpGet("Paged")]
        public async Task<IActionResult> GetAll(int? skip, int? take)
        {
            if (skip.HasValue && take.HasValue)
            {
                return Ok(await _categoryService.GetAllAsync(skip.Value, take.Value));
            }
            return Ok(await _categoryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _categoryService.GetByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryModel category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!string.IsNullOrEmpty(category.Status) && (category.Status != "A" && category.Status != "I" && category.Status != "D"))
            {
                return BadRequest("Status must be one of the 3 values A, I, D");
            }
            var created = await _categoryService.CreateAsync(category);
            return CreatedAtAction(nameof(Get), new { id = created.CateId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryModel category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _categoryService.UpdateAsync(id, category);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
