using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Concrete;
using Entities.DTO_s;

namespace DataAccess.Concrete.Entityframework
{
    public class EfMakineDal : EfEntityRepositoryBase<Makine, CuboContext>, IMakineDal
    {
        public List<MakineGunlukRaporDto> getGunlukRapor(string makineIsmi, DateTime firstDate,DateTime lastDate)
        {
            using (var context = new CuboContext())
            {
                var result = from makine in context.Makineler
                             join kabloUretim in context.KabloUretim
                                 on makine.Id equals kabloUretim.MakineId
                             where makine.MakineIsmi == makineIsmi && kabloUretim.Tarih>=firstDate && kabloUretim.Tarih<=lastDate
                             select new MakineGunlukRaporDto
                             {
                                 MakineIsmi = makine.MakineIsmi,
                                 KabloIsmi = kabloUretim.KabloIsmi,
                                 KesitAlani = kabloUretim.KesitCapi,
                                 Metraj = kabloUretim.Metraj,
                                 Kopma = kabloUretim.Kopma,
                                 KopmaKaybi = kabloUretim.Kopma * makine.Kopma,
                                 RenkDegisimi = kabloUretim.RenkDegisimi,
                                 RenkDegisimiKaybi = kabloUretim.RenkDegisimi * makine.RenkDegisimi,
                                 KesitDegisimiKaybi = makine.KesitDegisimi, //her kesit 1 kez kesit değişimi yapmış sayılır
                                 GenelAriza = kabloUretim.GenelAriza,
                                 HurdaPvc = kabloUretim.HurdaPvc,
                                 HurdaCu = kabloUretim.HurdaCu,
                                 CalismaSuresi = kabloUretim.CalismaSuresi,
                                 KayipZaman=kabloUretim.KayipZaman,
                                 Verimlilik=kabloUretim.Verimlilik,
                                 Isinma = makine.Isinma,
                                 Tarih = kabloUretim.Tarih
                             };

                
                return result.ToList();

            }
        }

      
    }
}
