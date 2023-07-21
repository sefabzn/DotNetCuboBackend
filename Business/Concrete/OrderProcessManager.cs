using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OrderProcessManager : ManagerBase<OrderProcess, IOrderProcessDal>, IOrderProcessService
    {
        public OrderProcessManager(IOrderProcessDal repository) : base(repository)
        {
        }
    }
}
