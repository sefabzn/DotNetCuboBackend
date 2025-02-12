using Core.Entities;

namespace Entities.Concrete
{
    public class SevkIrsaliyeKalem : IEntity
    {
        public int Id { get; set; }
        public int SevkIrsaliyeId { get; set; }
        public int KabloUretimId { get; set; }
        public double Miktar { get; set; }
        public double Fiyat { get; set; }
        public SevkIrsaliye? SevkIrsaliye { get; set; }
        public KabloUretim? KabloUretim { get; set; }
    }
}
