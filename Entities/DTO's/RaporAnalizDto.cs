namespace Entities
{
    public class RaporAnalizDto
    {
        public string? MakineIsmi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public int SecilenGun { get; set; }
        public int CalisilanGun { get; set; }

        public double OrtalamaAriza { get; set; }
        public double OrtalamaRenkDegisimKaybi { get; set; }
        public double OrtalamaKesitDegisimKaybi { get; set; }
        public double OrtalamaKopmaKaybi { get; set; }
        public double OrtalamaIsinma { get; set; }
        public double ToplamMetraj { get; set; }
        public double VerimliGun { get; set; }
        public double VerimsizGun { get; set; }
        public double OrtalamaVerimlilik { get; set; }
        public double ToplamPvc { get; set; }
        public double ToplamCu { get; set; }
        public double HurdaPvc { get; set; }
        public double HurdaCu { get; set; }
    }
}
