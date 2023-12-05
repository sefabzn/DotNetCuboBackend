using Core.Entities;

namespace Entities.DTO_s
{
    public class UserDTO : IDto
    {
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}
