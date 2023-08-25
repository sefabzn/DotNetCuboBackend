using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Mailing;
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
        private IExchangeRateDal _exchangeRateDal;

        //Bu class cok fazla experimental bunu test et
        public KabloUretimManager(IKabloUretimDal kabloUretimDal, ISarfiyatDal sarfiyatDal, IKesitYapisiDal kesitYapisiDal, IMakineDal makineDal,IExchangeRateDal exchangeRateDal):base(kabloUretimDal)
        {
            _kabloUretimDal = kabloUretimDal;
            _sarfiyatDal = sarfiyatDal;
            _kesitYapisiDal = kesitYapisiDal;
            _makineDal = makineDal;
            _exchangeRateDal = exchangeRateDal;
        }

        [MailAspect]
        public new async Task<IResult> addAsync(KabloUretim kablo) // new keywordu base'deki aynı isimdeki methodu bastırması için kullanılır
        {


            var makine = await _makineDal.GetAsync(x => x.Id == kablo.MakineId);

            VerimlilikHesapla(kablo, makine);

            await _kabloUretimDal.AddAsync((kablo));
            await addToSarfiyat(kablo);

            return new SuccessResult("Ürün Başarıyla Eklendi");
        }
        public async Task<IResult> IsTimeValid()
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

            double calismaSuresiByDakika = kablo.CalismaSuresi * 60;

            kablo.KayipZaman = (KopmaKaybi + RenkDegisimiKaybi + KesitDegisimiKaybi + GenelAriza + Isinma);
            kablo.Verimlilik = Math.Round(((calismaSuresiByDakika - kablo.KayipZaman) / calismaSuresiByDakika),2); // Çalışılan zaman 0 olmamalı dikkat et
        }

        private async Task<IResult> addToSarfiyat(KabloUretim kablo)
        {
            double PVCOZGUL = 1.5;  ///// Bu değerler için henüz bir veritabanı yok o yüzden constant 
            double CUOZGUL = 8.95;   // değişken gibi girdim
            var kesityapisi =await _kesitYapisiDal.GetAsync(x => x.KesitCapi == kablo.KesitCapi);
            double Back = Convert.ToDouble(kesityapisi.Back);
            double Dis_Cap = Convert.ToDouble(kesityapisi.DisCap);

            double cuAlan = Convert.ToDouble(kesityapisi.Alan);




            double kullanilanPVC = ((Dis_Cap / 2) * Math.PI - ((Back / 2) * Math.PI)) * PVCOZGUL * Convert.ToDouble(kablo.Metraj) / 1000;
            double kullanilanCu = cuAlan * CUOZGUL * Convert.ToDouble(kablo.Metraj) / 1000;


            double cuFiyat = _exchangeRateDal.GetCopperRateByTL();
            double cuMaliyet = kullanilanCu * cuFiyat;

            double pvcMaliyet = 0; //şimdilik

            double toplamMaliyet = cuMaliyet + pvcMaliyet;
            Sarfiyat sarfiyat = new Sarfiyat
            {
                KabloId = kablo.Id,
                KesitCapi = kablo.KesitCapi,
                MakineId = kablo.MakineId,
                KullanilanPvc = kullanilanPVC,
                KullanilanCu = kullanilanCu,
                HurdaPvc = kablo.HurdaPvc,
                HurdaCu = kablo.HurdaCu,
                Maliyet = toplamMaliyet,
                Tarih = kablo.Tarih
            };

           await _sarfiyatDal.AddAsync((sarfiyat));
            return new SuccessResult();
        }

     

        public new async Task<IResult> deleteAsync(KabloUretim kablo)
        {
            var sarfiyat =await _sarfiyatDal.GetAsync(x => x.KabloId == kablo.Id);
            try
            {
                await _sarfiyatDal.DeleteAsync(sarfiyat);
            }
            catch (Exception)
            {

                Console.WriteLine("Belirtilen kabloya ait sarfiyat verisi bulunamadı");
            }
          
            await _kabloUretimDal.DeleteAsync(kablo);
            return new SuccessResult("Ürün Başarıyla Silindi");

        }

        public new async Task<IResult> update(KabloUretim kablo)
        {
            await _kabloUretimDal.UpdateAsync(kablo);
            return new SuccessResult("Ürün Başarıyla Güncellendi");
        }

        public async Task<IDataResult<List<KabloUretim>>> GetAll(Expression<Func<KabloUretim, bool>>? filter = null)
        {
            return new SuccessDataResult<List<KabloUretim>>(await _kabloUretimDal.GetAllAsync(filter), "Ürünler Getirildi");
        }

        public async Task<IDataResult<KabloUretim>> GetAsync(Expression<Func<KabloUretim, bool>> filter)
        {
            return new SuccessDataResult<KabloUretim>(await _kabloUretimDal.GetAsync(filter));
        }

  
    }
}
