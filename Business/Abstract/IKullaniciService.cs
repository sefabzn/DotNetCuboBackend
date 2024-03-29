﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IKullaniciService: IServiceRepository<Kullanici>
    {

      
        Task<IDataResult<List<OperationClaim>>> GetClaimsAsync(Kullanici kullanici);
        Task<IDataResult<Kullanici>> GetByKullaniciAdiAsync(string kullaniciAdi);
    }
}
