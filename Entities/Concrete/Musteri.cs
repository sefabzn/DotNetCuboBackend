using Core.Entities;

namespace Entities.Concrete
{
    public class Musteri : IEntity
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string? Adres { get; set; }
    }
}
