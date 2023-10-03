using Core.DataAccess;
using Core.Entities;
using Core.Utilities.Results;
using System.Linq.Expressions;

namespace Core.Business
{
    public class ManagerBase<TEntity, TDal> : IServiceRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TDal : IEntityRepository<TEntity>
    {
        TDal _dal;
        public ManagerBase(TDal repository)
        {
            _dal = repository;
        }
        //[MailAspect]
        public async Task<IResult> addAsync(TEntity entity)
        {

            await _dal.AddAsync(entity);

            return new SuccessResult("Ürün Eklendi");
        }

        public async Task<IResult> deleteAsync(TEntity makinalar)
        {
            await _dal.DeleteAsync(makinalar);
            return new SuccessResult("Ürün Silindi");

        }

        public async Task<IDataResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
        {

            return new SuccessDataResult<TEntity>(await _dal.GetAsync(filter), "Ürün bulundu");
        }


        public async Task<IDataResult<List<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            return new SuccessDataResult<List<TEntity>>(await _dal.GetAllAsync(filter), "Ürünler Bulundu");
        }

        public async Task<IResult> updateAsync(TEntity makinalar)
        {
            await _dal.UpdateAsync(makinalar);
            return new SuccessResult("Ürün Güncellendi");


        }


    }
}
