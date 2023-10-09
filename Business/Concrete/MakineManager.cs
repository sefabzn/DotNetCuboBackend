using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
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

        [CacheAspect]
        public async Task<IDataResult<List<MakineGunlukRaporDto>>> GetGunlukRaporlarAsync(string makineIsmi, DateTime firstDate, DateTime lastDate)
        {
            return new SuccessDataResult<List<MakineGunlukRaporDto>>(_makineDal.getGunlukRapor(makineIsmi, firstDate, lastDate), "Günlük Rapor Getirildi");
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
