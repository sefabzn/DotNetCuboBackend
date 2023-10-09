using Core.Business;
using Entities.Base;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IIsEmriService : IServiceRepository<IsEmriBase>
    {
        Task<Object> IsPlaniOlustur(OrtakIsEmri ortakIsEmri);
        Task<double?> TeorikSüreHesapla(OrtakIsEmri ortakIsEmri);
    }
}
