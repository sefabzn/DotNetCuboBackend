using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : Controller
    {
        IProcessService _processService;
        public ProcessController(IProcessService processService)
        {
            _processService = processService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _processService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(Process process)
        {

            var result = await _processService.addAsync(process);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(Process process)
        {
            var result = await _processService.updateAsync(process);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(Process process)
        {
            var result = await _processService.deleteAsync(process);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
