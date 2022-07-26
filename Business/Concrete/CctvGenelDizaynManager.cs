using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CctvGenelDizaynManager:ICctvGenelDizaynService
    {
        private ICctvGenelDizaynDal _cctvGenelDizaynDal;
        public CctvGenelDizaynManager(ICctvGenelDizaynDal cctvGenelDizaynDal)
        {
            _cctvGenelDizaynDal = cctvGenelDizaynDal;
        }
        public IResult add(CctvGenelDizayn kablo)
        {
            _cctvGenelDizaynDal.Add(kablo);
            return new SuccessResult();
        }

        public IResult delete(CctvGenelDizayn kablo)
        {
            _cctvGenelDizaynDal.Delete(kablo);
            return new SuccessResult();
        }

        public IResult update(CctvGenelDizayn kablo)
        {
            _cctvGenelDizaynDal.Update(kablo);
            return new SuccessResult();
        }

        public IDataResult<List<CctvGenelDizayn>> GetAll(Expression<Func<CctvGenelDizayn, bool>>? filter = null)
        {
            return new SuccessDataResult<List<CctvGenelDizayn>>(_cctvGenelDizaynDal.GetAll(filter));
        }

        public IDataResult<CctvGenelDizayn> Get(Expression<Func<CctvGenelDizayn, bool>> filter)
        {
            return new SuccessDataResult<CctvGenelDizayn>(_cctvGenelDizaynDal.Get(filter));
        }
    }
}
