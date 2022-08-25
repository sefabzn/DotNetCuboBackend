using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO_s;

namespace Business.Abstract
{
    public interface IMakineService: IServiceRepository<Makine>
    {
      
        IDataResult<List<MakineGunlukRaporDto>> GetGunlukRaporlar(string makineIsmi,DateTime tarih);
    }
}
