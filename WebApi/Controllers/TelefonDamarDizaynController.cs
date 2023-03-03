using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Telefon/[controller]")]
    [ApiController]
    public class TelefonDamarDizaynController : Controller
    {
        private ITelefonDamarDizaynService _telefonDamarDizaynService;

        public TelefonDamarDizaynController(ITelefonDamarDizaynService telefonDamarDizaynService)
        {
            _telefonDamarDizaynService = telefonDamarDizaynService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result =await _telefonDamarDizaynService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("GetAllByGenelDizaynId")]
        public async Task<IActionResult> GetAllByGenelDizaynIdAsync(int id)
        {
            var result =await _telefonDamarDizaynService.GetAllAsync(x => x.AnaId == id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(TelefonDamarDizayn kablo)
        {
            var result = await _telefonDamarDizaynService.addAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result =await _telefonDamarDizaynService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(TelefonDamarDizayn kablo)
        {
            var result = await _telefonDamarDizaynService.updateAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(TelefonDamarDizayn kablo)
        {
            var result = await _telefonDamarDizaynService.deleteAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
