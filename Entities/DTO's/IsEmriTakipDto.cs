namespace Entities.DTO_s
{
    public class IsEmriTakipDto
    {

        public string? Isim { get; set; }
        public string? MakineIsmi { get; set; } //  bu özellik ortak is emri verme kısmında
        public DateTime Tarih { get; set; }
        public string? Degistiren { get; set; }
        public string? Tur { get; set; }
        public double Metraj { get; set; }
        public bool TamamlanmaDurumu { get; set; }
        public string? Barkod { get; set; }


    }
}
