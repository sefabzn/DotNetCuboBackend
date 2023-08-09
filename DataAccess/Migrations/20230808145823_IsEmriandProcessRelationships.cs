using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IsEmriandProcessRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProcesses");

            migrationBuilder.RenameColumn(
                name: "ProcessName",
                table: "Processes",
                newName: "Isim");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Processes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TamamlanmaDurumu",
                table: "Processes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "İşEmriId",
                table: "Processes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Barkod",
                table: "OperatorIsEmirleri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "TamamlanmaDurumu",
                table: "OperatorIsEmirleri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Processes_İşEmriId",
                table: "Processes",
                column: "İşEmriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_OperatorIsEmirleri_İşEmriId",
                table: "Processes",
                column: "İşEmriId",
                principalTable: "OperatorIsEmirleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_OperatorIsEmirleri_İşEmriId",
                table: "Processes");

            migrationBuilder.DropIndex(
                name: "IX_Processes_İşEmriId",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "TamamlanmaDurumu",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "İşEmriId",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "Barkod",
                table: "OperatorIsEmirleri");

            migrationBuilder.DropColumn(
                name: "TamamlanmaDurumu",
                table: "OperatorIsEmirleri");

            migrationBuilder.RenameColumn(
                name: "Isim",
                table: "Processes",
                newName: "ProcessName");

            migrationBuilder.CreateTable(
                name: "OrderProcesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    isCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProcesses", x => x.Id);
                });
        }
    }
}
