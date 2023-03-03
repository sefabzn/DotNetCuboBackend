using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Cctv/[controller]")]
    [ApiController]
    public class CctvIsEmriController : Controller
    {
        private ICctvIsEmriService _cctvIsEmriService;

        public CctvIsEmriController(ICctvIsEmriService cctvIsEmriService)
        {
            _cctvIsEmriService = cctvIsEmriService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result =await _cctvIsEmriService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _cctvIsEmriService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(CctvIsEmri kablo)
        {
            var result = await _cctvIsEmriService.updateAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(CctvIsEmri kablo)
        {
            var result = await _cctvIsEmriService.addAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(CctvIsEmri kablo)
        {
            var result = await _cctvIsEmriService.deleteAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
