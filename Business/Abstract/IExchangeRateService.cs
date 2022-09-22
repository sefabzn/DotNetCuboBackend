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
        IDataResult<double> GetDollarRate();
        IDataResult<double> GetEuroRate();

    }
}
