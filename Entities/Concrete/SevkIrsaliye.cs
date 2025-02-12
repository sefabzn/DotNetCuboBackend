using Core.Entities;

namespace Entities.Concrete
{
    public class SevkIrsaliye : IEntity
    {
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public DateTime Tarih { get; set; }
        public double ToplamTutar { get; set; }
        public Musteri? Musteri { get; set; }
        public List<SevkIrsaliyeKalem>? Kalemler { get; set; }
    }
}
