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

        Task<IDataResult<double>> SetOrtalamaVerimlilik(int id);
        Task<IResult> SetOrtalamaVerimlilikForAll();
        Task<IDataResult<List<MakineGunlukRaporDto>>> GetGunlukRaporlarAsync(string makineIsmi,DateTime firstDate, DateTime lastDate);
    }
}
