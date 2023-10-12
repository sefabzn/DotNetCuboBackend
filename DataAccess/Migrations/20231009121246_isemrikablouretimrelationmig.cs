using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class isemrikablouretimrelationmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BukumBarkodu",
                table: "IsEmirleri");

            migrationBuilder.DropColumn(
                name: "DamarBarkodu",
                table: "IsEmirleri");

            migrationBuilder.DropColumn(
                name: "DamarBukumBarkodu",
                table: "IsEmirleri");

            migrationBuilder.DropColumn(
                name: "DisKilifBarkodu",
                table: "IsEmirleri");

            migrationBuilder.DropColumn(
                name: "DolguBarkodu",
                table: "IsEmirleri");

            migrationBuilder.DropColumn(
                name: "FolyoBarkodu",
                table: "IsEmirleri");

            migrationBuilder.DropColumn(
                name: "KilifBarkodu",
                table: "IsEmirleri");

            migrationBuilder.DropColumn(
                name: "OrguBarkodu",
                table: "IsEmirleri");

            migrationBuilder.AddColumn<int>(
                name: "IsEmriId",
                table: "KabloUretim",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_KabloUretim_IsEmriId",
                table: "KabloUretim",
                column: "IsEmriId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KabloUretim_IsEmirleri_IsEmriId",
                table: "KabloUretim",
                column: "IsEmriId",
                principalTable: "IsEmirleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KabloUretim_IsEmirleri_IsEmriId",
                table: "KabloUretim");

            migrationBuilder.DropIndex(
                name: "IX_KabloUretim_IsEmriId",
                table: "KabloUretim");

            migrationBuilder.DropColumn(
                name: "IsEmriId",
                table: "KabloUretim");

            migrationBuilder.AddColumn<string>(
                name: "BukumBarkodu",
                table: "IsEmirleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamarBarkodu",
                table: "IsEmirleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamarBukumBarkodu",
                table: "IsEmirleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisKilifBarkodu",
                table: "IsEmirleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DolguBarkodu",
                table: "IsEmirleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FolyoBarkodu",
                table: "IsEmirleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KilifBarkodu",
                table: "IsEmirleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrguBarkodu",
                table: "IsEmirleri",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
