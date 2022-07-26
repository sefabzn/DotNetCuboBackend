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
    public interface ICctvGenelDizaynService
    {
        IResult add(CctvGenelDizayn kablo);
        IResult delete(CctvGenelDizayn kablo);
        IResult update(CctvGenelDizayn kablo);
        IDataResult<List<CctvGenelDizayn>> GetAll(Expression<Func<CctvGenelDizayn, bool>>? filter = null);
        IDataResult<CctvGenelDizayn> Get(Expression<Func<CctvGenelDizayn, bool>> filter);
    }
}
