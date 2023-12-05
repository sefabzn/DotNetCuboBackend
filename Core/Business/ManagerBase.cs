using Core.Aspects.Autofac.Caching;
using Core.DataAccess;
using Core.Entities;
using Core.Utilities.Results;
using FluentValidation;
using FluentValidation.Results;
using System.Linq.Expressions;
namespace Core.Business
{
    public class ManagerBase<TEntity, TDal> : IServiceRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TDal : IEntityRepository<TEntity>
    {

        AbstractValidator<TEntity> _validator;
        TDal _dal;
        public ManagerBase(TDal repository, AbstractValidator<TEntity>? validator = null)
        {
            _dal = repository;
            _validator = validator;
        }
        //[MailAspect]
        public async Task<IResult> addAsync(TEntity entity)
        {

            if (_validator != null)
            {
                // Validator is provided, you can perform additional actions if needed.
                ValidationResult results = await _validator.ValidateAsync(entity);

                if (!results.IsValid)
                {
                    foreach (var failure in results.Errors)
                    {
                        return new ErrorResult("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }
            }

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

        [CacheAspect()]
        public async Task<IDataResult<List<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            return new SuccessDataResult<List<TEntity>>(await _dal.GetAllAsync(filter), "Ürünler Bulundu");
        }

        public async Task<IResult> updateAsync(TEntity entity)
        {

            if (_validator != null)
            {
                // Validator is provided, you can perform additional actions if needed.
                ValidationResult results = await _validator.ValidateAsync(entity);

                if (!results.IsValid)
                {
                    foreach (var failure in results.Errors)
                    {
                        return new ErrorResult("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }
            }
            await _dal.UpdateAsync(entity);
            return new SuccessResult("Ürün Güncellendi");


        }





    }
}
