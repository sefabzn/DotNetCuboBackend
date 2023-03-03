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
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _makineKesitHizTablosuService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
