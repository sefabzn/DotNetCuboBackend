using Business.Abstract;
using Entities.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(KullaniciForLoginDto userForLoginDto)
        {
            var userToLogin =await _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result =await _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(KullaniciForRegisterDto userForRegisterDto)
        {
            var userExists =await _authService.CheckIfUserExists(userForRegisterDto.KullaniciAdi);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult =await _authService.Register(userForRegisterDto, userForRegisterDto.Sifre);
            var result =await _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
