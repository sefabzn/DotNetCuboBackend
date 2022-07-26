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
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //filtre girilmeyebilir

        T Get(Expression<Func<T,bool>> filter);//filtre girmek zorunlu

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
