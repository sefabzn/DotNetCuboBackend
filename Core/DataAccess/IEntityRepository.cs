using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:IEntity
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null); //filtre girilmeyebilir

        Task<T> GetAsync(Expression<Func<T,bool>> filter);//filtre girmek zorunlu

        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
