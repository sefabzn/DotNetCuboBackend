using Core.Entities;

namespace Entities.DTO_s

{
    public class RegisterWithRoleDto : IDto
    {

        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
