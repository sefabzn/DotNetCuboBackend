using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BarkodMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barkod",
                table: "IsEmirleri");

            migrationBuilder.CreateTable(
                name: "Barkods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarkodString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmriId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barkods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barkods_IsEmirleri_IsEmriId",
                        column: x => x.IsEmriId,
                        principalTable: "IsEmirleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barkods_IsEmriId",
                table: "Barkods",
                column: "IsEmriId",
                unique: true,
                filter: "[IsEmriId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barkods");

            migrationBuilder.AddColumn<string>(
                name: "Barkod",
                table: "IsEmirleri",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
