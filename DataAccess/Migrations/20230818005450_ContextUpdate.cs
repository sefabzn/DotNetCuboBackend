using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ContextUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_OperatorIsEmirleri_IsEmriId",
                table: "Processes");

            migrationBuilder.DropIndex(
                name: "IX_Processes_IsEmriId",
                table: "Processes");

            migrationBuilder.AddColumn<int>(
                name: "OperatorIsEmriId",
                table: "Processes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UrunIsmi",
                table: "OperatorIsEmirleri",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Operator",
                table: "OperatorIsEmirleri",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MakineIsmi",
                table: "OperatorIsEmirleri",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Kalip",
                table: "OperatorIsEmirleri",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DizaynTuru",
                table: "OperatorIsEmirleri",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Barkod",
                table: "OperatorIsEmirleri",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_OperatorIsEmriId",
                table: "Processes",
                column: "OperatorIsEmriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_OperatorIsEmirleri_OperatorIsEmriId",
                table: "Processes",
                column: "OperatorIsEmriId",
                principalTable: "OperatorIsEmirleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_OperatorIsEmirleri_OperatorIsEmriId",
                table: "Processes");

            migrationBuilder.DropIndex(
                name: "IX_Processes_OperatorIsEmriId",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "OperatorIsEmriId",
                table: "Processes");

            migrationBuilder.AlterColumn<string>(
                name: "UrunIsmi",
                table: "OperatorIsEmirleri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Operator",
                table: "OperatorIsEmirleri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MakineIsmi",
                table: "OperatorIsEmirleri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Kalip",
                table: "OperatorIsEmirleri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DizaynTuru",
                table: "OperatorIsEmirleri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Barkod",
                table: "OperatorIsEmirleri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Processes_IsEmriId",
                table: "Processes",
                column: "IsEmriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_OperatorIsEmirleri_IsEmriId",
                table: "Processes",
                column: "IsEmriId",
                principalTable: "OperatorIsEmirleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
