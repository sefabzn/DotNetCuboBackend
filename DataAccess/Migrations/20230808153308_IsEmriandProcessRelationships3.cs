using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IsEmriandProcessRelationships3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_OperatorIsEmirleri_İşEmriId",
                table: "Processes");

            migrationBuilder.RenameColumn(
                name: "İşEmriId",
                table: "Processes",
                newName: "IsEmriId");

            migrationBuilder.RenameIndex(
                name: "IX_Processes_İşEmriId",
                table: "Processes",
                newName: "IX_Processes_IsEmriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_OperatorIsEmirleri_IsEmriId",
                table: "Processes",
                column: "IsEmriId",
                principalTable: "OperatorIsEmirleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_OperatorIsEmirleri_IsEmriId",
                table: "Processes");

            migrationBuilder.RenameColumn(
                name: "IsEmriId",
                table: "Processes",
                newName: "İşEmriId");

            migrationBuilder.RenameIndex(
                name: "IX_Processes_IsEmriId",
                table: "Processes",
                newName: "IX_Processes_İşEmriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_OperatorIsEmirleri_İşEmriId",
                table: "Processes",
                column: "İşEmriId",
                principalTable: "OperatorIsEmirleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
