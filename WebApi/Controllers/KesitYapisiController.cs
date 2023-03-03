using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KesitYapisiController : Controller
    {
        IKesitYapisiService _kesitYapisiService;
        public KesitYapisiController(IKesitYapisiService kesitYapisiService)
        {
            _kesitYapisiService = kesitYapisiService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(KesitYapisi entity)
        {

            var result =await _kesitYapisiService.addAsync(entity);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result =await  _kesitYapisiService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(KesitYapisi kablo)
        {
            var result =await _kesitYapisiService.updateAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result =await _kesitYapisiService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(KesitYapisi kablo)
        {
            var result =await _kesitYapisiService.deleteAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
