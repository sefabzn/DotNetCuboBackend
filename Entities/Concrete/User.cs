using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete
{
    public class User : IdentityUser<int>
    {
        public List<UserRole>? UserRoles { get; set; }

    }
}
