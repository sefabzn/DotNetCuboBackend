using DataAccess.Concrete.Entityframework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AdminConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<CuboContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CuboDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");

            using (var context = new CuboContext(optionsBuilder.Options))
            {
                try
                {
                    context.Database.OpenConnection();
                    context.Database.CloseConnection();
                    Console.WriteLine("Connection successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Connection failed: {ex.Message}");
                }
            }
            //using (var context = new CuboContext())
            //{

            //    //var genelDizayn = context.CctvGenelDizayn.SingleOrDefault(x => x.Id == 3);

            //    //var isEmri = new IsEmriBase
            //    //{
            //    //    Isim = "console",
            //    //    GenelDizaynId = 3,
            //    //    GenelDizayn = genelDizayn
            //    //};
            //    //context.IsEmirleri.Add(isEmri);
            //    //context.SaveChanges();


            //    //var isEmri1 = context.IsEmirleri.SingleOrDefault(x => x.Id == 4);

            //    //var geneldizayn1 = isEmri1.GenelDizayn;

            //    //var a = 2;



            //}
        }


        public void updateDatabase()
        {



        }
    }
}