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
        public IActionResult GetAll()
        {
            var result = _telefonGenelDizaynService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(TelefonGenelDizayn kablo)
        {
            var result = _telefonGenelDizaynService.add(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("Update")]
        public IActionResult Update(TelefonGenelDizayn kablo)
        {
            var result = _telefonGenelDizaynService.update(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _telefonGenelDizaynService.Get(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public IActionResult Delete(TelefonGenelDizayn kablo)
        {
            var result = _telefonGenelDizaynService.delete(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
