using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Base;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProcessManager : ManagerBase<Process, IProcessDal>, IProcessService
    {
        private readonly IProcessDal _processDal;
        private readonly IIsEmriDal _isEmriDal;

        public ProcessManager(IProcessDal processDal, IIsEmriDal isEmriDal) : base(processDal)
        {
            _processDal = processDal;
            _isEmriDal = isEmriDal;
        }

        public async Task<DataResult<IsEmriBase>> UpdateBarcodeAsync(int isEmriId)
        {
            var result = await _isEmriDal.GetAsync(x => x.Id == isEmriId);

            var allProcesses = await _processDal.GetAllAsync(x => x.IsEmriId == isEmriId);

            var completedProcesses = allProcesses.Where(x => x.TamamlanmaDurumu == true).OrderBy(x => x.Order).ToList();



            var countAll = allProcesses.Count;


            //if (String.IsNullOrEmpty(result.Barkod))
            //{
            //    result.Barkod = result.UrunIsmi + "-" + result.Tarih;
            //}
            result.Barkod = result.Isim + "-(" + result.Tarih.ToString("dd/MM/yy") + ")";

            result.Barkod += "-";
            foreach (var elem in completedProcesses)
            {
                result.Barkod += elem.Order + ";";
            }
            result.Barkod += "/" + countAll.ToString();



            await _isEmriDal.UpdateAsync(result);

            return new SuccessDataResult<IsEmriBase>(result, "Barkod Değişti ");
        }
        public async Task<DataResult<IsEmriBase>> UpdateBarcodeAtCreateAsync(int isEmriId)
        {
            var result = await _isEmriDal.GetAsync(x => x.Id == isEmriId);



            result.Barkod = result.Isim + "-(" + result.Tarih.ToString("dd/MM/yy") + ")";




            await _isEmriDal.UpdateAsync(result);

            return new SuccessDataResult<IsEmriBase>(result, "Barkod Değişti ");
        }
    }
}
