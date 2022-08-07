using Core.Entities;

namespace Entities.Concrete;

public class OperatorIsEmri:IEntity
{
    public int Id { get; set; }
    public string MakineIsmi { get; set; }
    public string Operator { get; set; }
    public string UrunIsmi { get; set; }
    public string DizaynTuru { get; set; }
    public double KesitCapi { get; set; }
    public int Metraj { get; set; }
    public double DisCap { get; set; }
    public double Back { get; set; }
    public double Ayna { get; set; }
    public string Kalip { get; set; }
    public double TeorikMaliyet { get; set; }
    public DateTime Tarih { get; set; }
}