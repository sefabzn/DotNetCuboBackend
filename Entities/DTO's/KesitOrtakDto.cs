using Core.Entities;

namespace Entities.DTO_s
{
    public class KesitOrtakDto : IDto
    {
        public double KesitCapi { get; set; }
        public List<int>? makineIdleri { get; set; } = new List<int>();
    }
}
