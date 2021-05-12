using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Model.Migrations
{
    public partial class AddDescriptionBrandProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BrandProducts",
                nullable: true,
                defaultValueSql: "N'Thương hiệu có mặt trên thị trường với hơn 30 năm..'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "BrandProducts");
        }
    }
}
