using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KesitYapisiController : Controller
    {
        IKesitYapisiService _kesitYapisiService;
        public KesitYapisiController(IKesitYapisiService kesitYapisiService)
        {
            _kesitYapisiService = kesitYapisiService;
        }
        [HttpPost("Add")]
        public IActionResult Add(KesitYapisi entity)
        {

            var result = _kesitYapisiService.add(entity);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result =_kesitYapisiService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
