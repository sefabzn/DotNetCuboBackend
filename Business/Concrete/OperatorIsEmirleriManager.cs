using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OperatorIsEmriManager : ManagerBase<OperatorIsEmri, IOperatorIsEmriDal>, IOperatorIsEmriService
    {

        IMakineDal _makineDal;
        IOperatorIsEmriDal _operatorIsEmriDal;
        IMakineKesitHizTablosuDal _kesitHizTablosuDal;
        public OperatorIsEmriManager(IOperatorIsEmriDal operatorIsEmriDal, IMakineKesitHizTablosuDal kesitHizTablosuDal, IMakineDal makineDal) : base(operatorIsEmriDal)
        {
            _operatorIsEmriDal = operatorIsEmriDal;
            _kesitHizTablosuDal = kesitHizTablosuDal;
            _makineDal = makineDal;

        }



        public async Task<Object> IsPlaniOlustur(OrtakIsEmri ortakIsEmri)
        {
            List<Makine> makines = (from isim in ortakIsEmri.MakineIsimleri
                                    select _makineDal.GetAsync(x => x.MakineIsmi == isim).Result).ToList();
            var kesitBilgisi = await _kesitHizTablosuDal.GetAllAsync();

            double? toplamVerimlilik = 0;

            foreach (var makine in makines)
            {
                toplamVerimlilik += makine.Verimlilik;
            }

            var ortalamaVerimlilik = toplamVerimlilik / makines.Count();



            List<Object> liste = new List<object>();
            foreach (var makine in makines)
            {
                var isEmri = new OperatorIsEmri()
                {
                    UrunIsmi = ortakIsEmri.UrunIsmi,
                    DizaynTuru = ortakIsEmri.DizaynTuru,
                    DisCap = ortakIsEmri.DisCap,
                    Back = ortakIsEmri.Back,
                    Ayna = ortakIsEmri.Ayna,
                    Kalip = ortakIsEmri.Kalip,
                    MakineIsmi = makine.MakineIsmi,
                    Metraj = Convert.ToDouble(ortakIsEmri.Metraj * (makine.Verimlilik / toplamVerimlilik)),
                    KesitCapi = ortakIsEmri.Kesit,
                    Operator = ortakIsEmri.Operator,
                    Degistiren = ortakIsEmri.Degistiren,
                    Tarih = ortakIsEmri.Tarih

                };

                liste.Add(isEmri);
                await _operatorIsEmriDal.AddAsync(isEmri);
            }

            return (liste);
        }

        public async Task<double?> TeorikSüreHesapla(OrtakIsEmri ortakIsEmri)
        {
            List<Makine> makines = new List<Makine>();
            foreach (var isim in ortakIsEmri.MakineIsimleri)
            {
                makines.Add(_makineDal.GetAsync(x => x.MakineIsmi == isim).Result);

            }


            var kesitBilgisi = await _kesitHizTablosuDal.GetAllAsync();

            var toplamHiz = 0;
            double? toplamVerimlilik = 0;

            foreach (var makine in makines)
            {
                toplamHiz += kesitBilgisi.Single(x => x.MakineId == makine.Id && x.KesitCapi == ortakIsEmri.Kesit).Hiz;
                toplamVerimlilik += makine.Verimlilik;
            }

            var ortalamaVerimlilik = toplamVerimlilik / makines.Count();

            var teorikTahminiSüre = (ortakIsEmri.Metraj / (toplamHiz * 60)) / (ortalamaVerimlilik);



            return (teorikTahminiSüre);
        }




    }
}
