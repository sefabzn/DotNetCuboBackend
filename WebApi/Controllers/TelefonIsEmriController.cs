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
        public IActionResult GetAll()
        {
            var result = _telefonIsEmriService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(TelefonIsEmri kablo)
        {
            var result = _telefonIsEmriService.delete(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
