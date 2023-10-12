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
        private IMakineService _makineService;
        public KabloUretimController(IKabloUretimService kabloUretimService, IMakineService makineService)
        {
            _kabloUretimService = kabloUretimService;
            _makineService = makineService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result =await  _kabloUretimService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllByDate")]
        public async Task<IActionResult> GetAllByDate(DateTime tarih)
        {

            var result = await _kabloUretimService.GetAllAsync(x => x.Tarih== tarih);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(KabloUretim kablo)
        {

            var result =await _kabloUretimService.addAsync(kablo);
            await _makineService.SetOrtalamaVerimlilik(kablo.MakineId);

            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPost("AddMany")]
        public async Task<IActionResult> AddMany(List<KabloUretim> kabloUretims)
        {

            var result = await _kabloUretimService.AddManyAsync(kabloUretims);
            foreach (var kablo in kabloUretims)
            {
                await _makineService.SetOrtalamaVerimlilik(kablo.MakineId);

            }

            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(KabloUretim kablo)
        {

            var result =await  _kabloUretimService.deleteAsync(kablo);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(KabloUretim kablo)
        {

            var result =await  _kabloUretimService.updateAsync(kablo);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =await _kabloUretimService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetAllByDateRange")]
        public async Task<IActionResult> GetAllByDateRange(DateTime start, DateTime finish)
        {
        
            var result =await  _kabloUretimService.GetAllAsync(x => x.Tarih>=start && x.Tarih<=finish);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetAllByDateRangeAndMakine")]
        public async Task<IActionResult> GetAllByDateRangeAndMakine(DateTime start, DateTime finish,int makineId)
        {

            var result =await  _kabloUretimService.GetAllAsync(x => (x.Tarih >= start && x.Tarih <= finish)&& x.MakineId==makineId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
