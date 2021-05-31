using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Model.Migrations
{
    public partial class UpdateModel4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "ProductsOnFirstPages");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "ProductsOnFirstPages");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProductsOnFirstPages");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "ProductsOnFirstPages");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ProductsOnFirstPages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "ProductsOnFirstPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "ProductsOnFirstPages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ProductsOnFirstPages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "ProductsOnFirstPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ProductsOnFirstPages",
                type: "datetime2",
                nullable: true);
        }
    }
}
