using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRateController : Controller
    {
        private readonly IExchangeRateService _exchangeRateService;

        public ExchangeRateController(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        [HttpGet("GetDollarRate")]
        public async Task<IActionResult> GetDollarRate()
        {
            var result = await _exchangeRateService.GetDollarRate();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetEuroRate")]
        public async Task<IActionResult> GetEuroRate()
        {
            var result = await _exchangeRateService.GetEuroRate();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetCopperRate")]
        public IActionResult GetCopperRate()
        {
            var result = _exchangeRateService.GetCopperRate();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetCopperRateByTL")]
        public IActionResult GetCopperRateByTL()
        {
            var result = _exchangeRateService.GetCopperRateByTL();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
