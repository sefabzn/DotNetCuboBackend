using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SarfiyatController : Controller
    {
        ISarfiyatService _sarfiyatService;
        public SarfiyatController(ISarfiyatService sarfiyatService)
        {
            _sarfiyatService = sarfiyatService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result =await  _sarfiyatService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllByDateRange")]
        public async Task<IActionResult> GetAllByDateRange(DateTime startDate, DateTime finishDate)
        {
            var result =await _sarfiyatService.GetAllAsync(x=>x.Tarih>=startDate && x.Tarih<= finishDate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(Sarfiyat kablo)
        {
            var result =await _sarfiyatService.deleteAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(Sarfiyat sarfiyat)
        {
            var result =await  _sarfiyatService.addAsync(sarfiyat);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =await  _sarfiyatService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(Sarfiyat kablo)
        {
            var result =await _sarfiyatService.updateAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
