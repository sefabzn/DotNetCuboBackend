using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTO_s;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IKullaniciService _kullaniciService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IKullaniciService kullaniciService, ITokenHelper tokenHelper)
        {
            _kullaniciService = kullaniciService;
            _tokenHelper = tokenHelper;
        }

        public async Task<IDataResult<Kullanici>> Register(KullaniciForRegisterDto kullaniciForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var kullanici = new Kullanici
            {
                KullaniciAdi = kullaniciForRegisterDto.KullaniciAdi,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,

            };
            await _kullaniciService.addAsync(kullanici);
            return new SuccessDataResult<Kullanici>(kullanici, "User Registered");
        }

        public async Task<IDataResult<Kullanici>> Login(KullaniciForLoginDto kullaniciForLoginDto)
        {
            var kullaniciToCheck =(await _kullaniciService.GetByKullaniciAdiAsync(kullaniciForLoginDto.KullaniciAdi)).Data;
            if (kullaniciToCheck == null)
            {
                return new ErrorDataResult<Kullanici>("User not Found");
            }

            if (!HashingHelper.VerifyPasswordHash(kullaniciForLoginDto.Sifre, kullaniciToCheck.PasswordHash, kullaniciToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Kullanici>("Şifre Hatalı");
            }

            return new SuccessDataResult<Kullanici>(kullaniciToCheck, "Giriş yapıldı");
        }

        public async Task<IResult> CheckIfUserExists(string kullaniciAdi)
        {
            if ((await _kullaniciService.GetByKullaniciAdiAsync(kullaniciAdi)).Data != null)
            {
                return new ErrorResult("User Already exist");
            }
            return new SuccessResult();
        }

        public async Task<IDataResult<AccessToken>> CreateAccessToken(Kullanici kullanici)
        {
            var claims = await _kullaniciService.GetClaimsAsync(kullanici);
            var accessToken = _tokenHelper.CreateToken(kullanici, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, "Acces Token Created");
        }
    }
}
