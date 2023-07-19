using Business.Abstract;
using Entities.Concrete;
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
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(MakineKesitHizTablosu entity)
        {

            var result = await _makineKesitHizTablosuService.addAsync(entity);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

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
        [HttpGet("GetAllOrdered")]
        public async Task<IActionResult> GetAllOrderedAsync()
        {
            var result = await _makineKesitHizTablosuService.GetAllByMakineIdAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
