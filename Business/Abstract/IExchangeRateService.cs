using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public  interface IExchangeRateService
    {
       Task< IDataResult<decimal>> GetDollarRate();
        Task<IDataResult<decimal>> GetEuroRate();
        IDataResult<double> GetCopperRate();
        IDataResult<double> GetPVCRate();
        IDataResult<double> GetCopperRateByTL();

    }
}
