using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IYanginDamarDizaynService : IServiceRepository<YanginDamarDizayn>
    {
        IResult UpdateGenelDizaynDamarSayisi(int genelDizaynId);
    }
}
