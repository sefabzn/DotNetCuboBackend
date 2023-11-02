using Core.Entities;
using Entities.Concrete;
using System.ComponentModel;

namespace Entities.Base
{
    public class IsEmriBase : IEntity
    {
        public IsEmriBase()
        {
            Tarih = DateTime.Today;
        }
        public int Id { get; set; }
        public string? Isim { get; set; }
        public string? Tur { get; set; }

        public double Metraj { get; set; }

        [DefaultValue(false)]
        public bool TamamlanmaDurumu { get; set; }
        public virtual Barkod? Barkod { get; set; }
        public string BarkodString { get; set; }

        public List<Process>? Surecler { get; set; }

        [DefaultValue(null)]
        public string? MakineIsmi { get; set; } //  bu özellik ortak is emri verme kısmında
                                                //  otomatik olarak bir makineye en  uygun iş emrini vermesi
        public int MakineId { get; set; } //  bu özellik ortak is emri verme kısmında
                                          //  için konuldu.




        public DateTime Tarih { get; set; }
        public string? Degistiren { get; set; }

        public int GenelDizaynId { get; set; }
        public virtual GenelDizaynBase? GenelDizayn { get; set; }
        public virtual List<KabloUretim>? KabloUretimler { get; set; }
        public List<IsEmriOperator>? IsEmriOperators { get; set; }
    }

}
