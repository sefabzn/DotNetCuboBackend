using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;

namespace Business.Concrete
{
    public class MakineKesizHizTablosuManager : ManagerBase<MakineKesitHizTablosu, IMakineKesitHizTablosuDal>, IMakineKesitHizTablosuService
    {
        IMakineKesitHizTablosuDal _makineKesitHizTablosuDal;
        public MakineKesizHizTablosuManager(IMakineKesitHizTablosuDal dal) : base(dal)
        {
            _makineKesitHizTablosuDal = dal;
        }

        public async Task<IDataResult<IOrderedEnumerable<MakineKesitHizTablosu>>> GetAllByMakineIdAsync()
        {
            var entities = await _makineKesitHizTablosuDal.GetAllAsync();
            var result = entities.OrderBy(x => x.MakineId);

            return new SuccessDataResult<IOrderedEnumerable<MakineKesitHizTablosu>>(result);
        }

        public async Task<IDataResult<IEnumerable<double>>> GetAllByMakinesAsync(List<int> makineIdList)
        {
            var kesitler = await _makineKesitHizTablosuDal.GetAllAsync();
            var ortakList = new List<KesitOrtakDto>();
            foreach (var kesit in kesitler)
            {
                var ortakListItem = ortakList.SingleOrDefault(ortakList => ortakList.KesitCapi == kesit.KesitCapi);
                if (ortakListItem is null)
                {
                    var newOrtakListItem = new KesitOrtakDto { KesitCapi = kesit.KesitCapi };
                    newOrtakListItem.makineIdleri.Add(kesit.MakineId);
                    ortakList.Add(newOrtakListItem);

                }
                else
                {
                    ortakListItem.makineIdleri.Add(kesit.MakineId);
                }
            }

            var result = new List<double>();

            foreach (var elem in ortakList)
            {
                if (!makineIdList.Except(elem.makineIdleri).Any())
                {
                    result.Add(elem.KesitCapi);
                }
            }
            return new SuccessDataResult<IEnumerable<double>>(result);


        }
    }
}
