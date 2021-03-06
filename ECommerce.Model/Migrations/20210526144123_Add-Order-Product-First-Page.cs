﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Model.Migrations
{
    public partial class AddOrderProductFirstPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ProductsOnFirstPages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ProductsOnFirstPages");
        }
    }
}
