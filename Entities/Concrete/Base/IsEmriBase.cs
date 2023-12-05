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

        public int DamarSayisi { get; set; }
        public int GirilenDamarSayisi { get; set; }

        [DefaultValue(false)]
        public bool TamamlanmaDurumu { get; set; }
        public virtual Barkod? Barkod { get; set; }
        public string BarkodString { get; set; }

        public List<Process>? Surecler { get; set; }


        //  için konuldu.

        public DateTime Tarih { get; set; }
        public string? Degistiren { get; set; }

        public int GenelDizaynId { get; set; }
        public GenelDizaynBase GenelDizayn { get; set; }

        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
        public List<DamarDizaynBase>? Damarlar { get; set; }
        public List<KabloUretim>? KabloUretimler { get; set; }
    }

}
