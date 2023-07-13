using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRateController : Controller
    {
        IExchangeRateService _exchangeRateService;
        public ExchangeRateController(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }
        [HttpGet("GetDollarRate")]
        public async Task<IActionResult> GetDollarRate()
        {
            var json = await _exchangeRateService.GetDollarRate();
            if (json != null)
            {
                return Ok(json);
            }


            return BadRequest(json);
        }
        [HttpGet("GetEuroRate")]
        public async Task<IActionResult> GetEuroRate()
        {

            var json = await _exchangeRateService.GetEuroRate();
            if (json != null)
            {
                return Ok(json);
            }
          

            return BadRequest(json);
        }
        [HttpGet("GetCopperRate")]
        public IActionResult GetCopperRate()
        {
            var result = _exchangeRateService.GetCopperRate();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("GetCopperRateByTL")]
        public IActionResult GetCopperRateByTL()
        {
            var result = _exchangeRateService.GetCopperRateByTL();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
