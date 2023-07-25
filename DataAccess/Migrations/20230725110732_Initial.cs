using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CctvDamarDizayn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imalat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnaId = table.Column<int>(type: "int", nullable: false),
                    DamarNo = table.Column<int>(type: "int", nullable: false),
                    Renk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    Etk = table.Column<double>(type: "float", nullable: false),
                    Cap = table.Column<double>(type: "float", nullable: false),
                    Back = table.Column<double>(type: "float", nullable: false),
                    Ayna = table.Column<double>(type: "float", nullable: false),
                    Kalip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hatve = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CctvDamarDizayn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CctvGenelDizayn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Core = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hatve = table.Column<double>(type: "float", nullable: false),
                    Kablo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    Orgu = table.Column<double>(type: "float", nullable: false),
                    OrguTelYapisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolyesterOlcusu = table.Column<double>(type: "float", nullable: false),
                    FolyoTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolyoOlcusu = table.Column<double>(type: "float", nullable: false),
                    DisKilif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisCap = table.Column<double>(type: "float", nullable: false),
                    Back = table.Column<double>(type: "float", nullable: false),
                    Ayna = table.Column<double>(type: "float", nullable: false),
                    Kalip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DamarSayisi = table.Column<int>(type: "int", nullable: false),
                    GirilenDamarSayisi = table.Column<int>(type: "int", nullable: false),
                    Zorlama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistiren = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CctvGenelDizayn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CctvIsEmirleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BukumBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamarBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamarBukumBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DolguBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KilifBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolyoBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrguBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisKilifBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Degistiren = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CctvIsEmirleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KabloUretim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KabloIsmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MakineId = table.Column<int>(type: "int", nullable: false),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    Metraj = table.Column<double>(type: "float", nullable: false),
                    Kopma = table.Column<double>(type: "float", nullable: false),
                    RenkDegisimi = table.Column<double>(type: "float", nullable: false),
                    GenelAriza = table.Column<double>(type: "float", nullable: false),
                    HurdaPvc = table.Column<double>(type: "float", nullable: false),
                    HurdaCu = table.Column<double>(type: "float", nullable: false),
                    CalismaSuresi = table.Column<double>(type: "float", nullable: false),
                    KayipZaman = table.Column<double>(type: "float", nullable: false),
                    Verimlilik = table.Column<double>(type: "float", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistiren = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KabloUretim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KesitYapisi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    Back = table.Column<double>(type: "float", nullable: false),
                    DisCap = table.Column<double>(type: "float", nullable: false),
                    Ayna = table.Column<double>(type: "float", nullable: false),
                    KilcalDamarSayisi = table.Column<int>(type: "int", nullable: false),
                    KilcalDamarCapi = table.Column<double>(type: "float", nullable: false),
                    Hatve = table.Column<double>(type: "float", nullable: false),
                    Alan = table.Column<double>(type: "float", nullable: false),
                    Coef = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KesitYapisi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MakineKesitHizTablosu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    MakineId = table.Column<int>(type: "int", nullable: false),
                    Hiz = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakineKesitHizTablosu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Makineler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", nullable: false),
                    MakineIsmi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isinma = table.Column<int>(type: "int", nullable: false),
                    RenkDegisimi = table.Column<int>(type: "int", nullable: false),
                    Kopma = table.Column<int>(type: "int", nullable: false),
                    KesitDegisimi = table.Column<int>(type: "int", nullable: false),
                    Verimlilik = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makineler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperatorIsEmirleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakineIsmi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunIsmi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DizaynTuru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    Metraj = table.Column<double>(type: "float", nullable: false),
                    DisCap = table.Column<double>(type: "float", nullable: false),
                    Back = table.Column<double>(type: "float", nullable: false),
                    Ayna = table.Column<double>(type: "float", nullable: false),
                    Kalip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeorikMaliyet = table.Column<double>(type: "float", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistiren = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorIsEmirleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderProcesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    isCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProcesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sarfiyat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KabloId = table.Column<int>(type: "int", nullable: false),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    MakineId = table.Column<int>(type: "int", nullable: false),
                    KullanilanPvc = table.Column<double>(type: "float", nullable: false),
                    KullanilanCu = table.Column<double>(type: "float", nullable: false),
                    HurdaPvc = table.Column<double>(type: "float", nullable: false),
                    HurdaCu = table.Column<double>(type: "float", nullable: false),
                    Maliyet = table.Column<double>(type: "float", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sarfiyat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SatisPlanlama",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KabloIsmi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metraj = table.Column<int>(type: "int", nullable: false),
                    Tonaj = table.Column<double>(type: "float", nullable: false),
                    ListeFiyati = table.Column<double>(type: "float", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    Iskonto = table.Column<double>(type: "float", nullable: false),
                    Tutar = table.Column<double>(type: "float", nullable: false),
                    PaketlemeSekli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatisPlanlama", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TekDamarDizayn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KabloIsmi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Core = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    Hatve = table.Column<double>(type: "float", nullable: false),
                    DisKilif1 = table.Column<double>(type: "float", nullable: false),
                    DisKilif2 = table.Column<double>(type: "float", nullable: false),
                    DisCap = table.Column<double>(type: "float", nullable: false),
                    Back = table.Column<double>(type: "float", nullable: false),
                    Ayna = table.Column<double>(type: "float", nullable: false),
                    Kalip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DizaynTuru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistiren = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TekDamarDizayn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelefonDamarDizayn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnaId = table.Column<int>(type: "int", nullable: false),
                    DamarNo = table.Column<int>(type: "int", nullable: false),
                    Renk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    Etk = table.Column<double>(type: "float", nullable: false),
                    Cap = table.Column<double>(type: "float", nullable: false),
                    Back = table.Column<double>(type: "float", nullable: false),
                    Ayna = table.Column<double>(type: "float", nullable: false),
                    Kalip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hatve = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonDamarDizayn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelefonGenelDizayn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kablo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    Orgu = table.Column<double>(type: "float", nullable: false),
                    OrguTelYapisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolyesterOlcusu = table.Column<double>(type: "float", nullable: false),
                    FolyoTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolyoOlcusu = table.Column<double>(type: "float", nullable: false),
                    DisKilif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisCap = table.Column<double>(type: "float", nullable: false),
                    Back = table.Column<double>(type: "float", nullable: false),
                    Ayna = table.Column<double>(type: "float", nullable: false),
                    Kalip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DamarSayisi = table.Column<int>(type: "int", nullable: false),
                    GirilenDamarSayisi = table.Column<int>(type: "int", nullable: false),
                    Zorlama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistiren = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonGenelDizayn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelefonIsEmirleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BukumBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamarBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamarBukumBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DolguBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KilifBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolyoBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrguBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisKilifBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Degistiren = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonIsEmirleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YanginDamarDizayn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnaId = table.Column<int>(type: "int", nullable: false),
                    DamarNo = table.Column<int>(type: "int", nullable: false),
                    Renk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    Etk = table.Column<double>(type: "float", nullable: false),
                    Cap = table.Column<double>(type: "float", nullable: false),
                    Back = table.Column<double>(type: "float", nullable: false),
                    Ayna = table.Column<double>(type: "float", nullable: false),
                    Kalip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hatve = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YanginDamarDizayn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YanginGenelDizayn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kablo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    Orgu = table.Column<double>(type: "float", nullable: false),
                    OrguTelYapisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolyesterOlcusu = table.Column<double>(type: "float", nullable: false),
                    FolyoTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolyoOlcusu = table.Column<double>(type: "float", nullable: false),
                    DisKilif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisCap = table.Column<double>(type: "float", nullable: false),
                    Back = table.Column<double>(type: "float", nullable: false),
                    Ayna = table.Column<double>(type: "float", nullable: false),
                    Kalip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DamarSayisi = table.Column<int>(type: "int", nullable: false),
                    GirilenDamarSayisi = table.Column<int>(type: "int", nullable: false),
                    Zorlama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistiren = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YanginGenelDizayn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YanginIsEmirleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BukumBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamarBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamarBukumBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DolguBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KilifBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolyoBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrguBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisKilifBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Degistiren = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YanginIsEmirleri", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CctvDamarDizayn");

            migrationBuilder.DropTable(
                name: "CctvGenelDizayn");

            migrationBuilder.DropTable(
                name: "CctvIsEmirleri");

            migrationBuilder.DropTable(
                name: "KabloUretim");

            migrationBuilder.DropTable(
                name: "KesitYapisi");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "MakineKesitHizTablosu");

            migrationBuilder.DropTable(
                name: "Makineler");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "OperatorIsEmirleri");

            migrationBuilder.DropTable(
                name: "OrderProcesses");

            migrationBuilder.DropTable(
                name: "Processes");

            migrationBuilder.DropTable(
                name: "Sarfiyat");

            migrationBuilder.DropTable(
                name: "SatisPlanlama");

            migrationBuilder.DropTable(
                name: "TekDamarDizayn");

            migrationBuilder.DropTable(
                name: "TelefonDamarDizayn");

            migrationBuilder.DropTable(
                name: "TelefonGenelDizayn");

            migrationBuilder.DropTable(
                name: "TelefonIsEmirleri");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "YanginDamarDizayn");

            migrationBuilder.DropTable(
                name: "YanginGenelDizayn");

            migrationBuilder.DropTable(
                name: "YanginIsEmirleri");
        }
    }
}
