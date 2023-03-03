using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTO_s;

namespace Business.Abstract
{
    public interface IAuthService
    {

        Task<IDataResult<Kullanici>> Register(KullaniciForRegisterDto userForRegisterDto, string password);
        Task<IDataResult<Kullanici>> Login(KullaniciForLoginDto userForLoginDto);
        Task<IResult> CheckIfUserExists(string kullaniciAdi);
        Task<IDataResult<AccessToken>> CreateAccessToken(Kullanici kullanici);
    }

    
}
