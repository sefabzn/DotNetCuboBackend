using System.Linq.Expressions;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;

namespace Business.Concrete
{
    public class MakineManager : IMakineService
    {
        IMakineDal _makineDal;

        public MakineManager(IMakineDal makinaDal)
        {
            _makineDal = makinaDal;
        }
        //[SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(MakineValidator))]
        [CacheRemoveAspect("IMakineService.Get")]
        public IResult Add(Makine makine)
        {
            _makineDal.Add(makine);
            return new SuccessResult("Makine Eklendi");
        }
        [CacheRemoveAspect("IMakineService.Get")]
        public IResult Delete(Makine Makine)
        {
            _makineDal.Delete(Makine);
            return new SuccessResult("Ürün silindi");
        }

        public IDataResult<Makine> Get(Expression<Func<Makine, bool>> filter)
        {
            return new SuccessDataResult<Makine>(_makineDal.Get(filter));
        }
        [CacheAspect]
        public IDataResult<List<Makine>> GetAll()
        {
            return new SuccessDataResult<List<Makine>>(_makineDal.GetAll());
        }

        [CacheAspect]
        public Makine GetById(int id)
        {
            return _makineDal.Get(x => x.Id == id);
        }
        [CacheAspect]
        public IDataResult<List<MakineGunlukRaporDto>> GetGunlukRaporlar(string makineIsmi, DateTime tarih)
        {
           return new SuccessDataResult<List<MakineGunlukRaporDto>>(_makineDal.getGunlukRapor(makineIsmi,tarih),"Günlük Rapor Getirildi");
        }

        [ValidationAspect(typeof(MakineValidator))]
        [CacheRemoveAspect("IMakineService.Get")]
        public IResult Update(Makine makina)
        {
            return new SuccessResult("Ürün güncellendi");
        }
    }
}
