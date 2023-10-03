using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Yangin/[controller]")]
    [ApiController]
    public class YanginDamarDizaynController : Controller
    {
        private IYanginDamarDizaynService _yanginDamarDizaynService;

        public YanginDamarDizaynController(IYanginDamarDizaynService yanginDamarDizaynService)
        {
            _yanginDamarDizaynService = yanginDamarDizaynService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _yanginDamarDizaynService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("GetAllByGenelDizaynId")]
        public async Task<IActionResult> GetAllByGenelDizaynId(int id)
        {
            var result = await _yanginDamarDizaynService.GetAllAsync(x => x.AnaId == id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(YanginDamarDizayn kablo)
        {
            var result = await _yanginDamarDizaynService.addAsync(kablo);
            if (result.Success)
            {
                _yanginDamarDizaynService.UpdateGenelDizaynDamarSayisi(kablo.AnaId);
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("AddAll")]
        public async Task<IActionResult> AddAAlllAsync(List<YanginDamarDizayn> kablolar)
        {

            foreach (var kablo in kablolar)
            {
                var result = await _yanginDamarDizaynService.addAsync(kablo);
                if (!result.Success)
                {
                    return BadRequest(result);

                }
                _yanginDamarDizaynService.UpdateGenelDizaynDamarSayisi(kablo.AnaId);

            }
            return Ok("Damarlar Eklendi");

        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _yanginDamarDizaynService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(YanginDamarDizayn kablo)
        {
            var result = await _yanginDamarDizaynService.updateAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(YanginDamarDizayn kablo)
        {
            var result = await _yanginDamarDizaynService.deleteAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
