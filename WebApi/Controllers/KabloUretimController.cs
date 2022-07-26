using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KabloUretimController : Controller
    {
        private IKabloUretimService _kabloUretimService;
        public KabloUretimController(IKabloUretimService kabloUretimService)
        {
            _kabloUretimService = kabloUretimService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _kabloUretimService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllByDate")]
        public IActionResult GetAllByDate(DateTime tarih)
        {

            var result = _kabloUretimService.GetAll(x => x.Tarih== tarih);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(KabloUretim kablo)
        {

            var result = _kabloUretimService.add(kablo);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id,DateTime tarih)
        {
            var result = _kabloUretimService.Get(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
