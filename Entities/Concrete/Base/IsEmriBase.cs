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
        public int? Id { get; set; }
        public string? Isim { get; set; }
        public string? Tur { get; set; }


        [DefaultValue(false)]
        public bool TamamlanmaDurumu { get; set; }
        public string? Barkod { get; set; }

        public List<Process>? Surecler { get; set; }

        public DateTime Tarih { get; set; }
        public string? Degistiren { get; set; }
        public int GenelDizaynId { get; set; }
        public virtual GenelDizaynBase? GenelDizayn { get; set; }
        public virtual KabloUretim? KabloUretim { get; set; }
    }

}
