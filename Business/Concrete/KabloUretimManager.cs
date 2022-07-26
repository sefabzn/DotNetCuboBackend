using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class KabloUretimManager : IKabloUretimService
    {
        private IKabloUretimDal _kabloUretimDal;

        public KabloUretimManager(IKabloUretimDal kabloUretimDal)
        {
            _kabloUretimDal = kabloUretimDal;
        }
        public IResult add(KabloUretim kablo)
        {
            _kabloUretimDal.Add((kablo));
            return new SuccessResult("Ürün Başarıyla Eklendi");
        }

        public IResult delete(KabloUretim kablo)
        {
            _kabloUretimDal.Delete(kablo);
            return new SuccessResult("Ürün Başarıyla Silindi");

        }

        public IResult update(KabloUretim kablo)
        {
            _kabloUretimDal.Update(kablo);
            return new SuccessResult("Ürün Başarıyla Güncellendi");
        }

        public IDataResult<List<KabloUretim>> GetAll(Expression<Func<KabloUretim, bool>>? filter = null)
        {
            return new SuccessDataResult<List<KabloUretim>>(_kabloUretimDal.GetAll(filter), "Ürünler Getirildi");
        }

        public IDataResult<KabloUretim> Get(Expression<Func<KabloUretim, bool>> filter)
        {
            return new SuccessDataResult<KabloUretim>(_kabloUretimDal.Get(filter));
        }
    }
}
