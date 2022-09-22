using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entityframework
{
    public class EfExchangeRateDal : IExchangeRateDal
    {
        public double GetDollarRate()
        {
            return 18;
        }

        public double GetEuroRate()
        {
            return 20;
        }
    }
}
