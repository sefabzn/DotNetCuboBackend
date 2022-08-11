using Business.Abstract;
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
    public class SarfiyatManager : ISarfiyatService
    {
        ISarfiyatDal _sarfiyatDal;
        public SarfiyatManager(ISarfiyatDal sarfiyatDal)
        {
            _sarfiyatDal = sarfiyatDal;
        }

        public IResult add(Sarfiyat entity)
        {
            _sarfiyatDal.Add(entity);
            return new SuccessResult();
        }

        public IResult delete(Sarfiyat entity)
        {
            _sarfiyatDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Sarfiyat> Get(Expression<Func<Sarfiyat, bool>> filter)
        {
            return new SuccessDataResult<Sarfiyat>(_sarfiyatDal.Get(filter));
        }

        public IDataResult<List<Sarfiyat>> GetAll(Expression<Func<Sarfiyat, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Sarfiyat>>(_sarfiyatDal.GetAll(filter));
        }

        public IResult update(Sarfiyat entity)
        {
            _sarfiyatDal.Update(entity);
            return new SuccessResult();
        }
    }
}
