using Core.Business;
using Core.Utilities.Results;
using Entities.Base;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProcessService : IServiceRepository<Process>
    {
        Task<DataResult<IsEmriBase>> UpdateBarcodeAsync(int isEmriId, Process process);
        Task<DataResult<IsEmriBase>> UpdateBarcodeAtCreateAsync(int isEmriId);


    }
}
