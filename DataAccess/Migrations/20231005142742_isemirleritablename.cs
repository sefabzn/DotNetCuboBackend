using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class isemirleritablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ısEmriBases_GenelDizaynBase_GenelDizaynId",
                table: "ısEmriBases");

            migrationBuilder.DropForeignKey(
                name: "FK_Processes_ısEmriBases_IsEmriId",
                table: "Processes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ısEmriBases",
                table: "ısEmriBases");

            migrationBuilder.RenameTable(
                name: "ısEmriBases",
                newName: "IsEmirleri");

            migrationBuilder.RenameIndex(
                name: "IX_ısEmriBases_GenelDizaynId",
                table: "IsEmirleri",
                newName: "IX_IsEmirleri_GenelDizaynId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IsEmirleri",
                table: "IsEmirleri",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IsEmirleri_GenelDizaynBase_GenelDizaynId",
                table: "IsEmirleri",
                column: "GenelDizaynId",
                principalTable: "GenelDizaynBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_IsEmirleri_IsEmriId",
                table: "Processes",
                column: "IsEmriId",
                principalTable: "IsEmirleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IsEmirleri_GenelDizaynBase_GenelDizaynId",
                table: "IsEmirleri");

            migrationBuilder.DropForeignKey(
                name: "FK_Processes_IsEmirleri_IsEmriId",
                table: "Processes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IsEmirleri",
                table: "IsEmirleri");

            migrationBuilder.RenameTable(
                name: "IsEmirleri",
                newName: "ısEmriBases");

            migrationBuilder.RenameIndex(
                name: "IX_IsEmirleri_GenelDizaynId",
                table: "ısEmriBases",
                newName: "IX_ısEmriBases_GenelDizaynId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ısEmriBases",
                table: "ısEmriBases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ısEmriBases_GenelDizaynBase_GenelDizaynId",
                table: "ısEmriBases",
                column: "GenelDizaynId",
                principalTable: "GenelDizaynBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_ısEmriBases_IsEmriId",
                table: "Processes",
                column: "IsEmriId",
                principalTable: "ısEmriBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
