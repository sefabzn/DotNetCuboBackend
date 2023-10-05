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
        public string? BukumBarkodu { get; set; }
        public string? DamarBarkodu { get; set; }
        public string? DamarBukumBarkodu { get; set; }
        public string? DolguBarkodu { get; set; }
        public string? KilifBarkodu { get; set; }
        public string? FolyoBarkodu { get; set; }
        public string? OrguBarkodu { get; set; }
        public string? DisKilifBarkodu { get; set; }

        [DefaultValue(false)]
        public bool TamamlanmaDurumu { get; set; }
        public string? Barkod { get; set; }

        public List<Process>? Surecler { get; set; }

        public DateTime Tarih { get; set; }
        public string? Degistiren { get; set; }
    }

}
