using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProcessController : Controller
    {
        IProcessService _processService;
        IOperatorIsEmriService _operatorIsEmriService;

        public ProcessController(IProcessService processService, IOperatorIsEmriService operatorIsEmri)
        {
            _processService = processService;
            _operatorIsEmriService = operatorIsEmri;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _processService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllByIsEmriId")]
        public async Task<IActionResult> GetAllByIsEmriId(int id)
        {
            var result = await _processService.GetAllAsync(x => x.IsEmriId == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _processService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(Process processDto)
        {

            var isEmriResult = await _operatorIsEmriService.GetAsync(x => x.Id == processDto.IsEmriId);


            var process = new Process
            {
                OperatorIsEmri = isEmriResult.Data,
                Aciklama = processDto.Aciklama,
                IsEmriId = processDto.IsEmriId,
                Isim = processDto.Isim,
                Order = processDto.Order,
                TamamlanmaDurumu = processDto.TamamlanmaDurumu,

            };

            var result = _processService.addAsync(process);
            await UpdateBarcode(process.IsEmriId, process);

            return Ok(result.Result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(Process process)
        {

            var result = await _processService.updateAsync(process);
            await UpdateBarcode(process.IsEmriId, process);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("SetAsCompleted")]
        public async Task<IActionResult> UpdateBarcode(int isEmriId, Process process)
        {



            var result = await _processService.UpdateBarcodeAsync(isEmriId, process);

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest();

        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(Process process)
        {
            var result = await _processService.deleteAsync(process);
            if (result.Success)
            {

                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
