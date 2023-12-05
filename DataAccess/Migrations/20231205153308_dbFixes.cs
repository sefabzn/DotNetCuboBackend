using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class dbFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DamarDizaynBase_GenelDizaynBase_GenelDizaynId",
                table: "DamarDizaynBase");

            migrationBuilder.DropForeignKey(
                name: "FK_IsEmirleri_GenelDizaynBase_GenelDizaynId",
                table: "IsEmirleri");

            migrationBuilder.DropIndex(
                name: "IX_IsEmirleri_GenelDizaynId",
                table: "IsEmirleri");

            migrationBuilder.DropIndex(
                name: "IX_DamarDizaynBase_GenelDizaynId",
                table: "DamarDizaynBase");

            migrationBuilder.DropColumn(
                name: "DamarSayisi",
                table: "GenelDizaynBase");

            migrationBuilder.DropColumn(
                name: "GirilenDamarSayisi",
                table: "GenelDizaynBase");

            migrationBuilder.RenameColumn(
                name: "GenelDizaynId",
                table: "DamarDizaynBase",
                newName: "IsEmriId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Tarih",
                table: "IsEmriOperators",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DamarSayisi",
                table: "IsEmirleri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GirilenDamarSayisi",
                table: "IsEmirleri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IsEmriDamarDizayns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsEmriId = table.Column<int>(type: "int", nullable: false),
                    DamarDizaynId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsEmriDamarDizayns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IsEmriDamarDizayns_DamarDizaynBase_DamarDizaynId",
                        column: x => x.DamarDizaynId,
                        principalTable: "DamarDizaynBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IsEmriDamarDizayns_IsEmirleri_IsEmriId",
                        column: x => x.IsEmriId,
                        principalTable: "IsEmirleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IsEmriGenelDizayns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsEmriId = table.Column<int>(type: "int", nullable: false),
                    GenelDizaynId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsEmriGenelDizayns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IsEmriGenelDizayns_GenelDizaynBase_GenelDizaynId",
                        column: x => x.GenelDizaynId,
                        principalTable: "GenelDizaynBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IsEmriGenelDizayns_IsEmirleri_IsEmriId",
                        column: x => x.IsEmriId,
                        principalTable: "IsEmirleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IsEmriDamarDizayns_DamarDizaynId",
                table: "IsEmriDamarDizayns",
                column: "DamarDizaynId");

            migrationBuilder.CreateIndex(
                name: "IX_IsEmriDamarDizayns_IsEmriId",
                table: "IsEmriDamarDizayns",
                column: "IsEmriId");

            migrationBuilder.CreateIndex(
                name: "IX_IsEmriGenelDizayns_GenelDizaynId",
                table: "IsEmriGenelDizayns",
                column: "GenelDizaynId");

            migrationBuilder.CreateIndex(
                name: "IX_IsEmriGenelDizayns_IsEmriId",
                table: "IsEmriGenelDizayns",
                column: "IsEmriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IsEmriDamarDizayns");

            migrationBuilder.DropTable(
                name: "IsEmriGenelDizayns");

            migrationBuilder.DropColumn(
                name: "Tarih",
                table: "IsEmriOperators");

            migrationBuilder.DropColumn(
                name: "DamarSayisi",
                table: "IsEmirleri");

            migrationBuilder.DropColumn(
                name: "GirilenDamarSayisi",
                table: "IsEmirleri");

            migrationBuilder.RenameColumn(
                name: "IsEmriId",
                table: "DamarDizaynBase",
                newName: "GenelDizaynId");

            migrationBuilder.AddColumn<int>(
                name: "DamarSayisi",
                table: "GenelDizaynBase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GirilenDamarSayisi",
                table: "GenelDizaynBase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IsEmirleri_GenelDizaynId",
                table: "IsEmirleri",
                column: "GenelDizaynId");

            migrationBuilder.CreateIndex(
                name: "IX_DamarDizaynBase_GenelDizaynId",
                table: "DamarDizaynBase",
                column: "GenelDizaynId");

            migrationBuilder.AddForeignKey(
                name: "FK_DamarDizaynBase_GenelDizaynBase_GenelDizaynId",
                table: "DamarDizaynBase",
                column: "GenelDizaynId",
                principalTable: "GenelDizaynBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IsEmirleri_GenelDizaynBase_GenelDizaynId",
                table: "IsEmirleri",
                column: "GenelDizaynId",
                principalTable: "GenelDizaynBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
