using Core.Entities;

namespace Entities.Concrete
{
    public class Makine : IEntity
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string? MakineIsmi { get; set; }
        public int Isinma { get; set; }
        public int RenkDegisimi { get; set; }
        public int Kopma { get; set; }
        public int KesitDegisimi { get; set; }
        public double? Verimlilik { get; set; }

    }
}
