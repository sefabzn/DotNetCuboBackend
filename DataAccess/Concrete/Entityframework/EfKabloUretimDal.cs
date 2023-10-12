using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Tls;

namespace DataAccess.Concrete.Entityframework
{
    public class EfKabloUretimDal : EfEntityRepositoryBase<KabloUretim, CuboContext>, IKabloUretimDal
    {
      

      
        public async Task AddManyAsync(List<KabloUretim> kabloUretims)
        {

            using (CuboContext context = new CuboContext())
            {
                await context.KabloUretim.AddRangeAsync(kabloUretims);
               
                await context.SaveChangesAsync();
            }
        }
    }
}
