using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOperatorIsEmriService
    {
        IResult add(OperatorIsEmri kablo);
        IResult delete(OperatorIsEmri kablo);
        IResult update(OperatorIsEmri kablo);
        IDataResult<List<OperatorIsEmri>> GetAll(Expression<Func<OperatorIsEmri, bool>>? filter = null);
        IDataResult<OperatorIsEmri> Get(Expression<Func<OperatorIsEmri, bool>> filter);
    }
}
