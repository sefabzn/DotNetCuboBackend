using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Cctv/[controller]")]
    [ApiController]
    public class CctvGenelDizaynController : Controller
    {
       
        private ICctvGenelDizaynService _cctvGenelDizaynService;

        public CctvGenelDizaynController(ICctvGenelDizaynService cctvGenelDizaynService)
        {
            _cctvGenelDizaynService = cctvGenelDizaynService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _cctvGenelDizaynService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(CctvGenelDizayn kablo)
        {
            var result = _cctvGenelDizaynService.add(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(CctvGenelDizayn kablo)
        {
            var result = _cctvGenelDizaynService.delete(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
