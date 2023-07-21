using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;

namespace Business.Concrete
{
    public class OrderProcessManager : ManagerBase<OrderProcess, IOrderProcessDal>, IOrderProcessService
    {

        IOrderProcessDal _orderProcessDal;
        public OrderProcessManager(IOrderProcessDal repository) : base(repository)
        {
            _orderProcessDal = repository;
        }

        public  IResult GetTakip()
        {
            return  new SuccessDataResult<List<IsEmriTakipDto>>(_orderProcessDal.getTakip());
        }
    }
}
