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
        public IActionResult GetAll()
        {
            var result = _sarfiyatService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllByDateRange")]
        public IActionResult GetAllByDateRange(DateTime startDate, DateTime finishDate)
        {
            var result = _sarfiyatService.GetAll(x=>x.Tarih>=startDate && x.Tarih<= finishDate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(Sarfiyat kablo)
        {
            var result = _sarfiyatService.delete(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Add")]
        public IActionResult Add(Sarfiyat sarfiyat)
        {
            var result = _sarfiyatService.add(sarfiyat);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
