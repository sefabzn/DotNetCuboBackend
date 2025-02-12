using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newtablesforirsaliye : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SevkIrsaliyeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToplamTutar = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SevkIrsaliyeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SevkIrsaliyeler_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SevkIrsaliyeKalemler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SevkIrsaliyeId = table.Column<int>(type: "int", nullable: false),
                    KabloUretimId = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<double>(type: "float", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SevkIrsaliyeKalemler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SevkIrsaliyeKalemler_KabloUretim_KabloUretimId",
                        column: x => x.KabloUretimId,
                        principalTable: "KabloUretim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SevkIrsaliyeKalemler_SevkIrsaliyeler_SevkIrsaliyeId",
                        column: x => x.SevkIrsaliyeId,
                        principalTable: "SevkIrsaliyeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SevkIrsaliyeKalemler_KabloUretimId",
                table: "SevkIrsaliyeKalemler",
                column: "KabloUretimId");

            migrationBuilder.CreateIndex(
                name: "IX_SevkIrsaliyeKalemler_SevkIrsaliyeId",
                table: "SevkIrsaliyeKalemler",
                column: "SevkIrsaliyeId");

            migrationBuilder.CreateIndex(
                name: "IX_SevkIrsaliyeler_MusteriId",
                table: "SevkIrsaliyeler",
                column: "MusteriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SevkIrsaliyeKalemler");

            migrationBuilder.DropTable(
                name: "SevkIrsaliyeler");

            migrationBuilder.DropTable(
                name: "Musteriler");
        }
    }
}
