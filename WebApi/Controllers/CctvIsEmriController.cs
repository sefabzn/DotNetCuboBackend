using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Cctv/[controller]")]
    [ApiController]
    public class CctvIsEmriController : Controller
    {
        private ICctvIsEmriService _cctvIsEmriService;

        public CctvIsEmriController(ICctvIsEmriService cctvIsEmriService)
        {
            _cctvIsEmriService = cctvIsEmriService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _cctvIsEmriService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(CctvIsEmri kablo)
        {
            var result = _cctvIsEmriService.delete(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
