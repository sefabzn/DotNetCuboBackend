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
    public class TelefonDamarDizaynManager : ManagerBase<TelefonDamarDizayn, ITelefonDamarDizaynDal>, Abstract.ITelefonDamarDizaynService
    {
        public TelefonDamarDizaynManager(ITelefonDamarDizaynDal repository) : base(repository)
        {
        }
    }
}
