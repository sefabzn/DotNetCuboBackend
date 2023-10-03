using AutoMapper;
using Business.Abstract;
using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Concrete;
using Entities.DTO_s;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly CuboContext _context;
        private readonly IAuthService _authService;

        public AuthController(CuboContext context, ITokenService tokenService, UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IAuthService authService)
        {
            _context = context;
            _tokenService = tokenService;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _authService = authService;
        }


        [HttpPost("Register")]
        public async Task<ActionResult> RegisterAsync(RegisterDto registerUser)
        {
            var result = await _authService.RegisterAsync(registerUser);

            return Ok(result);

        }


        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto loginUser)
        {

            var result = await _authService.LoginAsync(loginUser);

            return Ok(result);

        }

        [HttpPost("AddRole")]
        public async Task<ActionResult> AddRole(string roleName)
        {
            var role = new Role
            {
                Name = roleName
            };

            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                return BadRequest("Rol Eklenemedi");

            }

            return Ok("Rol Eklendi");

        }
        [Authorize(Roles = "Admin")]
        [HttpPost("authexperiment")]
        public ActionResult authexperiment()
        {

            return Ok("yetkilendirme başarılı");

        }


    }
}