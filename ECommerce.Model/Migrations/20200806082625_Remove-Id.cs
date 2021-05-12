using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Model.Migrations
{
    public partial class RemoveId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Product_ProductStatus");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Product_Functions");

            migrationBuilder.AlterColumn<float>(
                name: "ThicknessOfClass",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "StoreWarrantyTime",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "InternationalWarrantyTime",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Diameter",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Images",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "ThicknessOfClass",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StoreWarrantyTime",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InternationalWarrantyTime",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Diameter",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Product_ProductStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Product_Functions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
