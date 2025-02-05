using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Concrete;
using Entities.DTO_s;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly CuboContext _context;

        public AuthManager(CuboContext context, ITokenService tokenService, UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper)
        {
            _context = context;
            _tokenService = tokenService;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IDataResult<UserDTO>> LoginAsync(LoginDto loginUser)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Email == loginUser.Email);

            if (user == null) return new ErrorDataResult<UserDTO>("Invalid email");
            var result = await _userManager.CheckPasswordAsync(user, loginUser.Password);

            if (!result) return new ErrorDataResult<UserDTO>("Invalid Password");

            return new SuccessDataResult<UserDTO>(new UserDTO
            {
                Email = user.Email,
                Token = await _tokenService.CreateToken(user)
            });
        }

        public async Task<IDataResult<UserDTO>> RegisterAsync(RegisterDto registerUser)
        {
            var user = _mapper.Map<User>(registerUser);

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return new ErrorDataResult<UserDTO>($"Could not create the user: {errors}");
            }

            var roleResult = await _userManager.AddToRoleAsync(user, "Member");

            if (!roleResult.Succeeded)
            {
                return new ErrorDataResult<UserDTO>("Could not assign the role");
            }


            return new SuccessDataResult<UserDTO>(new UserDTO
            {
                Email = user.Email,
                Token = await _tokenService.CreateToken(user)
            });

        }
        public async Task<IResult> CheckIfUserExists(string kullaniciAdi)
        {
            if (await _context.Users.AnyAsync(x => x.UserName == kullaniciAdi))
            {
                return new ErrorResult("User Already exist");
            }
            return new SuccessResult();
        }

        public async Task AddRoles()
        {
            var roles = new List<Role>
            {
                new Role{Name="Admin"},
                new Role{Name="Moderator"},
                new Role{Name="Member"}
            };

            foreach (var role in roles)
            {
                await _roleManager.CreateAsync(role);

            }
        }


    }
}
