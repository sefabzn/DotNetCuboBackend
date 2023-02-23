 using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Cctv/[controller]")]
    [ApiController]
    public class CctvDamarDizaynController : Controller
    {

        private ICctvDamarDizaynService _cctvDamarDizaynService;

        public CctvDamarDizaynController(ICctvDamarDizaynService cctvDamarDizaynService)
        {
            _cctvDamarDizaynService = cctvDamarDizaynService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _cctvDamarDizaynService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("GetAllByGenelDizaynId")]
        public IActionResult GetAll(int id)
        {
            var result = _cctvDamarDizaynService.GetAll(x=>x.AnaId==id);
            if (result.Success)
            {
                return Ok(result);
            }
    
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(CctvDamarDizayn kablo)
        {
            var result = _cctvDamarDizaynService.add(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _cctvDamarDizaynService.Get(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public IActionResult Update(CctvDamarDizayn kablo)
        {
            var result = _cctvDamarDizaynService.update(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public IActionResult Delete(CctvDamarDizayn kablo)
        {
            var result = _cctvDamarDizaynService.delete(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
