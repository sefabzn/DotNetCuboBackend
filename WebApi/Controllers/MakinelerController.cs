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

            var data =_kabloUretimService.GetAllAsync();
            var result = await _makinaService.GetAllAsync();
            var data2 = (await _kabloUretimService.GetAllAsync(x => x.MakineId == 3)).Data;
            foreach (var elem in result.Data)
            {
                int a = 12;
                try
                {
                    var kablo =(await _kabloUretimService.GetAllAsync(x => x.MakineId == elem.Id)).Data;
                    var b = _makinaService.GetOrtalamaVerimlilik((await _kabloUretimService.GetAllAsync(x => x.MakineId == elem.Id)).Data);
                    double verimlilik =b.Data;
                    elem.Verimlilik = verimlilik;
                   await _makinaService.updateAsync(elem);

                }
                catch (Exception)
                {

                    elem.Verimlilik = 0;
                }
            }
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(Makine makina)
        {

            var result =await _makinaService.addAsync(makina);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
        [HttpGet("GetById")]
        public async  Task<IActionResult> GetById(int id)
        {
            var result =await _makinaService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(Makine kablo)
        {
            var result =await  _makinaService.updateAsync(kablo);
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
       
        [HttpGet("GetGunlukRaporlar")]
        public async Task<IActionResult> GetGunlukRaporlar(string makineIsmi,DateTime startDate, DateTime finishDate)
        {
            var result =await  _makinaService.GetGunlukRaporlarAsync(makineIsmi,startDate,finishDate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetOrtalamaVerimlilik")]
        public async Task<IActionResult>GetOrtalamaVerimlilik(int makineId)
        {
            var data =await  _kabloUretimService.GetAllAsync(x => x.MakineId == makineId);
            var result = _makinaService.GetOrtalamaVerimlilik(data.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
