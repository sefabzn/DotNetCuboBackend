using Core.Entities;

namespace Entities.Base
{
    public class IsEmirleriBase:IEntity
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string BukumBarkodu { get; set; }
        public string DamarBarkodu { get; set; }
        public string DamarBukumBarkodu { get; set; }
        public string DolguBarkodu { get; set; }
        public string KilifBarkodu { get; set; }
        public string FolyoBarkodu { get; set; }
        public string OrguBarkodu { get; set; }
        public string DisKilifBarkodu { get; set; }
        public DateTime Tarih { get; set; }
    }

}
