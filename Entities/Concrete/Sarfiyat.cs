using Core.Entities;

namespace Entities.Concrete;

public class Sarfiyat : IEntity
{
    public int Id { get; set; }
    public int KabloId { get; set; }
    public int KesitId{ get; set; }
    public int MakineId{ get; set; }
    public double KullanilanPvc{ get; set; }
    public double KullanilanCu{ get; set; }
    public double HurdaPvc{ get; set; }
    public double HurdaCu{ get; set; }
    public double Maliyet{ get; set; }
    public DateTime Tarih{ get; set; }

}