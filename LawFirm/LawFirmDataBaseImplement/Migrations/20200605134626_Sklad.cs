using Microsoft.EntityFrameworkCore.Migrations;

namespace LawFirmDataBaseImplement.Migrations
{
    public partial class Sklad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBlanks_Products_ProductId",
                table: "ProductBlanks");

            migrationBuilder.DropIndex(
                name: "IX_ProductBlanks_ProductId",
                table: "ProductBlanks");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                        onDelete: ReferentialAction.Cascade);
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
                column: "SkladId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBlanks_Products_BlankId",
                table: "ProductBlanks",
                column: "BlankId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBlanks_Products_BlankId",
                table: "ProductBlanks");

            migrationBuilder.DropTable(
                name: "SkladBlanks");

            migrationBuilder.DropTable(
                name: "Sklads");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_ProductBlanks_ProductId",
                table: "ProductBlanks",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBlanks_Products_ProductId",
                table: "ProductBlanks",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
