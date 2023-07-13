using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO_s;

namespace DataAccess.Abstract
{
    public interface IMakineDal:IEntityRepository<Makine>
    {
        List<MakineGunlukRaporDto> getGunlukRapor(string makineIsmi, DateTime fistDate,DateTime lastDate);
       
    }
}
