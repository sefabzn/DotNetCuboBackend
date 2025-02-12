using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Concrete;

public class EfCustomerDal : EfEntityRepositoryBase<Musteri, CuboContext>, ICustomerDal
{
}
