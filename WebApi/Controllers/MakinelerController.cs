using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakinelerController : Controller
    {
        IMakineService _makinaService;

        public MakinelerController(IMakineService makinaService)
        {
            _makinaService = makinaService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _makinaService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(Makine makina)
        {

            var result = _makinaService.add(makina);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _makinaService.Get(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
