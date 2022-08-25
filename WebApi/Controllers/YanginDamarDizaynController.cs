using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Yangin/[controller]")]
    [ApiController]
    public class YanginDamarDizaynController : Controller
    {
        private IYanginDamarDizaynService _yanginDamarDizaynService;

        public YanginDamarDizaynController(IYanginDamarDizaynService yanginDamarDizaynService)
        {
            _yanginDamarDizaynService = yanginDamarDizaynService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _yanginDamarDizaynService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("GetAllByGenelDizaynId")]
        public IActionResult GetAll(int id)
        {
            var result = _yanginDamarDizaynService.GetAll(x => x.AnaId == id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(YanginDamarDizayn kablo)
        {
            var result = _yanginDamarDizaynService.add(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public IActionResult Delete(YanginDamarDizayn kablo)
        {
            var result = _yanginDamarDizaynService.delete(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
