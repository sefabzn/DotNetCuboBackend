using Core.Utilities.Results;
using System.Linq.Expressions;

namespace Core.Business
{
    public interface IServiceRepository<TEntity>
    {
        IDataResult<List<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter = null);
        IResult add(TEntity makinalar);
        IResult delete(TEntity makinalar);
        IResult update(TEntity makinalar);

        IDataResult<TEntity> Get(Expression<Func<TEntity, bool>> filter);

    }
}
