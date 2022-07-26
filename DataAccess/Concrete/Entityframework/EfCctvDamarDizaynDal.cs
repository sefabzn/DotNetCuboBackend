using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.Entityframework
{
    public class EfCctvDamarDizaynDal:EfEntityRepositoryBase<CctvDamarDizayn,CuboContext>,ICctvDamarDizaynDal
    {
    }
}
