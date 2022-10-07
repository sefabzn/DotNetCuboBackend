using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Business;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class KabloUretimManager : ManagerBase<KabloUretim, IKabloUretimDal>, IKabloUretimService
    {
        private IKabloUretimDal _kabloUretimDal;
        private ISarfiyatDal _sarfiyatDal;
        private IKesitYapisiDal _kesitYapisiDal;
        private IMakineDal _makineDal;

        //Bu class cok fazla experimental bunu test et
        public KabloUretimManager(IKabloUretimDal kabloUretimDal, ISarfiyatDal sarfiyatDal, IKesitYapisiDal kesitYapisiDal, IMakineDal makineDal):base(kabloUretimDal)
        {
            _kabloUretimDal = kabloUretimDal;
            _sarfiyatDal = sarfiyatDal;
            _kesitYapisiDal = kesitYapisiDal;
            _makineDal = makineDal;
        }
        public IResult add(KabloUretim kablo)
        {

            var result = BusinessRules.Run(IsTimeValid());

            if (result != null)
            {
                return result;
            }


            var makine = _makineDal.Get(x => x.Id == kablo.MakineId);

            VerimlilikHesapla(kablo, makine);

            _kabloUretimDal.Add((kablo));
            addToSarfiyat(kablo);

            return new SuccessResult("Ürün Başarıyla Eklendi");
        }
        public IResult IsTimeValid()
        {
            if (DateTime.Now.Hour < 6 && DateTime.Now.Hour > 21 )
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
        private static void VerimlilikHesapla(KabloUretim kablo, Makine makine)
        {
            double KopmaKaybi = kablo.Kopma * makine.Kopma;
            double RenkDegisimiKaybi = kablo.RenkDegisimi * makine.RenkDegisimi;
            double KesitDegisimiKaybi = makine.KesitDegisimi;//her kesit 1 kez kesit değişimi yapmış sayılır
            double GenelAriza = kablo.GenelAriza;
            double Isinma = makine.Isinma;

            kablo.KayipZaman = (KopmaKaybi + RenkDegisimiKaybi + KesitDegisimiKaybi + GenelAriza + Isinma);
            kablo.Verimlilik = Math.Round(((kablo.CalismaSuresi - kablo.KayipZaman) / kablo.CalismaSuresi),2) * 100; // Çalışılan zaman 0 olmamalı dikkat et
        }

        private IResult addToSarfiyat(KabloUretim kablo)
        {
            double PVCOZGUL = 1.5;  ///// Bu değerler için henüz bir veritabanı yok o yüzden constant 
            double CUOZGUL = 8.95;   // değişken gibi girdim
            var kesityapisi = _kesitYapisiDal.Get(x => x.KesitCapi == kablo.KesitCapi);
            double Back = Convert.ToDouble(kesityapisi.Back);
            double Dis_Cap = Convert.ToDouble(kesityapisi.DisCap);

            double cuAlan = Convert.ToDouble(kesityapisi.Alan);




            double kullanilanPVC = (Dis_Cap / 2 * Math.PI - ((Back / 2) * Math.PI)) * PVCOZGUL * Convert.ToDouble(kablo.Metraj) / 1000;
            double kullanilanCu = cuAlan * CUOZGUL * Convert.ToDouble(kablo.Metraj) / 1000;

            Sarfiyat sarfiyat = new Sarfiyat
            {
                KabloId = kablo.Id,
                KesitCapi = kablo.KesitCapi,
                MakineId = kablo.MakineId,
                KullanilanPvc = kullanilanPVC,
                KullanilanCu = kullanilanCu,
                HurdaPvc = kablo.HurdaPvc,
                HurdaCu = kablo.HurdaCu,
                Maliyet = 0,
                Tarih = kablo.Tarih
            };

            _sarfiyatDal.Add((sarfiyat));
            return new SuccessResult();
        }

     

        public IResult delete(KabloUretim kablo)
        {
            var sarfiyat = _sarfiyatDal.Get(x => x.KabloId == kablo.Id);
            try
            {
                _sarfiyatDal.Delete(sarfiyat);
            }
            catch (Exception)
            {

                Console.WriteLine("Belirtilen kabloya ait sarfiyat verisi bulunamadı");
            }
          
            _kabloUretimDal.Delete(kablo);
            return new SuccessResult("Ürün Başarıyla Silindi");

        }

        public IResult update(KabloUretim kablo)
        {
            _kabloUretimDal.Update(kablo);
            return new SuccessResult("Ürün Başarıyla Güncellendi");
        }

        public IDataResult<List<KabloUretim>> GetAll(Expression<Func<KabloUretim, bool>>? filter = null)
        {
            return new SuccessDataResult<List<KabloUretim>>(_kabloUretimDal.GetAll(filter), "Ürünler Getirildi");
        }

        public IDataResult<KabloUretim> Get(Expression<Func<KabloUretim, bool>> filter)
        {
            return new SuccessDataResult<KabloUretim>(_kabloUretimDal.Get(filter));
        }

  
    }
}
