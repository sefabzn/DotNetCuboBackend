
using DataAccess.Concrete.Entityframework;
using Entities.Concrete;

KabloUretim uretim = new KabloUretim
{
    KabloIsmi = "BAŞARILI ÜRÜN"
};

EfKabloUretimDal dal = new EfKabloUretimDal();
dal.Add(uretim);