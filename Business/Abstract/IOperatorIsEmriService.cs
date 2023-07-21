using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOperatorIsEmriService: IServiceRepository<OperatorIsEmri>
    {
        Task<Object> IsPlaniOlustur(OrtakIsEmri ortakIsEmri);
        Task<double?> TeorikSüreHesapla(OrtakIsEmri ortakIsEmri);
    }
   
}
