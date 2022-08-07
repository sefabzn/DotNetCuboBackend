using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaseService<T>
    {

        IResult add(T entity);
        IResult delete(T entity);
        IResult update(T entity);
        IDataResult<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);
        IDataResult<T> Get(Expression<Func<T, bool>> filter);


    }
}
