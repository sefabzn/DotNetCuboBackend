using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MakeIsEmriIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KabloUretim_IsEmirleri_IsEmriId",
                table: "KabloUretim");

            migrationBuilder.AlterColumn<int>(
                name: "IsEmriId",
                table: "KabloUretim",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_KabloUretim_IsEmirleri_IsEmriId",
                table: "KabloUretim",
                column: "IsEmriId",
                principalTable: "IsEmirleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KabloUretim_IsEmirleri_IsEmriId",
                table: "KabloUretim");

            migrationBuilder.AlterColumn<int>(
                name: "IsEmriId",
                table: "KabloUretim",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KabloUretim_IsEmirleri_IsEmriId",
                table: "KabloUretim",
                column: "IsEmriId",
                principalTable: "IsEmirleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
