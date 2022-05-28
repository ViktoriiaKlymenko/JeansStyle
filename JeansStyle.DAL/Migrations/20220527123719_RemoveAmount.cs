using Microsoft.EntityFrameworkCore.Migrations;

namespace JeansStyle.DAL.Migrations
{
    public partial class RemoveAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Products_ProductsId",
                table: "ProductSizes");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ProductSizes",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSizes_ProductsId",
                table: "ProductSizes",
                newName: "IX_ProductSizes_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Products_ProductId",
                table: "ProductSizes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Products_ProductId",
                table: "ProductSizes");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductSizes",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSizes_ProductId",
                table: "ProductSizes",
                newName: "IX_ProductSizes_ProductsId");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Products_ProductsId",
                table: "ProductSizes",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
