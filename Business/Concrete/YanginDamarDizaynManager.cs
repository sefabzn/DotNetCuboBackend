using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class YanginDamarDizaynManager : ManagerBase<YanginDamarDizayn, IYanginDamarDizaynDal>, IYanginDamarDizaynService
    {
        IYanginDamarDizaynDal _yanginDamarDizaynDal;
        IYanginGenelDizaynDal _yanginGenelDizaynDal;
        public YanginDamarDizaynManager(IYanginDamarDizaynDal yanginDamarDizaynDal, IYanginGenelDizaynDal yanginGenelDizaynDal) : base(yanginDamarDizaynDal)
        {
            _yanginDamarDizaynDal = yanginDamarDizaynDal;
            _yanginGenelDizaynDal = yanginGenelDizaynDal;
        }
        public IResult UpdateGenelDizaynDamarSayisi(int genelDizaynId)
        {
            var genelDizaynKablo = _yanginGenelDizaynDal.GetAsync(x => x.Id == genelDizaynId).Result;

            var damarSayisi = _yanginDamarDizaynDal.GetAllAsync(x => x.AnaId == genelDizaynId).Result.Count;

            genelDizaynKablo.GirilenDamarSayisi = damarSayisi;

            _yanginGenelDizaynDal.UpdateAsync(genelDizaynKablo);

            return new SuccessResult("Damar Sayısı Güncellendi");
        }
    }
}
