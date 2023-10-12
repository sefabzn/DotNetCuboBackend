using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class isemrikablouretimmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_OperatorIsEmirleri_OperatorIsEmriId",
                table: "Processes");

            migrationBuilder.DropTable(
                name: "OperatorIsEmirleri");

            migrationBuilder.DropIndex(
                name: "IX_Processes_OperatorIsEmriId",
                table: "Processes");

            migrationBuilder.DropIndex(
                name: "IX_KabloUretim_IsEmriId",
                table: "KabloUretim");

            migrationBuilder.DropColumn(
                name: "OperatorIsEmriId",
                table: "Processes");

            migrationBuilder.CreateIndex(
                name: "IX_KabloUretim_IsEmriId",
                table: "KabloUretim",
                column: "IsEmriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_KabloUretim_IsEmriId",
                table: "KabloUretim");

            migrationBuilder.AddColumn<int>(
                name: "OperatorIsEmriId",
                table: "Processes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OperatorIsEmirleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ayna = table.Column<double>(type: "float", nullable: false),
                    Back = table.Column<double>(type: "float", nullable: false),
                    Barkod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Degistiren = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisCap = table.Column<double>(type: "float", nullable: false),
                    DizaynTuru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kalip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    MakineIsmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metraj = table.Column<double>(type: "float", nullable: false),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TamamlanmaDurumu = table.Column<bool>(type: "bit", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeorikMaliyet = table.Column<double>(type: "float", nullable: false),
                    UrunIsmi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorIsEmirleri", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Processes_OperatorIsEmriId",
                table: "Processes",
                column: "OperatorIsEmriId");

            migrationBuilder.CreateIndex(
                name: "IX_KabloUretim_IsEmriId",
                table: "KabloUretim",
                column: "IsEmriId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_OperatorIsEmirleri_OperatorIsEmriId",
                table: "Processes",
                column: "OperatorIsEmriId",
                principalTable: "OperatorIsEmirleri",
                principalColumn: "Id");
        }
    }
}
