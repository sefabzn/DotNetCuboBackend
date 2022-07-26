using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Entityframework
{
    public class EfKabloUretimDal:EfEntityRepositoryBase<KabloUretim,CuboContext>,IKabloUretimDal
    {
        
    }
}
