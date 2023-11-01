using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Base;
using Entities.Concrete;
using Entities.DTO_s;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.Entityframework
{
    public class EfIsEmriDal : EfEntityRepositoryBase<IsEmriBase, CuboContext>, IIsEmriDal
    {
        public async Task<Barkod> GetBarkodAsync(int isEmriId)
        {
            using (var context = new CuboContext())
            {

                var barkod = await context.Barkods.SingleAsync(x => x.IsEmriId == isEmriId);
                return barkod;
            }


        }
        public async Task<List<IsEmriTakipDto>> GetAllIsEmriTakipAsync(Expression<Func<IsEmriTakipDto, bool>> filter = null)
        {
            using (var context = new CuboContext())
            {

                //get isemirleri with their barkod
                var isemirleri = from isEmri in context.IsEmirleri
                                 join barkod in context.Barkods
                                 on isEmri.Id equals barkod.IsEmriId
                                 select new IsEmriTakipDto
                                 {
                                     Isim = isEmri.Isim,
                                     Barkod = barkod.BarkodString,
                                     Tur = isEmri.Tur,
                                     Metraj = isEmri.Metraj,
                                     TamamlanmaDurumu = isEmri.TamamlanmaDurumu,
                                     MakineIsmi = isEmri.MakineIsmi,
                                     Tarih = isEmri.Tarih,
                                     Degistiren = isEmri.Degistiren,

                                 };
                return filter == null
                     ? await isemirleri.ToListAsync()
                     : await isemirleri.Where(filter).ToListAsync();


            }


        }
    }
}
