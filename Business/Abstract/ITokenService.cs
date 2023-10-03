using Entities.Concrete;

namespace Business.Abstract
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
