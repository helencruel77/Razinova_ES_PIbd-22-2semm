using Microsoft.EntityFrameworkCore.Migrations;

namespace LawFirmDataBaseImplement.Migrations
{
    public partial class Sklad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sklads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkladName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sklads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkladBlanks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkladId = table.Column<int>(nullable: false),
                    BlankId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkladBlanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkladBlanks_Blanks_BlankId",
                        column: x => x.BlankId,
                        principalTable: "Blanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SkladBlanks_Sklads_SkladId",
                        column: x => x.SkladId,
                        principalTable: "Sklads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkladBlanks_BlankId",
                table: "SkladBlanks",
                column: "BlankId");

            migrationBuilder.CreateIndex(
                name: "IX_SkladBlanks_SkladId",
                table: "SkladBlanks",
                column: "SkladId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkladBlanks");

            migrationBuilder.DropTable(
                name: "Sklads");
        }
    }
}
