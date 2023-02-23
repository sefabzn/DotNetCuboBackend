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
        public IActionResult GetAll()
        {
            var result = _telefonDamarDizaynService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("GetAllByGenelDizaynId")]
        public IActionResult GetAll(int id)
        {
            var result = _telefonDamarDizaynService.GetAll(x => x.AnaId == id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(TelefonDamarDizayn kablo)
        {
            var result = _telefonDamarDizaynService.add(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _telefonDamarDizaynService.Get(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public IActionResult Update(TelefonDamarDizayn kablo)
        {
            var result = _telefonDamarDizaynService.update(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public IActionResult Delete(TelefonDamarDizayn kablo)
        {
            var result = _telefonDamarDizaynService.delete(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
