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
        public IActionResult GetDollarRate()
        {
            var result = _exchangeRateService.GetDollarRate();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("GetEuroRate")]
        public IActionResult GetEuroRate()
        {
            var result = _exchangeRateService.GetEuroRate();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
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
