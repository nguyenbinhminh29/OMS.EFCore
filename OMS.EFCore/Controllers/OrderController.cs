using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMS.EFCore.Domain.Models;
using OMS.EFCore.Services.Interfaces;

namespace OMS.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderService.GetAllAsync(true));
        }

        [HttpGet("Filter")]
        public async Task<IActionResult> GetAllFilter(DateTime? fromDate, DateTime? toDate, int customerId)
        {
            return Ok(await _orderService.GetAsync(fromDate, toDate, customerId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            return order == null ? NotFound() : Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderModel order)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (order.Items == null || order.Items.Count == 0)
            {
                return BadRequest("Order line cannot be empty.");
            }

            var sumLineAmnt = order.Items.Sum(l => l.LineAmount);
            if (sumLineAmnt > order.TotalAmount)
            {
                return BadRequest("Total amount is incorrect.");
            }

            var created = await _orderService.AddAsync(order);
            return CreatedAtAction(nameof(Get), new { id = created.OrderId }, created);
        }
    }
}
