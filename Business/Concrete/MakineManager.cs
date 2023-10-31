using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTO_s;

namespace Business.Concrete
{
    public class MakineManager : ManagerBase<Makine, IMakineDal>, IMakineService
    {
        IMakineDal _makineDal;
        IKabloUretimDal _kabloUretimDal;

        public MakineManager(IMakineDal dal, IKabloUretimDal kabloUretimDal) : base(dal, new MakineValidator())
        {
            _makineDal = dal;
            _kabloUretimDal = kabloUretimDal;
        }

        public async Task<IDataResult<RaporAnalizDto>> GetRaporAnalysis(int makineId, DateTime firstDate, DateTime lastDate)
        {
            var secilenGun = (lastDate - firstDate).Days + 1;
            var raporlar = await _makineDal.getRaporByDateRange(makineId, firstDate, lastDate);
            var raporAnaliz = new RaporAnalizDto()
            {
                MakineIsmi = raporlar[0].MakineIsmi,
                BaslangicTarihi = firstDate,
                BitisTarihi = lastDate,
                OrtalamaAriza = raporlar.Average(x => x.GenelAriza),
                SecilenGun = (lastDate - firstDate).Days + 1,
                OrtalamaIsinma = raporlar.Average(x => x.Isinma),
                OrtalamaKesitDegisimKaybi = raporlar.Average(x => x.KesitDegisimiKaybi),
                OrtalamaKopmaKaybi = raporlar.Average(x => x.KopmaKaybi),
                OrtalamaRenkDegisimKaybi = raporlar.Average(x => x.RenkDegisimiKaybi),
                OrtalamaVerimlilik = raporlar.Average(x => x.Verimlilik),
                HurdaCu = raporlar.Sum(x => x.HurdaCu),
                HurdaPvc = raporlar.Sum(x => x.HurdaPvc),
                CalisilanGun = raporlar.Count,
                VerimliGun = raporlar.Count(x => x.Verimlilik >= 0.50),
                VerimsizGun = raporlar.Count(x => x.Verimlilik < 0.50),
                ToplamCu = raporlar.Sum(x => x.KullanilanCu) + raporlar.Sum(x => x.HurdaCu),
                ToplamPvc = raporlar.Sum(x => x.KullanilanPvc) + raporlar.Sum(x => x.HurdaPvc),
                ToplamMetraj = raporlar.Sum(x => x.Metraj),
            };
            return new SuccessDataResult<RaporAnalizDto>(raporAnaliz, "Rapor Analizi Getirildi");
        }

        //[CacheAspect]
        public async Task<IDataResult<List<MakineGunlukRaporDto>>> getRaporByDateRangeAsync(int makineId, DateTime firstDate, DateTime lastDate)
        {
            return new SuccessDataResult<List<MakineGunlukRaporDto>>(await _makineDal.getRaporByDateRange(makineId, firstDate, lastDate), "Günlük Rapor Getirildi");
        }

        public async Task<IDataResult<double>> SetOrtalamaVerimlilik(int id)
        {

            // Makine ve verileri al.
            var makine = await _makineDal.GetAsync(x => x.Id == id);
            var data = await _kabloUretimDal.GetAllAsync(x => x.MakineId == id);
            if (data.Count == 0)
            {
                makine.Verimlilik = 0;
                return new SuccessDataResult<double>(0, "Verimlilik Hesaplandı");
            }

            // Ortalama verimliliği hesapla.
            var ortalamaVerimlilik = data.Average(x => x.Verimlilik);

            // Makinenin verimliliğini güncelle.
            makine.Verimlilik = ortalamaVerimlilik;
            await _makineDal.UpdateAsync(makine);

            // Verimliliği döndür.
            return new SuccessDataResult<double>(ortalamaVerimlilik, "Verimlilik Hesaplandı");
        }

        public async Task<IResult> SetOrtalamaVerimlilikForAll()
        {
            var makineler = await _makineDal.GetAllAsync();

            foreach (var makine in makineler)
            {

                await SetOrtalamaVerimlilik(makine.Id);
            }
            return new SuccessResult("Tüm makineler için verimlilik hesaplandı");
        }
    }
}
