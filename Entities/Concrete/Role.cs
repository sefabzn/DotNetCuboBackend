using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete
{
    public class Role : IdentityRole<int>
    {

        public List<UserRole>? UserRoles { get; set; }
    }
}
