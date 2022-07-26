using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;
namespace Core.Extensions
{

    public static class ClaimExtensions
    {

        public static void AddKullaniciAdi(this ICollection<Claim> claims, string kullaniciAdi)
        {
            claims.Add(new Claim(ClaimTypes.Name, kullaniciAdi));
        }

        public static void AddKullaniciIdentifier(this ICollection<Claim> claims, string kullaniciIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, kullaniciIdentifier));
        }
    
        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
