using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProcessService : IServiceRepository<Process>
    {
        Task<DataResult<Barkod>> UpdateBarcodeAsync(int isEmriId);


    }
}
