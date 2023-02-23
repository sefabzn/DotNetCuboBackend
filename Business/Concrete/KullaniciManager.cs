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
using Core.Business;
using Core.CrossCuttingConcern.Logging;

namespace Business.Concrete
{
    public class KullaniciManager : ManagerBase<Kullanici, IKullaniciDal>, IKullaniciService
    {
        IKullaniciDal _kullaniciDal;
        ILoggerService _loggerService;
        public KullaniciManager(IKullaniciDal dal,ILoggerService loggerService) : base(dal)
        {
            _kullaniciDal = dal;
            _loggerService = loggerService;
        }



        [ValidationAspect(typeof(KullaniciValidator))]
        [CacheRemoveAspect("IKullaniciService.Get")]

        private IResult CheckIfKullaniciExists(string kullaniciAdi)
        {

            if (_kullaniciDal.GetAll(x => x.KullaniciAdi == kullaniciAdi).Any())
            {
                return new ErrorResult();
            }
            return new SuccessResult();


        }
      
        public IDataResult<List<OperationClaim>> GetClaims(Kullanici kullanici)
        {
            return new SuccessDataResult<List<OperationClaim>>(_kullaniciDal.GetClaims(kullanici));
        }
       
        public IDataResult<Kullanici> GetByKullaniciAdi(string kullaniciAdi)
        {
            _loggerService.LogInfo($"{kullaniciAdi} isimli kullanıcı getirildi. ");
           
            return new SuccessDataResult<Kullanici>(_kullaniciDal.Get(x => x.KullaniciAdi == kullaniciAdi));
        }
    }
}
