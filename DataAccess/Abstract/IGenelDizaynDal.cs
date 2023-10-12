using Core.DataAccess;
using Entities.Base;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IGenelDizaynDal : IEntityRepository<GenelDizaynBase>
    {
        public GenelDizaynBase Get(Expression<Func<GenelDizaynBase, bool>> filter);
    }
}
