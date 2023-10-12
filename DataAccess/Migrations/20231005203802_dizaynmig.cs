using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class dizaynmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CctvDamarDizayn");

            migrationBuilder.DropTable(
                name: "TelefonDamarDizayn");

            migrationBuilder.DropTable(
                name: "YanginDamarDizayn");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "GenelDizaynBase");

            migrationBuilder.AlterColumn<double>(
                name: "Hatve",
                table: "GenelDizaynBase",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tur",
                table: "GenelDizaynBase",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DamarDizaynBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DamarNo = table.Column<int>(type: "int", nullable: false),
                    Renk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    Etk = table.Column<double>(type: "float", nullable: false),
                    Cap = table.Column<double>(type: "float", nullable: false),
                    Back = table.Column<double>(type: "float", nullable: false),
                    Ayna = table.Column<double>(type: "float", nullable: false),
                    Kalip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imalat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hatve = table.Column<double>(type: "float", nullable: false),
                    GenelDizaynId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamarDizaynBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DamarDizaynBase_GenelDizaynBase_GenelDizaynId",
                        column: x => x.GenelDizaynId,
                        principalTable: "GenelDizaynBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DamarDizaynBase_GenelDizaynId",
                table: "DamarDizaynBase",
                column: "GenelDizaynId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DamarDizaynBase");

            migrationBuilder.DropColumn(
                name: "Tur",
                table: "GenelDizaynBase");

            migrationBuilder.AlterColumn<double>(
                name: "Hatve",
                table: "GenelDizaynBase",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "GenelDizaynBase",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CctvDamarDizayn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnaId = table.Column<int>(type: "int", nullable: false),
                    Ayna = table.Column<double>(type: "float", nullable: false),
                    Back = table.Column<double>(type: "float", nullable: false),
                    Cap = table.Column<double>(type: "float", nullable: false),
                    DamarNo = table.Column<int>(type: "int", nullable: false),
                    Etk = table.Column<double>(type: "float", nullable: false),
                    Hatve = table.Column<double>(type: "float", nullable: false),
                    Imalat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kalip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    Renk = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CctvDamarDizayn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelefonDamarDizayn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnaId = table.Column<int>(type: "int", nullable: false),
                    Ayna = table.Column<double>(type: "float", nullable: false),
                    Back = table.Column<double>(type: "float", nullable: false),
                    Cap = table.Column<double>(type: "float", nullable: false),
                    DamarNo = table.Column<int>(type: "int", nullable: false),
                    Etk = table.Column<double>(type: "float", nullable: false),
                    Hatve = table.Column<double>(type: "float", nullable: false),
                    Kalip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    Renk = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonDamarDizayn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YanginDamarDizayn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnaId = table.Column<int>(type: "int", nullable: false),
                    Ayna = table.Column<double>(type: "float", nullable: false),
                    Back = table.Column<double>(type: "float", nullable: false),
                    Cap = table.Column<double>(type: "float", nullable: false),
                    DamarNo = table.Column<int>(type: "int", nullable: false),
                    Etk = table.Column<double>(type: "float", nullable: false),
                    Hatve = table.Column<double>(type: "float", nullable: false),
                    Kalip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KesitCapi = table.Column<double>(type: "float", nullable: false),
                    Renk = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YanginDamarDizayn", x => x.Id);
                });
        }
    }
}
