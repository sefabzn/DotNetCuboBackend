using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IKullaniciDal:IEntityRepository<Kullanici>
    {
        List<OperationClaim> GetClaims(Kullanici kullanici);
    }
}
