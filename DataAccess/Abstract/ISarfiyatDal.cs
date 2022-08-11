using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISarfiyatDal:IEntityRepository<Sarfiyat>
    {
    }
}
