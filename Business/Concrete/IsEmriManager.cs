using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Base;
using Entities.Concrete;
using Entities.DTO_s;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class IsEmriManager : ManagerBase<IsEmriBase, IIsEmriDal>, IIsEmriService
    {
        IMakineDal _makineDal;
        IIsEmriDal _isEmriDal;
        IMakineKesitHizTablosuDal _kesitHizTablosuDal;
        IGenelDizaynDal _genelDizaynDal;
        public IsEmriManager(IMakineKesitHizTablosuDal kesitHizTablosuDal, IMakineDal makineDal, IIsEmriDal isEmriDal, IGenelDizaynDal genelDizaynDal) : base(isEmriDal)
        {
            _kesitHizTablosuDal = kesitHizTablosuDal;
            _makineDal = makineDal;
            _isEmriDal = isEmriDal;
            _genelDizaynDal = genelDizaynDal;
        }

        public async Task<IResult> AddToDamarDizayn(IsEmriBase isEmri, int damarDizaynId)
        {
            using (var context = new CuboContext())
            {

                var damarDizayn = await context.DamarDizaynBase.SingleOrDefaultAsync(x => x.Id == damarDizaynId);

                var isEmriDamarDizayn = new IsEmriDamarDizayn
                {
                    IsEmriId = isEmri.Id,
                    IsEmri = isEmri,
                    DamarDizayn = damarDizayn,
                    DamarDizaynId = damarDizayn.Id
                };
                await context.IsEmriDamarDizayns.(isEmriDamarDizayn);

                return new SuccessResult("");
            }
        }

        public async Task<IResult> AddToGenelDizayn(IsEmriBase isEmri, int genelDizaynId)
        {
            using (var context = new CuboContext())
            {

                var genelDizayn = await context.GenelDizaynBase.SingleOrDefaultAsync(x => x.Id == genelDizaynId);

                var isEmriGenelDizayn = new IsEmriGenelDizayn
                {
                    IsEmriId = isEmri.Id,
                    IsEmri = isEmri,
                    GenelDizayn = genelDizayn,
                    GenelDizaynId = genelDizayn.Id
                };
                await context.IsEmriGenelDizayns.AddAsync(isEmriGenelDizayn);

                return new SuccessResult("");
            }
        }

        public async Task<IResult> AddWithControl(IsEmriBase isEmriBase, int genelDizaynId, int damarDizaynId)
        {
            var makine = await _makineDal.GetAsync(x => x.Id == isEmriBase.MakineId);
            var verimlilik = makine.Verimlilik;

            if (verimlilik <= 0.4 && isEmriBase.Metraj >= 150000)
            {
                return new ErrorResult("Verimsiz makine için metraj 200000 den fazla olamaz");
            }

            await _isEmriDal.AddAsync(isEmriBase);
            await AddToGenelDizayn(isEmriBase, genelDizaynId);
            await AddToGenelDizayn(isEmriBase, damarDizaynId);

            return new SuccessResult("İş Emri Eklendi");
        }


        public async Task<IResult> AddWithControl(IsEmriBase isEmriBase)
        {
            var makine = await _makineDal.GetAsync(x => x.Id == isEmriBase.MakineId);
            var verimlilik = makine.Verimlilik;

            if (verimlilik <= 0.4 && isEmriBase.Metraj >= 150000)
            {
                return new ErrorResult("Verimsiz makine için metraj 200000 den fazla olamaz");
            }

            await _isEmriDal.AddAsync(isEmriBase);


            return new SuccessResult("İş Emri Eklendi");
        }
        public async Task<IDataResult<List<IsEmriTakipDto>>> GetAllIsEmriTakipDto(Expression<Func<IsEmriTakipDto, bool>>? filter = null)
        {

            var result = await _isEmriDal.GetAllIsEmriTakipAsync(filter);

            return new SuccessDataResult<List<IsEmriTakipDto>>(result, "İş Emirleri Getirildi");
        }

        public async Task<Object> IsPlaniOlustur(OrtakIsEmri ortakIsEmri, int genelDizaynId, int damarDizaynId)
        {
            List<Makine> makines = (from isim in ortakIsEmri.MakineIsimleri
                                    select _makineDal.GetAsync(x => x.MakineIsmi == isim).Result).ToList();
            var kesitBilgisi = await _kesitHizTablosuDal.GetAllAsync();

            double? toplamVerimlilik = 0;

            foreach (var makine in makines)
            {
                toplamVerimlilik += makine.Verimlilik;
            }

            var ortalamaVerimlilik = toplamVerimlilik / makines.Count();

            List<Object> liste = new List<object>();
            foreach (var makine in makines)
            {
                var isEmri = new IsEmriBase()
                {
                    Isim = ortakIsEmri.UrunIsmi,
                    Tur = ortakIsEmri.DizaynTuru,
                    Metraj = Convert.ToDouble(ortakIsEmri.Metraj * (makine.Verimlilik / toplamVerimlilik)),
                    MakineId = makine.Id,
                    Degistiren = ortakIsEmri.Degistiren,
                    Tarih = ortakIsEmri.Tarih
                };


                liste.Add(isEmri);
                await _isEmriDal.AddAsync(isEmri);
                await AddToGenelDizayn(isEmri, genelDizaynId);
                await AddToDamarDizayn(isEmri, damarDizaynId);
            }

            return (liste);
        }

        public async Task<double?> TeorikSüreHesapla(OrtakIsEmri ortakIsEmri)
        {
            List<Makine> makines = new List<Makine>();
            foreach (var isim in ortakIsEmri.MakineIsimleri)
            {
                makines.Add(_makineDal.GetAsync(x => x.MakineIsmi == isim).Result);

            }


            var kesitBilgisi = await _kesitHizTablosuDal.GetAllAsync();

            var toplamHiz = 0;
            double? toplamVerimlilik = 0;

            foreach (var makine in makines)
            {
                toplamHiz += kesitBilgisi.Single(x => x.MakineId == makine.Id && x.KesitCapi == ortakIsEmri.Kesit).Hiz;
                toplamVerimlilik += makine.Verimlilik;
            }

            var ortalamaVerimlilik = toplamVerimlilik / makines.Count();

            var teorikTahminiSüre = (ortakIsEmri.Metraj / (toplamHiz * 60)) / (ortalamaVerimlilik);



            return (teorikTahminiSüre);//saat cinsinden
        }

    }
}
