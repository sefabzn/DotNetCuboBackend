using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorIsEmriController : Controller
    {
        IOperatorIsEmriService _operatorIsEmriService;
        public OperatorIsEmriController(IOperatorIsEmriService operatorIsEmriService)
        {
            _operatorIsEmriService = operatorIsEmriService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
           var result= _operatorIsEmriService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(OperatorIsEmri kablo)
        {
            var result = _operatorIsEmriService.delete(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
