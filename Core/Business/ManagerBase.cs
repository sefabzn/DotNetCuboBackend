using Core.CrossCuttingConcern.Validation;
using Core.DataAccess;
using Core.Entities;
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
    public class ManagerBase<TEntity,TDal> : IServiceRepository<TEntity>
        where TEntity : class, IEntity,new()
        where TDal : IEntityRepository<TEntity>
    {
        TDal _repository;
        public ManagerBase(TDal repository)
        {
            _repository = repository;
        }
        public IResult add(IValidator validator,TEntity entity)
        {

            ValidationTool.Validate(validator, entity);

            _repository.Add(entity);

            return new SuccessResult("Ürün Eklendi");
        }

        public IResult delete(TEntity makinalar)
        {
            _repository.Delete(makinalar);
            return new SuccessResult("Ürün Silindi");

        }

        

        public IDataResult<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            if (DateTime.Now.Hour==19)
            {
                return new ErrorDataResult<TEntity>("Ürün Bulunamadı");
            }
            return new SuccessDataResult<TEntity>(_repository.Get(filter),"Ürün bulundu");
        }

        public IDataResult<List<TEntity>> GetAll()
        {
            return new DataResult<List<TEntity>>(_repository.GetAll(),true,"Ürünler Listelendi");
        }

       

        public IResult update(TEntity makinalar)
        {
            _repository.Update(makinalar);
            return new SuccessResult("Ürün Güncellendi");


        }
    }
}
