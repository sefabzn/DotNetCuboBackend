using Core.Entities;

namespace Entities.DTO_s

{
    public class LoginDto : IDto
    {

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
