using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Base;

namespace Business.Concrete
{
    public class DamarDizaynManager : ManagerBase<DamarDizaynBase, IDamarDizaynDal>, IDamarDizaynService
    {
        IDamarDizaynDal _DamarDizaynDal;
        IIsEmriDal _isEmriDal;
        public DamarDizaynManager(IDamarDizaynDal dal, IIsEmriDal isEmriDal) : base(dal)
        {
            _DamarDizaynDal = dal;
            _isEmriDal = isEmriDal;
        }
        public IResult UpdateIsEmriDamarSayisi(int isEmriId)
        {

            var damarSayisi = _DamarDizaynDal.GetAllAsync(x => x.IsEmriId == isEmriId).Result.Count;

            var isEmri = _isEmriDal.GetAsync(x => x.Id == isEmriId).Result;


            _isEmriDal.UpdateAsync(isEmri);

            return new SuccessResult("Damar Sayısı Güncellendi");
        }
    }
}
