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
        IKabloUretimService _kabloUretimService;

        public MakinelerController(IMakineService makinaService, IKabloUretimService kabloUretimService)
        {
            _makinaService = makinaService;
            _kabloUretimService = kabloUretimService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {

            var data = _kabloUretimService.GetAllAsync();
            var result = await _makinaService.GetAllAsync();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(Makine makina)
        {

            var result = await _makinaService.addAsync(makina);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _makinaService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(Makine kablo)
        {
            var result = await _makinaService.updateAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(Makine kablo)
        {
            var result = await _makinaService.deleteAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("GetRaporByDateRange")]
        public async Task<IActionResult> GetRaporByDateRangeAsync(int makineId, DateTime startDate, DateTime finishDate)
        {
            var result = await _makinaService.getRaporByDateRangeAsync(makineId, startDate, finishDate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetRaporAnalysis")]
        public async Task<IActionResult> GetRaporAnalysis(int makineId, DateTime startDate, DateTime finishDate)
        {
            var result = await _makinaService.GetRaporAnalysis(makineId, startDate, finishDate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("SetVerimlilikForAll")]
        public async Task<IActionResult> SetVerimlilikForAll()
        {
            var result = await _makinaService.SetOrtalamaVerimlilikForAll();

            return Ok(result);

        }

    }
}
