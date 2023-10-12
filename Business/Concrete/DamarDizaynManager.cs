using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Base;

namespace Business.Concrete
{
    public class DamarDizaynManager : ManagerBase<DamarDizaynBase, IDamarDizaynDal>, IDamarDizaynService
    {
        IGenelDizaynDal _GenelDizaynDal;
        IDamarDizaynDal _DamarDizaynDal;
        public DamarDizaynManager(IDamarDizaynDal dal, IGenelDizaynDal cctvGenelDizaynDal) : base(dal)
        {
            _GenelDizaynDal = cctvGenelDizaynDal;
            _DamarDizaynDal = dal;
        }
        public IResult UpdateGenelDizaynDamarSayisi(int genelDizaynId)
        {
            var genelDizaynKablo = _GenelDizaynDal.GetAsync(x => x.Id == genelDizaynId).Result;

            var damarSayisi = _DamarDizaynDal.GetAllAsync(x => x.GenelDizaynId == genelDizaynId).Result.Count;

            genelDizaynKablo.GirilenDamarSayisi = damarSayisi;

            _GenelDizaynDal.UpdateAsync(genelDizaynKablo);

            return new SuccessResult("Damar Sayısı Güncellendi");
        }
    }
}
