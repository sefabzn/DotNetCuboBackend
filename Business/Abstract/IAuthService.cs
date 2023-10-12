using Core.Utilities.Results;
using Entities.DTO_s;

namespace Business.Abstract
{
    public interface IAuthService
    {

        Task<IDataResult<UserDTO>> RegisterAsync(RegisterDto registerUser);
        Task AddRoles();
        Task<IDataResult<UserDTO>> LoginAsync(LoginDto loginUser);

        Task<IResult> CheckIfUserExists(string kullaniciAdi);

    }


}
