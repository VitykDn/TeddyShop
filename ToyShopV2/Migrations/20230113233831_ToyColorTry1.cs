using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToyShopV2.Migrations
{
    public partial class ToyColorTry1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToyId",
                table: "ToyColors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Colors",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ToyColors_ToyId",
                table: "ToyColors",
                column: "ToyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToyColors_Toys_ToyId",
                table: "ToyColors",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToyColors_Toys_ToyId",
                table: "ToyColors");

            migrationBuilder.DropIndex(
                name: "IX_ToyColors_ToyId",
                table: "ToyColors");

            migrationBuilder.DropColumn(
                name: "ToyId",
                table: "ToyColors");

            migrationBuilder.DropColumn(
                name: "Colors",
                table: "CartItems");
        }
    }
}
