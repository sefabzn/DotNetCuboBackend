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
using FluentValidation;

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

        
      
        public async Task<IDataResult<List<OperationClaim>>> GetClaimsAsync(Kullanici kullanici)
        {
            return new SuccessDataResult<List<OperationClaim>>(await _kullaniciDal.GetClaimsAsync(kullanici));
        }
       
        public async Task<IDataResult<Kullanici>> GetByKullaniciAdiAsync(string kullaniciAdi)
        {
            var data =await _kullaniciDal.GetAsync(x=>x.KullaniciAdi==kullaniciAdi);
            
            _loggerService.LogInfo($"{kullaniciAdi} isimli kullanıcı getirildi. ");
           
            return new SuccessDataResult<Kullanici>(data);
        }
    }
}
