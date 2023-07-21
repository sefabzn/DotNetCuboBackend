using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Concrete;
using Entities.DTO_s;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entityframework
{
    public class EfOrderProcessDal : EfEntityRepositoryBase<OrderProcess, CuboContext>, IOrderProcessDal
    {
       
        public List<IsEmriTakipDto> getTakip()
        {
            using (var context = new CuboContext())
            {
                var result = from orderProcess in context.OrderProcesses
                             join process in context.Processes
                                 on orderProcess.ProcessId equals process.Id
                             join isEmri in context.OperatorIsEmirleri
                                 on orderProcess.OrderId equals isEmri.Id
                             select new IsEmriTakipDto
                             {
                                 UrunIsmi = isEmri.UrunIsmi,
                                 ProcessName = process.ProcessName,
                                 isCompleted = orderProcess.isCompleted
                             };

                return result.ToList();
            }

        }
    }
}
