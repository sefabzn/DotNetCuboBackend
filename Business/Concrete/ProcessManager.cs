using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProcessManager : ManagerBase<Process, IProcessDal>, IProcessService
    {
        private readonly IProcessDal _processDal;
        private readonly IIsEmriDal _isEmriDal;
        private readonly IBarkodDaL _barkodDaL;

        public ProcessManager(IProcessDal processDal, IIsEmriDal isEmriDal, IBarkodDaL barkodDaL) : base(processDal)
        {
            _processDal = processDal;
            _isEmriDal = isEmriDal;
            _barkodDaL = barkodDaL;
        }

        public async Task<DataResult<Barkod>> UpdateBarcodeAsync(int isEmriId)

        {
            var isEmri = await _isEmriDal.GetAsync(x => x.Id == isEmriId);



            var barkod = await _barkodDaL.GetAsync(x => x.IsEmriId == isEmriId);

            if (barkod == null)
            {
                barkod = new Barkod();
                barkod.IsEmriId = isEmriId;
                barkod.BarkodString = "No Barcode";
                await _barkodDaL.AddAsync(barkod);

                barkod = await _barkodDaL.GetAsync(x => x.IsEmriId == isEmriId);
            }

            var allProcesses = await _processDal.GetAllAsync(x => x.IsEmriId == isEmriId);

            var completedProcesses = allProcesses.Where(x => x.TamamlanmaDurumu == true).OrderBy(x => x.Order).ToList();



            var countAll = allProcesses.Count;


            barkod.BarkodString = isEmri.Isim + "-(" + isEmri.Tarih.ToString("dd/MM/yy") + ")";

            barkod.BarkodString += "-";
            foreach (var elem in completedProcesses)
            {
                barkod.BarkodString += elem.Order + ";";
            }
            barkod.BarkodString += "/" + countAll.ToString();


            await _barkodDaL.UpdateAsync(barkod);

            return new SuccessDataResult<Barkod>(barkod, "Barkod Değişti ");
        }

    }
}
