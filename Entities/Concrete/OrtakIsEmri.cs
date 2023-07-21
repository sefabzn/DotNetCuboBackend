using Core.Entities;

namespace Entities.Concrete
{
    public class OrtakIsEmri : IEntity
    {
        public string? UrunIsmi { get; set; }
        public string? DizaynTuru { get; set; }
        public double Kesit { get; set; }
        public double Metraj { get; set; }
        public double DisCap { get; set; }
        public double Back { get; set; }
        public double Ayna { get; set; }
        public string? Kalip { get; set; }
        public string? Operator { get; set; }
        public DateTime Tarih { get; set; }
        public string? Degistiren { get; set; }
        public string[]? MakineIsimleri { get; set; }
    }
}
