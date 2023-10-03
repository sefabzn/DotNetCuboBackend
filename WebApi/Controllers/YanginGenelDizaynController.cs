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
        public async Task<IActionResult> GetAll()
        {
            var result = await _yanginGenelDizaynService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("AddAll")]
        public async Task<IActionResult> AddAll(List<YanginGenelDizayn> kablolar)  //veri testi amacıyla oluşturuldu
        {
            foreach (var kablo in kablolar)
            {
                var result = await _yanginGenelDizaynService.addAsync(kablo);
                if (!result.Success)
                {
                    return BadRequest(result);
                }
            }

            return Ok("Kablolar Eklendi");
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(YanginGenelDizayn kablo)
        {
            var result = await _yanginGenelDizaynService.addAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _yanginGenelDizaynService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(YanginGenelDizayn kablo)
        {

            var result = await _yanginGenelDizaynService.updateAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(YanginGenelDizayn kablo)
        {
            var result = await _yanginGenelDizaynService.deleteAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
