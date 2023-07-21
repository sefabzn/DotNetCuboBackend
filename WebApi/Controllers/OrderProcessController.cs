using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProcessController : Controller
    {
        IOrderProcessService _orderProcessService;
        public OrderProcessController(IOrderProcessService orderProcessService)
        {
                _orderProcessService = orderProcessService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderProcessService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(OrderProcess orderProcess)
        {

            var result = await _orderProcessService.addAsync(orderProcess);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(OrderProcess orderProcess)
        {
            var result = await _orderProcessService.updateAsync(orderProcess);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(OrderProcess orderProcess)
        {
            var result = await _orderProcessService.deleteAsync(orderProcess);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
