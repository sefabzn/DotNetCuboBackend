using Business.Abstract;
using Entities.Base;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DamarDizaynController : Controller
    {

        private IDamarDizaynService _damarDizaynService;

        public DamarDizaynController(IDamarDizaynService DamarDizaynService)
        {
            _damarDizaynService = DamarDizaynService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _damarDizaynService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAllByGenelDizaynId")]
        public async Task<IActionResult> GetAllAsync(int id)
        {
            var result = await _damarDizaynService.GetAllAsync(x => x.GenelDizaynId == id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(DamarDizaynBase kablo)
        {
            var result = await _damarDizaynService.addAsync(kablo);
            if (result.Success)
            {
                _damarDizaynService.UpdateGenelDizaynDamarSayisi(kablo.GenelDizaynId);
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("AddAll")]
        public async Task<IActionResult> AddAllAsync(List<DamarDizaynBase> kablolar)
        {

            foreach (var kablo in kablolar)
            {
                var result = await _damarDizaynService.addAsync(kablo);
                if (!result.Success)
                {
                    return BadRequest(result);

                }
                _damarDizaynService.UpdateGenelDizaynDamarSayisi(kablo.GenelDizaynId);

            }
            return Ok("Damarlar Eklendi");

        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _damarDizaynService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(DamarDizaynBase kablo)
        {
            var result = await _damarDizaynService.updateAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(DamarDizaynBase kablo)
        {
            var result = await _damarDizaynService.deleteAsync(kablo);
            if (result.Success)
            {
                _damarDizaynService.UpdateGenelDizaynDamarSayisi(kablo.GenelDizaynId);
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
