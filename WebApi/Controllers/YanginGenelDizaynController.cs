using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Yangin/[controller]")]
    [ApiController]
    public class YanginGenelDizaynController : Controller
    {
        private IYanginGenelDizaynService _yanginGenelDizaynService;

        public YanginGenelDizaynController(IYanginGenelDizaynService yanginGenelDizaynService)
        {
            _yanginGenelDizaynService = yanginGenelDizaynService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _yanginGenelDizaynService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(YanginGenelDizayn kablo)
        {
            var result = _yanginGenelDizaynService.add(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(YanginGenelDizayn kablo)
        {
            var result = _yanginGenelDizaynService.delete(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
