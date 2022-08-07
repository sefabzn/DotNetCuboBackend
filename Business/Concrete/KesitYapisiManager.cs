using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class KesitYapisiManager : IKesitYapisiService
    {
        IKesitYapisiDal _kesitYapisiDal;
        public KesitYapisiManager(IKesitYapisiDal kesitYapisiDal)
        {
            _kesitYapisiDal = kesitYapisiDal;
        }
        public IResult add(KesitYapisi entity)
        {
            _kesitYapisiDal.Add(entity);
            return new SuccessResult();
        }

        public IResult delete(KesitYapisi entity)
        {
            _kesitYapisiDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<KesitYapisi> Get(Expression<Func<KesitYapisi, bool>> filter)
        {
            return new SuccessDataResult<KesitYapisi>(_kesitYapisiDal.Get(filter));
        }

        public IDataResult<List<KesitYapisi>> GetAll(Expression<Func<KesitYapisi, bool>>? filter = null)
        {
            return new SuccessDataResult<List<KesitYapisi>>(_kesitYapisiDal.GetAll(filter));
        }

        public IResult update(KesitYapisi entity)
        {
            _kesitYapisiDal.Update(entity);
            return new SuccessResult();
        }
    }
}
