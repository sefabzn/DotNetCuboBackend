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
    public interface ICctvIsEmriService
    {
        IResult add(CctvIsEmri kablo);
        IResult delete(CctvIsEmri kablo);
        IResult update(CctvIsEmri kablo);
        IDataResult<List<CctvIsEmri>> GetAll(Expression<Func<CctvIsEmri, bool>>? filter = null);
        IDataResult<CctvIsEmri> Get(Expression<Func<CctvIsEmri, bool>> filter);
    }
}
