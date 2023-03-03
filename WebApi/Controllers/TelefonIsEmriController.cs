using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Telefon/[controller]")]
    [ApiController]
    public class TelefonIsEmriController : Controller
    {
        private ITelefonIsEmriService _telefonIsEmriService;

        public TelefonIsEmriController(ITelefonIsEmriService telefonIsEmriService)
        {
            _telefonIsEmriService = telefonIsEmriService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result =await _telefonIsEmriService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(TelefonIsEmri kablo)
        {
            var result =await _telefonIsEmriService.deleteAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =await _telefonIsEmriService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(TelefonIsEmri kablo)
        {
            var result =await _telefonIsEmriService.updateAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
