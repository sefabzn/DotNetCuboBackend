using Core.Entities;
using System.ComponentModel;

namespace Entities.Concrete;

public class OperatorIsEmri : IEntity
{
    public OperatorIsEmri()
    {
        Surecler = new List<Process>();
    }
    public int Id { get; set; }
    public string? MakineIsmi { get; set; }
    public string? Operator { get; set; }
    public string? UrunIsmi { get; set; }
    public string? DizaynTuru { get; set; }
    public double KesitCapi { get; set; }
    public double Metraj { get; set; }
    public double DisCap { get; set; }
    public double Back { get; set; }
    public double Ayna { get; set; }
    public string? Kalip { get; set; }
    public double TeorikMaliyet { get; set; }
    [DefaultValue(false)]
    public bool TamamlanmaDurumu { get; set; }
    public string? Barkod { get; set; }

    public List<Process>? Surecler { get; set; }
    public DateTime Tarih { get; set; }
    public string? Degistiren { get; set; }
}