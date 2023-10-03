using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Cctv/[controller]")]
    [ApiController]
    public class CctvDamarDizaynController : Controller
    {

        private ICctvDamarDizaynService _cctvDamarDizaynService;

        public CctvDamarDizaynController(ICctvDamarDizaynService cctvDamarDizaynService)
        {
            _cctvDamarDizaynService = cctvDamarDizaynService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _cctvDamarDizaynService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("GetAllByGenelDizaynId")]
        public async Task<IActionResult> GetAllAsync(int id)
        {
            var result = await _cctvDamarDizaynService.GetAllAsync(x => x.AnaId == id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(CctvDamarDizayn kablo)
        {
            var result = await _cctvDamarDizaynService.addAsync(kablo);
            if (result.Success)
            {
                _cctvDamarDizaynService.UpdateGenelDizaynDamarSayisi(kablo.AnaId);
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("AddAll")]
        public async Task<IActionResult> AddAAlllAsync(List<CctvDamarDizayn> kablolar)
        {

            foreach (var kablo in kablolar)
            {
                var result = await _cctvDamarDizaynService.addAsync(kablo);
                if (!result.Success)
                {
                    return BadRequest(result);

                }
                _cctvDamarDizaynService.UpdateGenelDizaynDamarSayisi(kablo.AnaId);

            }
            return Ok("Damarlar Eklendi");

        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _cctvDamarDizaynService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(CctvDamarDizayn kablo)
        {
            var result = await _cctvDamarDizaynService.updateAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(CctvDamarDizayn kablo)
        {
            var result = await _cctvDamarDizaynService.deleteAsync(kablo);
            if (result.Success)
            {
                _cctvDamarDizaynService.UpdateGenelDizaynDamarSayisi(kablo.AnaId);
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
