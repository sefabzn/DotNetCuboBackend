using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using System.Linq.Expressions;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Validation.FluentValidation;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class KullaniciManager:IKullaniciService
    {
        IKullaniciDal _kullaniciDal;

        public KullaniciManager(IKullaniciDal repository)
        {
            _kullaniciDal = repository;
        }
        [ValidationAspect(typeof(KullaniciValidator))]
        [CacheRemoveAspect("IKullaniciService.Get")]
        public IResult add(Kullanici kullanici)
        {

            var result = BusinessRules.Run(CheckIfKullaniciExists(kullanici.Kullanici_Adi));

            if (result != null)
            {
                return result;
            }
            _kullaniciDal.Add(kullanici);
            return new SuccessResult("Ürün Eklendi");
        }
        private IResult CheckIfKullaniciExists(string kullaniciAdi)
        {

            if (_kullaniciDal.GetAll(x => x.Kullanici_Adi == kullaniciAdi).Any())
            {
                return new ErrorResult();
            }
            return new SuccessResult();


        }
        public IResult delete(Kullanici kullanici)
        {
            _kullaniciDal.Delete(kullanici);
            return new SuccessResult("Ürün Eklendi");
        }

        public IDataResult<Kullanici> Get(Expression<Func<Kullanici, bool>> filter)
        {
            return new SuccessDataResult<Kullanici>(_kullaniciDal.Get(filter), "Ürün Getirildi");
        }

     

        public IResult update(Kullanici kullanici)
        {
            _kullaniciDal.Update(kullanici);
            return new SuccessResult("Ürün Değiştirildi");
        }

        public IDataResult<List<OperationClaim>> GetClaims(Kullanici kullanici)
        {
            return new SuccessDataResult<List<OperationClaim>>(_kullaniciDal.GetClaims(kullanici));
        }
        //[CacheAspect]
        public IDataResult<List<Kullanici>> GetAll(Expression<Func<Kullanici, bool>> filter = null)
        {
            return new SuccessDataResult<List<Kullanici>>(_kullaniciDal.GetAll(filter), "Ürünler Listelendi");

        }

        public IDataResult<Kullanici> GetByKullaniciAdi(string kullaniciAdi)
        {
            return new SuccessDataResult<Kullanici>(_kullaniciDal.Get(x => x.Kullanici_Adi == kullaniciAdi));
        }
    }
}
