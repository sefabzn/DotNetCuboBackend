using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Base;

namespace DataAccess.Concrete.Entityframework
{
    public class EfIsEmriDal : EfEntityRepositoryBase<IsEmriBase, CuboContext>, IIsEmriDal
    {
    }
}
