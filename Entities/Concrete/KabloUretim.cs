using Core.Entities;
using Entities.Base;

namespace Entities.Concrete
{
    public class KabloUretim : IEntity
    {

        public int Id { get; set; }
        public string? KabloIsmi { get; set; }
        public int MakineId { get; set; }
        public double KesitCapi { get; set; }
        public double Metraj { get; set; }
        public double Kopma { get; set; }
        public double RenkDegisimi { get; set; }
        public double GenelAriza { get; set; }
        public double HurdaPvc { get; set; }
        public double HurdaCu { get; set; }
        public double CalismaSuresi { get; set; }
        public double KayipZaman { get; set; }
        public double Verimlilik { get; set; }
        public int? IsEmriId { get; set; }

        public IsEmriBase? IsEmri { get; set; }

        public DateTime Tarih { get; set; }
        public string? Degistiren { get; set; }

    }
}
