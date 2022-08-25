using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakineKesitHizTablosuController : Controller
    {
        IMakineKesitHizTablosuService _makineKesitHizTablosuService;
        public MakineKesitHizTablosuController(IMakineKesitHizTablosuService makineKesitHizTablosuService)
        {
            _makineKesitHizTablosuService = makineKesitHizTablosuService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _makineKesitHizTablosuService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
