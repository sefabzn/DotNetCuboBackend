using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullanicilarController : ControllerBase
    {
        //Loosely Coupled
        //IoC container Inversion of Control
        IKullaniciService _kullaniciService;

        public KullanicilarController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _kullaniciService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       
        [HttpPost("Add")]
        public IActionResult Add(Kullanici kullanici)
        {

            var result = _kullaniciService.add(kullanici);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _kullaniciService.Get(x => x.ID == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetClaims")]
        public IActionResult GetClaims(int id)
        {
            var kullanici = _kullaniciService.Get(x => x.ID == id).Data;
            var result = _kullaniciService.GetClaims(kullanici);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
