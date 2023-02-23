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
        [HttpGet("GetAllByDate")]
        public IActionResult GetAllByDate(DateTime tarih)
        {
            var result = _cctvGenelDizaynService.GetAll(x=>x.Tarih==tarih);
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
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _cctvGenelDizaynService.Get(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public IActionResult Update(CctvGenelDizayn kablo)
        {
            var result = _cctvGenelDizaynService.update(kablo);
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
