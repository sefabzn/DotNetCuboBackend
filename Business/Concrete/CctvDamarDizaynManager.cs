using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CctvDamarDizaynManager : ManagerBase<CctvDamarDizayn, ICctvDamarDizaynDal>, ICctvDamarDizaynService
    {
        public CctvDamarDizaynManager(ICctvDamarDizaynDal dal) : base(dal)
        {
        }
    }
}
