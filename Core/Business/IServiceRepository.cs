using Core.Utilities.Results;
using System.Linq.Expressions;

namespace Core.Business
{
    public interface IServiceRepository<TEntity>
    {
        Task<IDataResult<List<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null);
        Task<IResult> addAsync(TEntity entity);
        Task<IResult> deleteAsync(TEntity entity);
        Task<IResult> updateAsync(TEntity entity);

        Task<IDataResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter);

    }
}
