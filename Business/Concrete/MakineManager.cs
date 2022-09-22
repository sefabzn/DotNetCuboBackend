﻿using System.Linq.Expressions;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;

namespace Business.Concrete
{
    public class MakineManager : ManagerBase<Makine, IMakineDal>, IMakineService
    {
        IMakineDal _makineDal;


        public MakineManager(IMakineDal dal) : base(dal)
        {
            _makineDal = dal;
        }
      
        [CacheAspect]
        public IDataResult<List<MakineGunlukRaporDto>> GetGunlukRaporlar(string makineIsmi, DateTime tarih)
        {
           return new SuccessDataResult<List<MakineGunlukRaporDto>>(_makineDal.getGunlukRapor(makineIsmi,tarih),"Günlük Rapor Getirildi");
        }

        public IDataResult<double> GetOrtalamaVerimlilik(List<KabloUretim> data)
        {

            return  new SuccessDataResult<double>(_makineDal.GetOrtalamaVerimlilik(data),"Verimlilik Hesaplandı");
        }
    }
}
