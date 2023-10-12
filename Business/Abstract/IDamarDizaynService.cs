using Core.Business;
using Core.Utilities.Results;
using Entities.Base;

namespace Business.Abstract
{
    public interface IDamarDizaynService : IServiceRepository<DamarDizaynBase>
    {
        IResult UpdateGenelDizaynDamarSayisi(int genelDizaynId);
    }
}
