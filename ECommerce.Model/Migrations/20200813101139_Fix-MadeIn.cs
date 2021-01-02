using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Model.Migrations
{
    public partial class FixMadeIn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MadeIns_MachineId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MadeInId",
                table: "Products",
                column: "MadeInId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MadeIns_MadeInId",
                table: "Products",
                column: "MadeInId",
                principalTable: "MadeIns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MadeIns_MadeInId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MadeInId",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MadeIns_MachineId",
                table: "Products",
                column: "MachineId",
                principalTable: "MadeIns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
