using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
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
                    Imalat = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "GenelDizaynBase",
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
                    Degistiren = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmriId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Core = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hatve = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenelDizaynBase", x => x.Id);
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
                    MakineIsmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    MakineIsmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunIsmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DizaynTuru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    Metraj = table.Column<double>(type: "float", nullable: false),
                    DisCap = table.Column<double>(type: "float", nullable: false),
                    Back = table.Column<double>(type: "float", nullable: false),
                    Ayna = table.Column<double>(type: "float", nullable: false),
                    Kalip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeorikMaliyet = table.Column<double>(type: "float", nullable: false),
                    TamamlanmaDurumu = table.Column<bool>(type: "bit", nullable: false),
                    Barkod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistiren = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorIsEmirleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                name: "ısEmriBases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BukumBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamarBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamarBukumBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DolguBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KilifBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolyoBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrguBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisKilifBarkodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TamamlanmaDurumu = table.Column<bool>(type: "bit", nullable: false),
                    Barkod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistiren = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenelDizaynId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ısEmriBases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ısEmriBases_GenelDizaynBase_GenelDizaynId",
                        column: x => x.GenelDizaynId,
                        principalTable: "GenelDizaynBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsEmriId = table.Column<int>(type: "int", nullable: false),
                    TamamlanmaDurumu = table.Column<bool>(type: "bit", nullable: false),
                    OperatorIsEmriId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processes_OperatorIsEmirleri_OperatorIsEmriId",
                        column: x => x.OperatorIsEmriId,
                        principalTable: "OperatorIsEmirleri",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Processes_ısEmriBases_IsEmriId",
                        column: x => x.IsEmriId,
                        principalTable: "ısEmriBases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ısEmriBases_GenelDizaynId",
                table: "ısEmriBases",
                column: "GenelDizaynId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Processes_IsEmriId",
                table: "Processes",
                column: "IsEmriId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_OperatorIsEmriId",
                table: "Processes",
                column: "OperatorIsEmriId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CctvDamarDizayn");

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
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "YanginDamarDizayn");

            migrationBuilder.DropTable(
                name: "OperatorIsEmirleri");

            migrationBuilder.DropTable(
                name: "ısEmriBases");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "GenelDizaynBase");
        }
    }
}
