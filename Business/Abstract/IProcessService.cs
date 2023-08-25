using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProcessService : IServiceRepository<Process>
    {
        Task<DataResult<OperatorIsEmri>> UpdateBarcodeAsync(int isEmriId,Process process);


    }
}
