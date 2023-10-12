using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class contexfixmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IsEmirleri_GenelDizaynId",
                table: "IsEmirleri");

            migrationBuilder.CreateIndex(
                name: "IX_IsEmirleri_GenelDizaynId",
                table: "IsEmirleri",
                column: "GenelDizaynId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IsEmirleri_GenelDizaynId",
                table: "IsEmirleri");

            migrationBuilder.CreateIndex(
                name: "IX_IsEmirleri_GenelDizaynId",
                table: "IsEmirleri",
                column: "GenelDizaynId",
                unique: true);
        }
    }
}
