using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Base;

namespace Business.Concrete
{
    public class GenelDizaynManager : ManagerBase<GenelDizaynBase, IGenelDizaynDal>, IGenelDizaynService
    {
        public GenelDizaynManager(IGenelDizaynDal repository) : base(repository)
        {
        }
    }
}
