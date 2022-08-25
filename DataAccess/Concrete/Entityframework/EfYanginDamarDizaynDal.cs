using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entityframework
{
    public class EfYanginDamarDizaynDal:EfEntityRepositoryBase<YanginDamarDizayn,CuboContext>,IYanginDamarDizaynDal
    {
    }
}
