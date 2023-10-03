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

        IProcessService _processService { get; }

        public OperatorIsEmriController(IOperatorIsEmriService operatorIsEmriService, IProcessService processService)
        {
            _operatorIsEmriService = operatorIsEmriService;
            _processService = processService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _operatorIsEmriService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("IsPlaniOlustur")]
        public async Task<IActionResult> IsPlaniOlustur(OrtakIsEmri ortakIsEmri)
        {


            return Ok(await _operatorIsEmriService.IsPlaniOlustur(ortakIsEmri));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(OperatorIsEmri kablo)
        {
            var result = await _operatorIsEmriService.deleteAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(OperatorIsEmri isEmri)
        {
            var result = await _operatorIsEmriService.addAsync(isEmri);

            if (result.Success)
            {
                return Ok(result);
            }


            await _processService.UpdateBarcodeAtCreateAsync(isEmri.Id);
            return BadRequest(result);

        }
        [HttpPost("AddAll")]
        public async Task<IActionResult> AddAll(List<OperatorIsEmri> isEmirleri)
        {

            foreach (var isEmri in isEmirleri)
            {
                var addResult = await _operatorIsEmriService.addAsync(isEmri);
                if (!addResult.Success)
                {
                    return BadRequest("İş Emri Eklenemedi");
                }
                var updateResult = await _processService.UpdateBarcodeAtCreateAsync(isEmri.Id);

                if (!updateResult.Success)
                {
                    return BadRequest("İş Emri Barkodu Güncellenemedi");

                }

            }


            return Ok(isEmirleri);

        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _operatorIsEmriService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(OperatorIsEmri kablo)
        {
            var result = await _operatorIsEmriService.updateAsync(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("TeorikSureHesapla")]
        public async Task<IActionResult> TeorikSüreHesapla(OrtakIsEmri ortakIsEmri)
        {

            return Ok(await _operatorIsEmriService.TeorikSüreHesapla(ortakIsEmri));
        }

    }
}
