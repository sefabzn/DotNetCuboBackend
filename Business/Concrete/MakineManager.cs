using System.Linq.Expressions;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

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
        public IResult add(Makine makine)
        {
            _makineDal.Add(makine);
            return new SuccessResult("Makine Eklendi");
        }
        [CacheRemoveAspect("IMakineService.Get")]
        public IResult delete(Makine Makine)
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
        [ValidationAspect(typeof(MakineValidator))]
        [CacheRemoveAspect("IMakineService.Get")]
        public IResult update(Makine makina)
        {
            return new SuccessResult("Ürün güncellendi");
        }
    }
}
