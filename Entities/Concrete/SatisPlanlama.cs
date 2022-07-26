
namespace Entities.Concrete;

public class SatisPlanlama
{
    public int Id { get; set; }
    public string KabloIsmi { get; set; }
    public int Metraj { get; set; }
    public double Tonaj{ get; set; }
    public double ListeFiyati{ get; set; }
    public double Fiyat{ get; set; }
    public double Iskonto{ get; set; }
    public double Tutar{ get; set; }
    public string PaketlemeSekli{ get; set; }
    public DateTime Tarih{ get; set; }

}