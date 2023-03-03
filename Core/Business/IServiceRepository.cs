using Core.Utilities.Results;
using System.Linq.Expressions;

namespace Core.Business
{
    public interface IServiceRepository<TEntity>
    {
        Task<IDataResult<List<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null);
        Task<IResult> addAsync(TEntity makinalar);
        Task<IResult> deleteAsync(TEntity makinalar);
        Task<IResult> updateAsync(TEntity makinalar);

        Task<IDataResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter);

    }
}
