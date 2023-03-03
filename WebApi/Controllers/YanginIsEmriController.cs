using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Yangin/[controller]")]
    [ApiController]
    public class YanginIsEmriController : Controller
    {
        private IYanginIsEmriService _yanginIsEmriService;

        public YanginIsEmriController(IYanginIsEmriService yanginIsEmriService)
        {
            _yanginIsEmriService = yanginIsEmriService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result =await _yanginIsEmriService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(YanginIsEmri kablo)
        {

            var result =await _yanginIsEmriService.updateAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =await _yanginIsEmriService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(YanginIsEmri kablo)
        {
            var result =await _yanginIsEmriService.deleteAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
