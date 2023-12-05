using Core.Entities;

namespace Entities.Concrete.Base;

public class TekDamarDizaynBase : IEntity
{
    public int Id { get; set; }
    public string KabloIsmi { get; set; }
    public string Core { get; set; }
    public double KesitCapi { get; set; }
    public double Hatve { get; set; }
    public double DisKilif1 { get; set; }
    public double DisKilif2 { get; set; }
    public double DisCap { get; set; }
    public double Back { get; set; }
    public double Ayna { get; set; }
    public string Kalip { get; set; }
    public string DizaynTuru { get; set; }
    public DateTime Tarih { get; set; }
    public DateTime DegistirilmeTarihi { get; set; }
    public string Degistiren { get; set; }


}