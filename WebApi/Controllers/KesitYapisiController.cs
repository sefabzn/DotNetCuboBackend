﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KesitYapisiController : Controller
    {
        IKesitYapisiService _kesitYapisiService;
        public KesitYapisiController(IKesitYapisiService kesitYapisiService)
        {
            _kesitYapisiService = kesitYapisiService;
        }
        [HttpPost("Add")]
        public IActionResult Add(KesitYapisi entity)
        {

            var result = _kesitYapisiService.add(entity);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _kesitYapisiService.Get(x => x.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("Update")]
        public IActionResult Update(KesitYapisi kablo)
        {
            var result = _kesitYapisiService.update(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result =_kesitYapisiService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(KesitYapisi kablo)
        {
            var result = _kesitYapisiService.delete(kablo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
