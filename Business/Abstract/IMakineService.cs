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
    public interface IMakineService
    {
        IDataResult<List<Makine>> GetAll();
        IResult add(Makine makineler);
        IResult delete(Makine Makine);
        IResult update(Makine Makine);

        IDataResult<Makine> Get(Expression<Func<Makine, bool>> filter);
    }
}
