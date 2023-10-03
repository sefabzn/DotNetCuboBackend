using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class TelefonDamarDizaynManager : ManagerBase<TelefonDamarDizayn, ITelefonDamarDizaynDal>, ITelefonDamarDizaynService
    {

        ITelefonDamarDizaynDal _telefonDamarDizaynDal;
        ITelefonGenelDizaynDal _telefonGenelDizaynDal;
        public TelefonDamarDizaynManager(ITelefonDamarDizaynDal telefonDamarDizaynDal, ITelefonGenelDizaynDal telefonGenelDizaynDal) : base(telefonDamarDizaynDal)
        {
            _telefonDamarDizaynDal = telefonDamarDizaynDal;
            _telefonGenelDizaynDal = telefonGenelDizaynDal;
        }
        public IResult UpdateGenelDizaynDamarSayisi(int genelDizaynId)
        {
            var genelDizaynKablo = _telefonGenelDizaynDal.GetAsync(x => x.Id == genelDizaynId).Result;

            var damarSayisi = _telefonDamarDizaynDal.GetAllAsync(x => x.AnaId == genelDizaynId).Result.Count;

            genelDizaynKablo.GirilenDamarSayisi = damarSayisi;

            _telefonGenelDizaynDal.UpdateAsync(genelDizaynKablo);

            return new SuccessResult("Damar Sayısı Güncellendi");
        }
    }
}
