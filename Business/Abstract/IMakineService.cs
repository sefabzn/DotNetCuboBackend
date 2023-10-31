using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO_s;

namespace Business.Abstract
{
    public interface IMakineService : IServiceRepository<Makine>
    {

        Task<IDataResult<double>> SetOrtalamaVerimlilik(int id);
        Task<IResult> SetOrtalamaVerimlilikForAll();
        Task<IDataResult<List<MakineGunlukRaporDto>>> getRaporByDateRangeAsync(int makineId, DateTime firstDate, DateTime lastDate);
    }
}
