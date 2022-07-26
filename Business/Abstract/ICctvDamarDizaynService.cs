using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICctvDamarDizaynService
    {
        IResult add(CctvDamarDizayn kablo);
        IResult delete(CctvDamarDizayn kablo);
        IResult update(CctvDamarDizayn kablo);
        IDataResult<List<CctvDamarDizayn>> GetAll(Expression<Func<CctvDamarDizayn, bool>>? filter = null);
        IDataResult<CctvDamarDizayn> Get(Expression<Func<CctvDamarDizayn, bool>> filter);
    }
}
