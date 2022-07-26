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
    public interface IKabloUretimService
    {
        IResult add(KabloUretim kablo);
        IResult delete(KabloUretim kablo);
        IResult update(KabloUretim kablo);
        IDataResult<List<KabloUretim>>GetAll(Expression<Func<KabloUretim, bool>>? filter =null);
        IDataResult<KabloUretim> Get(Expression<Func<KabloUretim, bool>> filter);
    }
}
