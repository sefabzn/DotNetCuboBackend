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
        TDal _dal;
        public ManagerBase(TDal repository)
        {
            _dal = repository;
        }
        public IResult add(TEntity entity)
        {

            _dal.Add(entity);

            return new SuccessResult("Ürün Eklendi");
        }

        public IResult delete(TEntity makinalar)
        {
            _dal.Delete(makinalar);
            return new SuccessResult("Ürün Silindi");

        }

        public IDataResult<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            
            return new SuccessDataResult<TEntity>(_dal.Get(filter),"Ürün bulundu");
        }

      
        public IDataResult<List<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            return new SuccessDataResult<List<TEntity>>(_dal.GetAll(filter),"Ürünler Bulundu");
        }

        public IResult update(TEntity makinalar)
        {
            _dal.Update(makinalar);
            return new SuccessResult("Ürün Güncellendi");


        }
    }
}
