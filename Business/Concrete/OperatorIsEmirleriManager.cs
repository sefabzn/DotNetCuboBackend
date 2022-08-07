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
    public class OperatorIsEmriManager : IOperatorIsEmriService
    {
        IOperatorIsEmriDal _operatorIsEmriDal;
        public OperatorIsEmriManager(IOperatorIsEmriDal operatorIsEmriDal)
        {
            _operatorIsEmriDal=operatorIsEmriDal;
        }
        public IResult add(OperatorIsEmri kablo)
        {
            _operatorIsEmriDal.Add(kablo);
            return new SuccessResult(); 
        }

        public IResult delete(OperatorIsEmri kablo)
        {

            _operatorIsEmriDal.Delete(kablo);
            return new SuccessResult();
        }

        public IDataResult<OperatorIsEmri> Get(Expression<Func<OperatorIsEmri, bool>> filter)
        {
            return new SuccessDataResult<OperatorIsEmri>(_operatorIsEmriDal.Get(filter));
        }

        public IDataResult<List<OperatorIsEmri>> GetAll(Expression<Func<OperatorIsEmri, bool>>? filter = null)
        {
            return new SuccessDataResult<List<OperatorIsEmri>>(_operatorIsEmriDal.GetAll(filter));
        }

        public IResult update(OperatorIsEmri kablo)
        {

            _operatorIsEmriDal.Update(kablo);
            return new SuccessResult();
        }
    }
}
