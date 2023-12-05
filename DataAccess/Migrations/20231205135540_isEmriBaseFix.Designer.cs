﻿// <auto-generated />
using System;
using DataAccess.Concrete.Entityframework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(CuboContext))]
    [Migration("20231205135540_isEmriBaseFix")]
    partial class isEmriBaseFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Concrete.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims");
                });

            modelBuilder.Entity("Core.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OperationId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserOperationClaims");
                });

            modelBuilder.Entity("Entities.Base.DamarDizaynBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Ayna")
                        .HasColumnType("float");

                    b.Property<double>("Back")
                        .HasColumnType("float");

                    b.Property<double>("Cap")
                        .HasColumnType("float");

                    b.Property<int>("DamarNo")
                        .HasColumnType("int");

                    b.Property<double>("Etk")
                        .HasColumnType("float");

                    b.Property<int>("GenelDizaynId")
                        .HasColumnType("int");

                    b.Property<double>("Hatve")
                        .HasColumnType("float");

                    b.Property<string>("Imalat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kalip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("KesitCapi")
                        .HasColumnType("float");

                    b.Property<string>("Renk")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenelDizaynId");

                    b.ToTable("DamarDizaynBase");
                });

            modelBuilder.Entity("Entities.Base.GenelDizaynBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Ayna")
                        .HasColumnType("float");

                    b.Property<double>("Back")
                        .HasColumnType("float");

                    b.Property<string>("Core")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DamarSayisi")
                        .HasColumnType("int");

                    b.Property<string>("Degistiren")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DegistirilmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<double>("DisCap")
                        .HasColumnType("float");

                    b.Property<string>("DisKilif")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FolyoOlcusu")
                        .HasColumnType("float");

                    b.Property<string>("FolyoTipi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GirilenDamarSayisi")
                        .HasColumnType("int");

                    b.Property<double>("Hatve")
                        .HasColumnType("float");

                    b.Property<string>("Kablo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kalip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("KesitCapi")
                        .HasColumnType("float");

                    b.Property<double>("Orgu")
                        .HasColumnType("float");

                    b.Property<string>("OrguTelYapisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PolyesterOlcusu")
                        .HasColumnType("float");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zorlama")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GenelDizaynBase");
                });

            modelBuilder.Entity("Entities.Base.IsEmriBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BarkodString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Degistiren")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenelDizaynId")
                        .HasColumnType("int");

                    b.Property<string>("Isim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MakineId")
                        .HasColumnType("int");

                    b.Property<double>("Metraj")
                        .HasColumnType("float");

                    b.Property<bool>("TamamlanmaDurumu")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tur")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenelDizaynId");

                    b.ToTable("IsEmirleri");
                });

            modelBuilder.Entity("Entities.Concrete.Barkod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BarkodString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IsEmriId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IsEmriId")
                        .IsUnique()
                        .HasFilter("[IsEmriId] IS NOT NULL");

                    b.ToTable("Barkods");
                });

            modelBuilder.Entity("Entities.Concrete.Base.TekDamarDizaynBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Ayna")
                        .HasColumnType("float");

                    b.Property<double>("Back")
                        .HasColumnType("float");

                    b.Property<string>("Core")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Degistiren")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DegistirilmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<double>("DisCap")
                        .HasColumnType("float");

                    b.Property<double>("DisKilif1")
                        .HasColumnType("float");

                    b.Property<double>("DisKilif2")
                        .HasColumnType("float");

                    b.Property<string>("DizaynTuru")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Hatve")
                        .HasColumnType("float");

                    b.Property<string>("KabloIsmi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kalip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("KesitCapi")
                        .HasColumnType("float");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TekDamarDizayn");
                });

            modelBuilder.Entity("Entities.Concrete.IsEmriOperator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IsEmriId")
                        .HasColumnType("int");

                    b.Property<int>("OperatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IsEmriId");

                    b.HasIndex("OperatorId");

                    b.ToTable("IsEmriOperators");
                });

            modelBuilder.Entity("Entities.Concrete.KabloUretim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CalismaSuresi")
                        .HasColumnType("float");

                    b.Property<string>("Degistiren")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GenelAriza")
                        .HasColumnType("float");

                    b.Property<double>("HurdaCu")
                        .HasColumnType("float");

                    b.Property<double>("HurdaPvc")
                        .HasColumnType("float");

                    b.Property<int>("IsEmriId")
                        .HasColumnType("int");

                    b.Property<string>("KabloIsmi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("KayipZaman")
                        .HasColumnType("float");

                    b.Property<double>("KesitCapi")
                        .HasColumnType("float");

                    b.Property<double>("Kopma")
                        .HasColumnType("float");

                    b.Property<int>("MakineId")
                        .HasColumnType("int");

                    b.Property<double>("Metraj")
                        .HasColumnType("float");

                    b.Property<double>("RenkDegisimi")
                        .HasColumnType("float");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<double>("Verimlilik")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IsEmriId");

                    b.ToTable("KabloUretim");
                });

            modelBuilder.Entity("Entities.Concrete.KesitYapisi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Alan")
                        .HasColumnType("float");

                    b.Property<double>("Ayna")
                        .HasColumnType("float");

                    b.Property<double>("Back")
                        .HasColumnType("float");

                    b.Property<double>("Coef")
                        .HasColumnType("float");

                    b.Property<double>("DisCap")
                        .HasColumnType("float");

                    b.Property<double>("Hatve")
                        .HasColumnType("float");

                    b.Property<double>("KesitCapi")
                        .HasColumnType("float");

                    b.Property<double>("KilcalDamarCapi")
                        .HasColumnType("float");

                    b.Property<int>("KilcalDamarSayisi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("KesitYapisi");
                });

            modelBuilder.Entity("Entities.Concrete.Makine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Isinma")
                        .HasColumnType("int");

                    b.Property<int>("KesitDegisimi")
                        .HasColumnType("int");

                    b.Property<int>("Kopma")
                        .HasColumnType("int");

                    b.Property<string>("MakineIsmi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("No")
                        .HasColumnType("int");

                    b.Property<int>("RenkDegisimi")
                        .HasColumnType("int");

                    b.Property<double?>("Verimlilik")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Makineler");
                });

            modelBuilder.Entity("Entities.Concrete.MakineKesitHizTablosu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Hiz")
                        .HasColumnType("int");

                    b.Property<double>("KesitCapi")
                        .HasColumnType("float");

                    b.Property<int>("MakineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MakineKesitHizTablosu");
                });

            modelBuilder.Entity("Entities.Concrete.Operator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Operators");
                });

            modelBuilder.Entity("Entities.Concrete.Process", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsEmriId")
                        .HasColumnType("int");

                    b.Property<string>("Isim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<bool>("TamamlanmaDurumu")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IsEmriId");

                    b.ToTable("Processes");
                });

            modelBuilder.Entity("Entities.Concrete.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Entities.Concrete.Sarfiyat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("HurdaCu")
                        .HasColumnType("float");

                    b.Property<double>("HurdaPvc")
                        .HasColumnType("float");

                    b.Property<int>("KabloId")
                        .HasColumnType("int");

                    b.Property<double>("KesitCapi")
                        .HasColumnType("float");

                    b.Property<double>("KullanilanCu")
                        .HasColumnType("float");

                    b.Property<double>("KullanilanPvc")
                        .HasColumnType("float");

                    b.Property<int>("MakineId")
                        .HasColumnType("int");

                    b.Property<double>("Maliyet")
                        .HasColumnType("float");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Sarfiyat");
                });

            modelBuilder.Entity("Entities.Concrete.SatisPlanlama", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<double>("Iskonto")
                        .HasColumnType("float");

                    b.Property<string>("KabloIsmi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListeFiyati")
                        .HasColumnType("float");

                    b.Property<int>("Metraj")
                        .HasColumnType("int");

                    b.Property<string>("PaketlemeSekli")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<double>("Tonaj")
                        .HasColumnType("float");

                    b.Property<double>("Tutar")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("SatisPlanlama");
                });

            modelBuilder.Entity("Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Entities.Concrete.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Entities.Base.DamarDizaynBase", b =>
                {
                    b.HasOne("Entities.Base.GenelDizaynBase", "GenelDizayn")
                        .WithMany("Damarlar")
                        .HasForeignKey("GenelDizaynId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GenelDizayn");
                });

            modelBuilder.Entity("Entities.Base.IsEmriBase", b =>
                {
                    b.HasOne("Entities.Base.GenelDizaynBase", "GenelDizayn")
                        .WithMany("IsEmirleri")
                        .HasForeignKey("GenelDizaynId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GenelDizayn");
                });

            modelBuilder.Entity("Entities.Concrete.Barkod", b =>
                {
                    b.HasOne("Entities.Base.IsEmriBase", "IsEmri")
                        .WithOne("Barkod")
                        .HasForeignKey("Entities.Concrete.Barkod", "IsEmriId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("IsEmri");
                });

            modelBuilder.Entity("Entities.Concrete.IsEmriOperator", b =>
                {
                    b.HasOne("Entities.Base.IsEmriBase", "IsEmri")
                        .WithMany("IsEmriOperators")
                        .HasForeignKey("IsEmriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Operator", "Operator")
                        .WithMany("IsEmriOperators")
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IsEmri");

                    b.Navigation("Operator");
                });

            modelBuilder.Entity("Entities.Concrete.KabloUretim", b =>
                {
                    b.HasOne("Entities.Base.IsEmriBase", "IsEmri")
                        .WithMany("KabloUretimler")
                        .HasForeignKey("IsEmriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IsEmri");
                });

            modelBuilder.Entity("Entities.Concrete.Process", b =>
                {
                    b.HasOne("Entities.Base.IsEmriBase", "IsEmri")
                        .WithMany("Surecler")
                        .HasForeignKey("IsEmriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IsEmri");
                });

            modelBuilder.Entity("Entities.Concrete.UserRole", b =>
                {
                    b.HasOne("Entities.Concrete.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Entities.Concrete.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Entities.Concrete.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Entities.Concrete.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Entities.Concrete.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Base.GenelDizaynBase", b =>
                {
                    b.Navigation("Damarlar");

                    b.Navigation("IsEmirleri");
                });

            modelBuilder.Entity("Entities.Base.IsEmriBase", b =>
                {
                    b.Navigation("Barkod");

                    b.Navigation("IsEmriOperators");

                    b.Navigation("KabloUretimler");

                    b.Navigation("Surecler");
                });

            modelBuilder.Entity("Entities.Concrete.Operator", b =>
                {
                    b.Navigation("IsEmriOperators");
                });

            modelBuilder.Entity("Entities.Concrete.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Entities.Concrete.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
