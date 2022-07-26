using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IKullaniciService
    {

        IDataResult<List<Kullanici>> GetAll(Expression<Func<Kullanici, bool>> filter = null);
        IResult add(Kullanici kullanici);
        IResult delete(Kullanici kullanici);
        IResult update(Kullanici kullanici);

        IDataResult<Kullanici> Get(Expression<Func<Kullanici, bool>> filter);
        IDataResult<List<OperationClaim>> GetClaims(Kullanici kullanici);
        IDataResult<Kullanici> GetByKullaniciAdi(string kullaniciAdi);
    }
}
