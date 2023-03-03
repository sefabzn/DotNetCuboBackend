using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullanicilarController : Controller
    {
        //Loosely Coupled
        //IoC container Inversion of Control
        IKullaniciService _kullaniciService;

        public KullanicilarController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _kullaniciService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(Kullanici kullanici)
        {

            var result = await _kullaniciService.addAsync(kullanici);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
        [HttpGet("GetById")]
        public async  Task<IActionResult> GetById(int id)
        {
            var result = await _kullaniciService.GetAsync(x => x.ID == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string kullaniciAdi)
        {
            var result = await _kullaniciService.GetByKullaniciAdiAsync(kullaniciAdi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(Kullanici kablo)
        {
            var result =await  _kullaniciService.updateAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(Kullanici kablo)
        {
            var result =await _kullaniciService.deleteAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetClaims")]
        public  async Task<IActionResult>GetClaims(int id)
        {
            var kullanici =(await _kullaniciService.GetAsync(x => x.ID == id)).Data;
            var result =await  _kullaniciService.GetClaimsAsync(kullanici);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
