using Core.Entities;

namespace Entities.DTO_s

{
    public class RegisterDto : IDto
    {

        public string? Email { get; set; }
        public string? Username { get; set; }

        public string? Password { get; set; }
    }
}
