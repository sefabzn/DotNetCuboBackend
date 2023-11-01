using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMakineKesitHizTablosuService : IServiceRepository<MakineKesitHizTablosu>
    {

        Task<IDataResult<IOrderedEnumerable<MakineKesitHizTablosu>>> GetAllByMakineIdAsync();
        Task<IDataResult<IEnumerable<double>>> GetAllByMakinesAsync(List<int> makineIdList);
    }
}
