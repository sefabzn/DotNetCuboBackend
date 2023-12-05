using Business.Abstract;
using Entities.Base;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IsEmriController : Controller
    {
        private readonly IIsEmriService _isEmriService;
        private readonly IProcessService _processService;
        public IsEmriController(IIsEmriService isEmriService, IProcessService processService)
        {
            _isEmriService = isEmriService;
            _processService = processService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _isEmriService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllIsEmriTakip")]
        public async Task<IActionResult> GetAllIsEmriTakipAsync()
        {
            var result = await _isEmriService.GetAllIsEmriTakipDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(IsEmriBase isEmri)
        {
            var result = await _isEmriService.deleteAsync(isEmri);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(IsEmriBase isEmri, int genelDizaynId, int damarDizaynId)
        {
            var result = await _isEmriService.addAsync(isEmri);
            var genelDizaynResult = await _isEmriService.AddToGenelDizayn(isEmri, genelDizaynId);
            var damarDizaynResult = await _isEmriService.AddToDamarDizayn(isEmri, damarDizaynId);

            if (result.Success && genelDizaynResult.Success && damarDizaynResult.Success)
            {
                return Ok(result);
            }


            await _processService.UpdateBarcodeAsync(Convert.ToInt32(isEmri.Id));
            return BadRequest(result);

        }

        [HttpPost("AddToGenelDizayn")]
        public async Task<IActionResult> AddToGenelDizayn(IsEmriBase isEmriBase, int genelDizaynId, int damarDizaynId)
        {
            var result = await _isEmriService.AddToGenelDizayn(isEmriBase, genelDizaynId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest("İş emri genel dizaynla ilişkilendirilemedi");
        }
        [HttpPost("AddToDamarDizayn")]
        public async Task<IActionResult> AddToDamarDizayn(IsEmriBase isEmriBase, int genelDizaynId, int damarDizaynId)
        {
            var result = await _isEmriService.AddToGenelDizayn(isEmriBase, damarDizaynId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest("İş emri damar dizaynla ilişkilendirilemedi");
        }
        [HttpPost("AddWithControl")]
        public async Task<IActionResult> AddWithControlAsync(IsEmriBase isEmri, int genelDizaynId, int damarDizaynId)
        {
            var result = await _isEmriService.AddWithControl(isEmri);
            var genelDizaynResult = await _isEmriService.AddToGenelDizayn(isEmri, genelDizaynId);
            var damarDizaynResult = await _isEmriService.AddToDamarDizayn(isEmri, damarDizaynId);

            if (result.Success && genelDizaynResult.Success && damarDizaynResult.Success)
            {
                return Ok(result);
            }


            await _processService.UpdateBarcodeAsync(Convert.ToInt32(isEmri.Id));
            return BadRequest(result);

        }
        [HttpPost("AddAll")]
        public async Task<IActionResult> AddAll(List<IsEmriBase> isEmirleri)
        {

            foreach (var isEmri in isEmirleri)
            {
                var addResult = await _isEmriService.addAsync(isEmri);
                if (!addResult.Success)
                {
                    return BadRequest("İş Emri Eklenemedi");
                }
                var updateResult = await _processService.UpdateBarcodeAsync(Convert.ToInt32(isEmri.Id));

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
            var result = await _isEmriService.GetAsync(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(IsEmriBase isEmri)
        {
            var result = await _isEmriService.updateAsync(isEmri);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }




    }
}
