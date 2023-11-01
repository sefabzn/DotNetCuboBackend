using Core.DataAccess;
using Entities.Base;
using Entities.Concrete;
using Entities.DTO_s;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IIsEmriDal : IEntityRepository<IsEmriBase>
    {
        Task<Barkod> GetBarkodAsync(int barkodId);
        Task<List<IsEmriTakipDto>> GetAllIsEmriTakipAsync(Expression<Func<IsEmriTakipDto, bool>> filter = null);


    }
}
