using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProcessManager : ManagerBase<Process, IProcessDal>, IProcessService
    {
        private readonly IProcessDal _processDal;
        private readonly IOperatorIsEmriDal _operatorIsEmriDal;

        public ProcessManager(IProcessDal processDal,IOperatorIsEmriDal operatorIsEmriService) : base(processDal)
        {
            _processDal= processDal;
            _operatorIsEmriDal = operatorIsEmriService;
        }

        public async Task<DataResult<OperatorIsEmri>> UpdateBarcodeAsync(int isEmriId,Process process)
        {
          var result = await _operatorIsEmriDal.GetAsync(x=>x.Id == isEmriId);

            var allProcesses = await _processDal.GetAllAsync(x => x.IsEmriId == isEmriId);

            var completedProcesses = allProcesses.Where(x => x.TamamlanmaDurumu == true).OrderBy(x=>x.Order).ToList();



            var countCompleted = allProcesses.Count;


            //if (String.IsNullOrEmpty(result.Barkod))
            //{
            //    result.Barkod = result.UrunIsmi + "-" + result.Tarih;
            //}
            result.Barkod = result.UrunIsmi + "-(" + result.Tarih.ToString("dd/MM/yy")+")";

            result.Barkod += "-(";
            foreach (var elem in completedProcesses)
            {
                result.Barkod += elem.Order + "-";
            }
            result.Barkod += ")/" + countCompleted.ToString();



            await _operatorIsEmriDal.UpdateAsync(result);

            return new SuccessDataResult<OperatorIsEmri>(result, "Barkod Değişti ");
        }
    }
}
