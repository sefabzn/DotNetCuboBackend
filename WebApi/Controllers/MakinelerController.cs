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
        public IActionResult GetAll()
        {

            var data =_kabloUretimService.GetAll();
            var result = _makinaService.GetAll();
            foreach (var elem in result.Data)
            {
                try
                {
                    double verimlilik = _makinaService.GetOrtalamaVerimlilik(_kabloUretimService.GetAll(x=>x.MakineId==elem.Id).Data).Data;
                    elem.Verimlilik = verimlilik;
                    _makinaService.update(elem);

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
        public IActionResult Add(Makine makina)
        {

            var result = _makinaService.add(makina);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
        [HttpPost("Delete")]
        public IActionResult Delete(Makine kablo)
        {
            var result = _makinaService.delete(kablo);
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
        [HttpGet("GetGunlukRaporlar")]
        public IActionResult GetGunlukRaporlar(string makineIsmi,DateTime Tarih)
        {
            var result = _makinaService.GetGunlukRaporlar(makineIsmi,Tarih);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetOrtalamaVerimlilik")]
        public IActionResult GetOrtalamaVerimlilik(int makineId)
        {
            var data = _kabloUretimService.GetAll(x => x.MakineId == makineId);
            var result = _makinaService.GetOrtalamaVerimlilik(data.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
