using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Base;

namespace Business.Concrete
{
    public class IsEmriManager : ManagerBase<IsEmriBase, IIsEmriDal>, IIsEmriService
    {
        public IsEmriManager(IIsEmriDal repository) : base(repository)
        {
        }
    }
}
