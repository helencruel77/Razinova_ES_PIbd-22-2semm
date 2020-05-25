using Microsoft.EntityFrameworkCore.Migrations;

namespace LawFirmDataBaseImplement.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBlanks_Products_ProductId",
                table: "ProductBlanks");

            migrationBuilder.DropForeignKey(
                name: "FK_SkladBlanks_Blanks_BlankId",
                table: "SkladBlanks");

            migrationBuilder.DropIndex(
                name: "IX_SkladBlanks_BlankId",
                table: "SkladBlanks");

            migrationBuilder.DropIndex(
                name: "IX_SkladBlanks_SkladId",
                table: "SkladBlanks");

            migrationBuilder.DropIndex(
                name: "IX_ProductBlanks_ProductId",
                table: "ProductBlanks");

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "SkladBlanks",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkladBlanks_ComponentId",
                table: "SkladBlanks",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_SkladBlanks_SkladId",
                table: "SkladBlanks",
                column: "SkladId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBlanks_Products_BlankId",
                table: "ProductBlanks",
                column: "BlankId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkladBlanks_Blanks_ComponentId",
                table: "SkladBlanks",
                column: "ComponentId",
                principalTable: "Blanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBlanks_Products_BlankId",
                table: "ProductBlanks");

            migrationBuilder.DropForeignKey(
                name: "FK_SkladBlanks_Blanks_ComponentId",
                table: "SkladBlanks");

            migrationBuilder.DropIndex(
                name: "IX_SkladBlanks_ComponentId",
                table: "SkladBlanks");

            migrationBuilder.DropIndex(
                name: "IX_SkladBlanks_SkladId",
                table: "SkladBlanks");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "SkladBlanks");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_SkladBlanks_BlankId",
                table: "SkladBlanks",
                column: "BlankId");

            migrationBuilder.CreateIndex(
                name: "IX_SkladBlanks_SkladId",
                table: "SkladBlanks",
                column: "SkladId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SkladBlanks_Blanks_BlankId",
                table: "SkladBlanks",
                column: "BlankId",
                principalTable: "Blanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
