using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Model.Migrations
{
    public partial class ProductMediaOrderIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderIndex",
                table: "Medias");

            migrationBuilder.AddColumn<int>(
                name: "OrderIndex",
                table: "Product_Media",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderIndex",
                table: "Product_Media");

            migrationBuilder.AddColumn<int>(
                name: "OrderIndex",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
