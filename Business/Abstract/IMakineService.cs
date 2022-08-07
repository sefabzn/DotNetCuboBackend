using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO_s;

namespace Business.Abstract
{
    public interface IMakineService
    {
        IDataResult<List<Makine>> GetAll();
        IResult Add(Makine makineler);
        IResult Delete(Makine Makine);
        IResult Update(Makine Makine);
        IDataResult<List<MakineGunlukRaporDto>> GetGunlukRaporlar(string makineIsmi,DateTime tarih);
        IDataResult<Makine> Get(Expression<Func<Makine, bool>> filter);
    }
}
