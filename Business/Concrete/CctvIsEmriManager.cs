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
    public class CctvIsEmriManager : ICctvIsEmriService
    {
        ICctvIsEmriDal _cctvIsEmriDal;
        public CctvIsEmriManager(ICctvIsEmriDal cctvIsEmriDal)
        {
            _cctvIsEmriDal = cctvIsEmriDal;
        }
        public IResult add(CctvIsEmri kablo)
        {
            _cctvIsEmriDal.Add(kablo);
            return new SuccessResult();
        }

        public IResult delete(CctvIsEmri kablo)
        {
            _cctvIsEmriDal.Delete(kablo);
            return new SuccessResult();
        }

        public IDataResult<CctvIsEmri> Get(Expression<Func<CctvIsEmri, bool>> filter)
        {
            return new SuccessDataResult<CctvIsEmri>(_cctvIsEmriDal.Get(filter));
        }

        public IDataResult<List<CctvIsEmri>> GetAll(Expression<Func<CctvIsEmri, bool>>? filter = null)
        {
           return new SuccessDataResult<List<CctvIsEmri>>(_cctvIsEmriDal.GetAll(filter));
        }

        public IResult update(CctvIsEmri kablo)
        {
            _cctvIsEmriDal.Update(kablo);
            return new SuccessResult();
        }
    }
}
