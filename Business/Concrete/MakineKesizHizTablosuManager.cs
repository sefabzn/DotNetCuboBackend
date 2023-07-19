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
    public class MakineKesizHizTablosuManager : ManagerBase<MakineKesitHizTablosu, IMakineKesitHizTablosuDal>, IMakineKesitHizTablosuService
    {
        IMakineKesitHizTablosuDal _makineKesitHizTablosuDal;
        public MakineKesizHizTablosuManager(IMakineKesitHizTablosuDal dal) : base(dal)
        {
            _makineKesitHizTablosuDal = dal;
        }

        public async Task<IDataResult<IOrderedEnumerable<MakineKesitHizTablosu>>> GetAllByMakineIdAsync()
        {
            var entities = await _makineKesitHizTablosuDal.GetAllAsync();
            var result =entities.OrderBy(x => x.MakineId);

            return new SuccessDataResult< IOrderedEnumerable<MakineKesitHizTablosu>>(result);
        }
    }
}
