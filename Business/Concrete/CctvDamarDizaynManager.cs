using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CctvDamarDizaynManager:ICctvDamarDizaynService
    {
        private ICctvDamarDizaynDal _cctvDamarDizaynDal;
        public CctvDamarDizaynManager(ICctvDamarDizaynDal cctvDamarDizaynDal)
        {
            _cctvDamarDizaynDal=cctvDamarDizaynDal;
        }
        public IResult add(CctvDamarDizayn kablo)
        {   
            _cctvDamarDizaynDal.Add(kablo);
            return new SuccessResult();
        }

        public IResult delete(CctvDamarDizayn kablo)
        {
            _cctvDamarDizaynDal.Delete(kablo);
            return new SuccessResult();
        }

        public IResult update(CctvDamarDizayn kablo)
        {
            _cctvDamarDizaynDal.Update(kablo);
            return new SuccessResult();
        }

        public IDataResult<List<CctvDamarDizayn>> GetAll(Expression<Func<CctvDamarDizayn, bool>>? filter = null)
        {
            return new SuccessDataResult<List<CctvDamarDizayn>>(_cctvDamarDizaynDal.GetAll(filter));
        }

        public IDataResult<CctvDamarDizayn> Get(Expression<Func<CctvDamarDizayn, bool>> filter)
        {
            return new SuccessDataResult<CctvDamarDizayn>(_cctvDamarDizaynDal.Get(filter));
        }
    }
}
