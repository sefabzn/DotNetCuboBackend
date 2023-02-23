namespace DataAccess.Abstract
{
    public interface IExchangeRateDal
    {
        double GetDollarRate();
        double GetEuroRate();
        double GetCopperRate();
        double GetPVCRate();
        double GetCopperRateByTL();
    }

}
