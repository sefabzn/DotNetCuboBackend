using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.Entityframework
{
    public class EfBarkodDal : EfEntityRepositoryBase<Barkod, CuboContext>, IBarkodDaL
    {


    }
}
