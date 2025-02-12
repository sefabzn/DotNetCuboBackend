using Core.Business;
using Entities.Concrete;

public class CustomerManager : ManagerBase<Musteri, ICustomerDal>, ICustomerService
{
    public CustomerManager(ICustomerDal customerDal) : base(customerDal)
    {
    }
}
