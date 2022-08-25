using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CctvIsEmriManager : ManagerBase<CctvIsEmri, ICctvIsEmriDal>, ICctvIsEmriService
    {
        public CctvIsEmriManager(ICctvIsEmriDal dal) : base(dal)
        {
        }
    }
}
