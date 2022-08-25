using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class YanginGenelDizaynManager : ManagerBase<YanginGenelDizayn, IYanginGenelDizaynDal>, IYanginGenelDizaynService
    {
        public YanginGenelDizaynManager(IYanginGenelDizaynDal repository) : base(repository)
        {
        }
    }
}
