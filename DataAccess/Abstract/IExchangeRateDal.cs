namespace DataAccess.Abstract
{
    public interface IExchangeRateDal
    {
        Task <decimal> GetDollarRate();
        Task<decimal>GetEuroRate();
        double GetCopperRate();
        double GetPVCRate();
        double GetCopperRateByTL();
    }

}
