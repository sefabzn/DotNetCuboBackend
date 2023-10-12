using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Base;
using System.Linq.Expressions;

namespace DataAccess.Concrete.Entityframework
{
    public class EfGenelDizaynDal : EfEntityRepositoryBase<GenelDizaynBase, CuboContext>, IGenelDizaynDal
    {
        public GenelDizaynBase Get(Expression<Func<GenelDizaynBase, bool>> filter)
        {
            using (var context = new CuboContext())
            {
                return context.Set<GenelDizaynBase>().SingleOrDefault(filter);
            }
        }

    }
}
