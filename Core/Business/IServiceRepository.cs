using Core.Utilities.Results;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public interface IServiceRepository<TEntity>
    {
        IDataResult<List<TEntity>> GetAll();
        IResult add(IValidator validator,TEntity makinalar);
        IResult delete(TEntity makinalar);
        IResult update(TEntity makinalar);

        IDataResult<TEntity> Get(Expression<Func<TEntity, bool>> filter);

    }
}
