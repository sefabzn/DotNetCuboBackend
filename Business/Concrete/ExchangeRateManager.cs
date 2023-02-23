using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ExchangeRateManager : IExchangeRateService
    {
        IExchangeRateDal _exchangeRateDal;
        public ExchangeRateManager(IExchangeRateDal exchangeRateDal)
        {
            _exchangeRateDal= exchangeRateDal;
        }

        public IDataResult<double> GetCopperRate()
        {
            return new SuccessDataResult<double>(_exchangeRateDal.GetCopperRate(), "Bakır/Dolar fiyatı getirildi");
        }

        public IDataResult<double> GetCopperRateByTL()
        {
            return new SuccessDataResult<double>(_exchangeRateDal.GetCopperRateByTL(), "Bakır/TL fiyatı getirildi");
        }

        public IDataResult<double> GetDollarRate()
        {
            return new SuccessDataResult<double>(_exchangeRateDal.GetDollarRate(),"Döviz Kuru Getirildi");
        }

        public IDataResult<double> GetEuroRate()
        {
            return new SuccessDataResult<double>(_exchangeRateDal.GetEuroRate(), "Döviz Kuru Getirildi");

        }

        public IDataResult<double> GetPVCRate()
        {
            throw new NotImplementedException();
        }
    }
}
