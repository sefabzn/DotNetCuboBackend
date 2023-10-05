﻿using Core.Entities.Concrete;
using Entities.Base;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Concrete.Entityframework.Contexts
{
    public class CuboContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
        UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public CuboContext()
        {

        }
        public CuboContext(DbContextOptions<CuboContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CuboDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
            optionsBuilder.LogTo(Console.WriteLine); // To easily see SQL logs on console.
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles");


            modelBuilder.Entity<Process>()
                .HasOne(p => p.IsEmri)
                .WithMany(o => o.Surecler)
                .HasForeignKey(p => p.IsEmriId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GenelDizaynBase>()
              .HasOne(d => d.IsEmri)
              .WithOne(i => i.GenelDizayn)
              .HasForeignKey<IsEmriBase>(i => i.GenelDizaynId);

            modelBuilder.Entity<GenelDizaynBase>()
            .HasMany(g => g.Damarlar)
            .WithOne(d => d.GenelDizayn)
            .HasForeignKey(d => d.GenelDizaynId)
            .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<User>()
              .HasMany(u => u.UserRoles)
              .WithOne(ur => ur.User)
              .HasForeignKey(u => u.UserId)
              .IsRequired();

            modelBuilder.Entity<Role>()
               .HasMany(r => r.UserRoles)
               .WithOne(ur => ur.Role)
               .HasForeignKey(r => r.RoleId)
               .IsRequired();


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<KabloUretim> KabloUretim { get; set; }
        public DbSet<KesitYapisi> KesitYapisi { get; set; }
        public DbSet<Makine> Makineler { get; set; }
        public DbSet<MakineKesitHizTablosu> MakineKesitHizTablosu { get; set; }
        public DbSet<OperatorIsEmri> OperatorIsEmirleri { get; set; }
        public DbSet<Sarfiyat> Sarfiyat { get; set; }
        public DbSet<SatisPlanlama> SatisPlanlama { get; set; }
        public DbSet<TekDamarDizayn> TekDamarDizayn { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<IsEmriBase> IsEmirleri { get; set; }
        public DbSet<Process> Processes { get; set; }

    }
}
