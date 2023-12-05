using Core.Business;
using Core.Utilities.Results;
using Entities.Base;
using Entities.Concrete;
using Entities.DTO_s;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IIsEmriService : IServiceRepository<IsEmriBase>
    {
        Task<Object> IsPlaniOlustur(OrtakIsEmri ortakIsEmri);
        Task<double?> TeorikSüreHesapla(OrtakIsEmri ortakIsEmri);
        Task<IDataResult<List<IsEmriTakipDto>>> GetAllIsEmriTakipDto(Expression<Func<IsEmriTakipDto, bool>>? filter = null);
        Task<IResult> AddWithControl(IsEmriBase isEmriBase);

    }
}
