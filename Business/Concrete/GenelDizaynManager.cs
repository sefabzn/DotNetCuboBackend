using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Base;

namespace Business.Concrete
{
    public class GenelDizaynManager : ManagerBase<GenelDizaynBase, IGenelDizaynDal>, IGenelDizaynService
    {
        IGenelDizaynDal _genelDizaynDal;
        public GenelDizaynManager(IGenelDizaynDal genelDizaynDal) : base(genelDizaynDal)
        {

            _genelDizaynDal = genelDizaynDal;
        }

        public async Task<DataResult<List<GenelDizaynBase>>> GetAllByDateAsync(DateTime tarih)
        {
            return new SuccessDataResult<List<GenelDizaynBase>>(await _genelDizaynDal.GetAllAsync(x => x.Tarih == tarih));
        }

        public async Task<DataResult<List<GenelDizaynBase>>> GetAllByTurAsync(string tur)
        {
            var result = await _genelDizaynDal.GetAllAsync(x => x.Tur == tur);

            return new SuccessDataResult<List<GenelDizaynBase>>(result);
        }

        public async Task<DataResult<GenelDizaynBase>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<GenelDizaynBase>(await _genelDizaynDal.GetAsync(x => x.Id == id));
        }
    }
}
