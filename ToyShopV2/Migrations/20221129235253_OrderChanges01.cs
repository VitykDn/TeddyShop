using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToyShopV2.Migrations
{
    public partial class OrderChanges01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Toys_ToyId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ToyId",
                table: "OrderDetail");

            migrationBuilder.AddColumn<string>(
                name: "ToyName",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToyName",
                table: "OrderDetail");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ToyId",
                table: "OrderDetail",
                column: "ToyId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Toys_ToyId",
                table: "OrderDetail",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
