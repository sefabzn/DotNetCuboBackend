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

        IDataResult<Kullanici> Register(KullaniciForRegisterDto userForRegisterDto, string password);
        IDataResult<Kullanici> Login(KullaniciForLoginDto userForLoginDto);
        IResult UserExists(string kullaniciAdi);
        IDataResult<AccessToken> CreateAccessToken(Kullanici kullanici);
    }

    
}
