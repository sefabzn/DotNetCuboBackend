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
using DataAccess.Concrete.Entityframework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CctvGenelDizaynManager : ManagerBase<CctvGenelDizayn, ICctvGenelDizaynDal>, ICctvGenelDizaynService
    {
        public CctvGenelDizaynManager(ICctvGenelDizaynDal dal) : base(dal)
        {
        }
    }
}
