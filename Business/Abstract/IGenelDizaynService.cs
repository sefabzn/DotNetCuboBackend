using Core.Business;
using Core.Utilities.Results;
using Entities.Base;

namespace Business.Abstract
{
    public interface IGenelDizaynService : IServiceRepository<GenelDizaynBase>
    {
        public Task<DataResult<GenelDizaynBase>> GetByIdAsync(int id);
        public Task<DataResult<List<GenelDizaynBase>>> GetAllByDateAsync(DateTime tarih);
        public Task<DataResult<List<GenelDizaynBase>>> GetAllByTurAsync(string tur);
    }
}
