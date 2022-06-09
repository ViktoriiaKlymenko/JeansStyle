using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JeansStyle.DAL.Migrations
{
    public partial class OrderId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Orders_OrderId",
                table: "ProductSizes");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "ProductSizes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Orders_OrderId",
                table: "ProductSizes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Orders_OrderId",
                table: "ProductSizes");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "ProductSizes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Orders_OrderId",
                table: "ProductSizes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
