using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete
{
    public class UserRole : IdentityUserRole<int>
    {

        public User User { get; set; }

        public Role Role { get; set; }
    }
}
