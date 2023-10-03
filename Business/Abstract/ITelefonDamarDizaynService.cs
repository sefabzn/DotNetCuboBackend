using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ITelefonDamarDizaynService : IServiceRepository<TelefonDamarDizayn>
    {
        IResult UpdateGenelDizaynDamarSayisi(int genelDizaynId);
    }
}
