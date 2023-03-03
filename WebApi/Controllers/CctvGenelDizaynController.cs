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
        public async Task<IActionResult> GetAllAsync()
        {
            var result =await  _cctvGenelDizaynService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllByDate")]
        public async Task<IActionResult> GetAllByDateAsync(DateTime tarih)
        {
            var result = await _cctvGenelDizaynService.GetAllAsync(x=>x.Tarih==tarih);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
      
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(CctvGenelDizayn kablo)
        {
            var result =await _cctvGenelDizaynService.addAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _cctvGenelDizaynService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(CctvGenelDizayn kablo)
        {
            var result =await _cctvGenelDizaynService.updateAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(CctvGenelDizayn kablo)
        {
            var result = await _cctvGenelDizaynService.deleteAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
