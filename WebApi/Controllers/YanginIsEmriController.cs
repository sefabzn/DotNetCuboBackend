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
        public IActionResult GetAll()
        {
            var result = _yanginIsEmriService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(YanginIsEmri kablo)
        {
            var result = _yanginIsEmriService.delete(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
