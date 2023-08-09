using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace DataAccess.Concrete.Entityframework.Contexts
{
    public class CuboContext:DbContext
    {
        public CuboContext()
        {
                
        }
        public CuboContext(DbContextOptions<CuboContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=EKMEKTEKNEM;Database=ProjectDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
            optionsBuilder.LogTo(Console.WriteLine); // To easily see SQL logs on console.
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OperatorIsEmri>().HasMany(o => o.Surecler)
                .WithOne(p=>p.OperatorIsEmri)
                .HasForeignKey(p=>p.IsEmriId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public  DbSet<CctvDamarDizayn> CctvDamarDizayn { get; set; }
        public DbSet<CctvGenelDizayn> CctvGenelDizayn { get; set; }
        public DbSet<CctvIsEmri> CctvIsEmirleri { get; set; }
        public DbSet<KabloUretim> KabloUretim { get; set; }
        public DbSet<KesitYapisi> KesitYapisi { get; set; }
        public DbSet<Makine> Makineler { get; set; }
        public DbSet<MakineKesitHizTablosu> MakineKesitHizTablosu { get; set; }
        public DbSet<OperatorIsEmri> OperatorIsEmirleri { get; set; }
        public DbSet<Sarfiyat> Sarfiyat { get; set; }
        public DbSet<SatisPlanlama> SatisPlanlama { get; set; }
        public DbSet<TekDamarDizayn> TekDamarDizayn { get; set; }
        public DbSet<TelefonDamarDizayn> TelefonDamarDizayn { get; set; }
        public DbSet<TelefonGenelDizayn> TelefonGenelDizayn { get; set; }
        public DbSet<TelefonIsEmri> TelefonIsEmirleri { get; set; }
        public DbSet<YanginDamarDizayn> YanginDamarDizayn { get; set; }
        public DbSet<YanginGenelDizayn> YanginGenelDizayn { get; set; }
        public DbSet<YanginIsEmri> YanginIsEmirleri { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims{ get; set; }

        public DbSet<Process> Processes { get; set; }
    }
}
