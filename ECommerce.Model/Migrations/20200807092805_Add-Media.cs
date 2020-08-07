using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Model.Migrations
{
    public partial class AddMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: false, defaultValueSql: "'https://localhost:44327/assets/data/p35.jpg'"),
                    Path = table.Column<string>(nullable: false, defaultValueSql: "'/assets/data/p35.jpg'"),
                    MediaTypeId = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medias_MediaTypes_MediaTypeId",
                        column: x => x.MediaTypeId,
                        principalTable: "MediaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_Media",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    MediaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Media", x => new { x.ProductId, x.MediaId });
                    table.ForeignKey(
                        name: "FK_Product_Media_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Media_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medias_Link",
                table: "Medias",
                column: "Link",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_MediaTypeId",
                table: "Medias",
                column: "MediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_Name",
                table: "Medias",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_Path",
                table: "Medias",
                column: "Path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaTypes_Name",
                table: "MediaTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Media_MediaId",
                table: "Product_Media",
                column: "MediaId");

            #region MediaType
            migrationBuilder.InsertData(
                table: "MediaTypes",
                columns: new[] { "Name" },
                values: new object[,] {
                    {"Image"},
                    {"Video"},
                });
            #endregion
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Media");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "MediaTypes");
        }
    }
}
