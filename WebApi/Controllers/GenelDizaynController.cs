using Business.Abstract;
using Entities.Base;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenelDizaynController : Controller
    {

        private IGenelDizaynService _genelDizaynService;

        public GenelDizaynController(IGenelDizaynService genelDizaynService)
        {
            _genelDizaynService = genelDizaynService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _genelDizaynService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAll/{tur}")]
        public async Task<IActionResult> GetAllAsync(string tur)
        {
            var result = await _genelDizaynService.GetAllAsync(x => x.Tur == tur);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllByDate")]
        public async Task<IActionResult> GetAllByDateAsync(DateTime tarih)
        {
            var result = await _genelDizaynService.GetAllAsync(x => x.Tarih == tarih);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(GenelDizaynBase dizayn)
        {
            var result = await _genelDizaynService.addAsync(dizayn);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("AddByList")]
        public async Task<IActionResult> AddByListAsync(List<GenelDizaynBase> dizaynList)
        {

            foreach (var elem in dizaynList)
            {

                var result = await _genelDizaynService.addAsync(elem);
                if (!(result.Success))
                {
                    return BadRequest(result);

                }

            }
            return Ok("Ekleme Tamamlandı");

        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _genelDizaynService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(GenelDizaynBase dizayn)
        {
            var result = await _genelDizaynService.updateAsync(dizayn);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(GenelDizaynBase dizayn)
        {
            var result = await _genelDizaynService.deleteAsync(dizayn);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
