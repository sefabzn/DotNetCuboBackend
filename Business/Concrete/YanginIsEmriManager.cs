using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class YanginIsEmriManager : ManagerBase<YanginIsEmri, IYanginIsEmriDal>, IYanginIsEmriService
    {
        public YanginIsEmriManager(IYanginIsEmriDal repository) : base(repository)
        {
        }
    }
}
