using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO_s;

namespace DataAccess.Abstract
{
    public interface IMakineDal : IEntityRepository<Makine>
    {
        Task<List<MakineGunlukRaporDto>> getRaporByDateRange(int makineId, DateTime fistDate, DateTime lastDate);
        Task<List<MakineGunlukRaporDto>> getRaporByDay(DateTime date);
    }
}
