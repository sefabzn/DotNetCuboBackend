using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CctvDamarDizaynManager : ManagerBase<CctvDamarDizayn, ICctvDamarDizaynDal>, ICctvDamarDizaynService
    {
        ICctvGenelDizaynDal _cctvGenelDizaynDal;
        ICctvDamarDizaynDal _cctvDamarDizaynDal;
        public CctvDamarDizaynManager(ICctvDamarDizaynDal dal, ICctvGenelDizaynDal cctvGenelDizaynDal) : base(dal)
        {
            _cctvGenelDizaynDal = cctvGenelDizaynDal;
            _cctvDamarDizaynDal = dal;
        }

        public IResult UpdateGenelDizaynDamarSayisi(int  genelDizaynId)
        {
            var genelDizaynKablo =_cctvGenelDizaynDal.GetAsync(x => x.Id == genelDizaynId).Result;

            var damarSayisi= _cctvDamarDizaynDal.GetAllAsync(x=>x.AnaId==genelDizaynId).Result.Count;

            genelDizaynKablo.GirilenDamarSayisi = damarSayisi;

            _cctvGenelDizaynDal.UpdateAsync(genelDizaynKablo);

            return new SuccessResult("Damar Sayısı Güncellendi");
        }
    }
}
