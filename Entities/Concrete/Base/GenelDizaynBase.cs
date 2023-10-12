using Core.Entities;

namespace Entities.Base
{
    public class GenelDizaynBase : IEntity
    {
        public int Id { get; set; }
        public string? Kablo { get; set; }
        public string? Tur { get; set; }
        public double KesitCapi { get; set; }
        public double Orgu { get; set; }
        public string? OrguTelYapisi { get; set; }
        public double PolyesterOlcusu { get; set; }
        public string? FolyoTipi { get; set; }
        public double FolyoOlcusu { get; set; }
        public string? DisKilif { get; set; }
        public double DisCap { get; set; }
        public double Back { get; set; }
        public double Ayna { get; set; }
        public string? Kalip { get; set; }

        public string? Core { get; set; }
        public double Hatve { get; set; }
        public DateTime Tarih { get; set; }
        public int DamarSayisi { get; set; }
        public int GirilenDamarSayisi { get; set; }
        public string? Zorlama { get; set; }
        public DateTime DegistirilmeTarihi { get; set; }
        public string? Degistiren { get; set; }
        public List<DamarDizaynBase>? Damarlar { get; set; }
        public virtual List<IsEmriBase>? IsEmirleri { get; set; }
    }
}
