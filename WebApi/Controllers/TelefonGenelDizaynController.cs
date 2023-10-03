using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Telefon/[controller]")]
    [ApiController]
    public class TelefonGenelDizaynController : Controller
    {
        private ITelefonGenelDizaynService _telefonGenelDizaynService;

        public TelefonGenelDizaynController(ITelefonGenelDizaynService telefonGenelDizaynService)
        {
            _telefonGenelDizaynService = telefonGenelDizaynService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _telefonGenelDizaynService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(TelefonGenelDizayn kablo)
        {
            var result = await _telefonGenelDizaynService.addAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("AddAll")]
        public async Task<IActionResult> AddAll(List<TelefonGenelDizayn> kablolar)  //veri testi amacıyla oluşturuldu
        {
            foreach (var kablo in kablolar)
            {
                var result = await _telefonGenelDizaynService.addAsync(kablo);
                if (!result.Success)
                {
                    return BadRequest(result);
                }
            }

            return Ok("Kablolar Eklendi");
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(TelefonGenelDizayn kablo)
        {
            var result = await _telefonGenelDizaynService.updateAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _telefonGenelDizaynService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(TelefonGenelDizayn kablo)
        {
            var result = await _telefonGenelDizaynService.deleteAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
