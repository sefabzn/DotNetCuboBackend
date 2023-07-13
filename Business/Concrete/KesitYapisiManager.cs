using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class KesitYapisiManager : ManagerBase<KesitYapisi, IKesitYapisiDal>, IKesitYapisiService
    {
        IKesitYapisiDal _kesitYapisiDal;
        public KesitYapisiManager(IKesitYapisiDal dal) : base(dal)
        {
            _kesitYapisiDal = dal;
        }

        public async Task<IResult> CalculateAreaAndCoef(KesitYapisi kesitYapisi)
        {
            kesitYapisi.Alan = Math.PI * Math.Pow(kesitYapisi.KilcalDamarCapi / 2, 2) * kesitYapisi.KilcalDamarSayisi;
            kesitYapisi.Coef = 0.025;
            await _kesitYapisiDal.UpdateAsync(kesitYapisi);

            return new SuccessResult("Alan ve Coef hesaplandı");
        }

      
    }
}
