using DataAccess.Concrete.Entityframework.Contexts;

namespace AdminConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {


            using (var context = new CuboContext())
            {

                //var genelDizayn = context.CctvGenelDizayn.SingleOrDefault(x => x.Id == 3);

                //var isEmri = new IsEmriBase
                //{
                //    Isim = "console",
                //    GenelDizaynId = 3,
                //    GenelDizayn = genelDizayn
                //};
                //context.IsEmirleri.Add(isEmri);
                //context.SaveChanges();


                var isEmri1 = context.IsEmirleri.SingleOrDefault(x => x.Id == 4);

                var geneldizayn1 = isEmri1.GenelDizayn;

                var a = 2;


            }
        }


        public void updateDatabase()
        {



        }
    }
}