using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Model.Migrations
{
    public partial class AddCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrandProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
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
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Citys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorClockFaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorClockFaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MadeIns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MadeIns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Desription = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "ProductStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Desription = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Straps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Straps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Waterproofs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waterproofs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Citys_CityId",
                        column: x => x.CityId,
                        principalTable: "Citys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),

                    Name = table.Column<string>(nullable: false),
                    Video = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    PriceDiscount = table.Column<int>(nullable: true),
                    DiscountDateFrom = table.Column<DateTime>(nullable: true),
                    DiscountDateTo = table.Column<DateTime>(nullable: true),
                    Characteristics = table.Column<string>(nullable: true),
                    DescriptionShort = table.Column<string>(nullable: true),
                    DescriptionFull = table.Column<string>(nullable: true),
                    Sku = table.Column<string>(nullable: true),
                    BrandProductId = table.Column<int>(nullable: true),
                    OriginNumber = table.Column<int>(nullable: true),
                    MachineId = table.Column<int>(nullable: true),
                    InternationalWarrantyTime = table.Column<float>(nullable: true),
                    StoreWarrantyTime = table.Column<float>(nullable: true),
                    Diameter = table.Column<string>(nullable: true),
                    ThicknessOfClass = table.Column<float>(nullable: true),
                    BandId = table.Column<int>(nullable: true),
                    StrapId = table.Column<int>(nullable: true),
                    ColorClockFaceId = table.Column<int>(nullable: true),
                    MadeInId = table.Column<int>(nullable: true),
                    StyleId = table.Column<int>(nullable: true),
                    WaterproofId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_BrandProducts_BrandProductId",
                        column: x => x.BrandProductId,
                        principalTable: "BrandProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ColorClockFaces_ColorClockFaceId",
                        column: x => x.ColorClockFaceId,
                        principalTable: "ColorClockFaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_MadeIns_MachineId",
                        column: x => x.MachineId,
                        principalTable: "MadeIns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Straps_StrapId",
                        column: x => x.StrapId,
                        principalTable: "Straps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Styles_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Waterproofs_WaterproofId",
                        column: x => x.WaterproofId,
                        principalTable: "Waterproofs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    DistrictId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wards_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product_Functions",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    FunctionId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Functions", x => new { x.ProductId, x.FunctionId });
                    table.ForeignKey(
                        name: "FK_Product_Functions_Functions_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Functions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Functions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_ProductStatus",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    ProductStatusId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_ProductStatus", x => new { x.ProductId, x.ProductStatusId });
                    table.ForeignKey(
                        name: "FK_Product_ProductStatus_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductStatus_ProductStatus_ProductStatusId",
                        column: x => x.ProductStatusId,
                        principalTable: "ProductStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(nullable: true),
                    WardId = table.Column<int>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Citys_CityId",
                        column: x => x.CityId,
                        principalTable: "Citys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    ReceiverInfo = table.Column<string>(nullable: true),
                    OrderStatusId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CurrentPrice = table.Column<float>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_DistrictId",
                table: "Address",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_WardId",
                table: "Address",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bands_Name",
                table: "Bands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BrandProducts_Name",
                table: "BrandProducts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                table: "Category",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citys_Name",
                table: "Citys",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ColorClockFaces_Name",
                table: "ColorClockFaces",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Functions_Name",
                table: "Functions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_Name",
                table: "Images",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_Name",
                table: "Machines",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MadeIns_Name",
                table: "MadeIns",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Functions_FunctionId",
                table: "Product_Functions",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductStatus_ProductStatusId",
                table: "Product_ProductStatus",
                column: "ProductStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BandId",
                table: "Products",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandProductId",
                table: "Products",
                column: "BrandProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorClockFaceId",
                table: "Products",
                column: "ColorClockFaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MachineId",
                table: "Products",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_StrapId",
                table: "Products",
                column: "StrapId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StyleId",
                table: "Products",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_WaterproofId",
                table: "Products",
                column: "WaterproofId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStatus_Name",
                table: "ProductStatus",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Styles_Name",
                table: "Styles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Straps_Name",
                table: "Straps",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wards_DistrictId",
                table: "Wards",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Waterproofs_Name",
                table: "Waterproofs",
                column: "Name",
                unique: true);

            #region Seed Data

            #region OrderStatus
            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Name", "Desription" },
                values: new object[,] { { "Chờ duyệt", "Đơn hàng vừa được tạo mới và chờ quản lý duyệt!" }, { "Đã duyệt", "Đơn hàng đã được quản lý duyệt!" }, { "Đang vận chuyển", "Đơn hàng vừa được tạo mới và chờ quản lý duyệt!" }, { "Đã thanh toán và chờ giao hàng", "Đơn hàng đã được trả tiền qua các phương thức giao dịch và đang chờ nhận hàng!" }, { "Đã giao hàng", "Đơn hàng đã giao xong và thu tiền của khách nhưng chưa đem về cho quản lý!" }, { "Hoàn thành", "Đơn hàng đã giao xong và quản lý đã cầm được tiền!" }, { "Hủy", "Đơn hàng đã bị hủy!" }, { "Trả lại", "Ví lý do gì đó mà đơn hàng đã bị trả lại!" },
                });
            #endregion

            #region ProductStatus
            migrationBuilder.InsertData(
                table: "ProductStatus",
                columns: new[] { "Name", "Desription" },
                values: new object[,] { { "Bình thường", "Hàng đã ở cửa hàng lâu năm và ổn định!" }, { "Mới", "Hàng mới nhập!" }, { "Bán chạy", "Hàng đang bán chạy!" }, { "Giảm giá", "Hàng đang giảm giá!" }, { "Seccond Hand", "Hàng đã qua sử dụng!" }, { "Phiên bản đặc biệt", "Phiên bản đặc biệt!" }, { "Phiên bản giới hạn", "Phiên bản giới hạn!" }, { "Nhiều người xem", "Nhiều người xem!" }
                });
            #endregion

            #region Band
            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Name" },
                values: new object[,] { { "Thép không rỉ (Inox)" }, { "Titanium" }, { "Xi" }, { "Da" }, { "Da vân nguyên bản" }, { "Dây da giả da cá sấu" }, { "Dây da giả vân" }, { "Dây da giả da" }, { "Nato" }, { "Vải" }, { "Nhựa" }, { "Cao su" }, { "Đá" }, { "gốm" }, { "ceramic" }, { "OYSTER" }, { "JUBILEE" }, { "PRESIDENT" }, { "MILANESE" }, { "BEADS OF RICE" }, { "ROYAL OAK" }, { "BONKLIP" }, { "Twist-O-Flex" }, { "H-link" }, { "Shark Mesh" }, { "Engineer" }, { "Ladder" },
                });
            #endregion

            #region BrandProduct
            migrationBuilder.InsertData(
                table: "BrandProducts",
                columns: new[] { "Name" },
                values: new object[,] {
                    {"Patek Philippe"},
                    {"Tag Heuer"},
                    {"Rolex Swiss Made"},
                    {"Omega"},
                    {"Longines"},
                    {"Tissot"},
                    {"Timex"},
                    {"Calvin Klein"},
                    {"Movado"},
                    {"SEIKO"},
                    {"Citizen"},
                    {"Orient"},
                    {"Casio"},
                    {"Fossil"},
                    {"Michael Kors"},
                    {"Ogival"},
                    {"OP: Olympia Star, Olym Pianus"},
                    {"DW (Daniel Wellington)"},
                    {"Anne Klein"},
                    {"Guess"},
                    {"Breitling"},
                    {"Piaget"},
                    {"Breguet"},
                    {"Zenith"},
                    {"Vacheron Constantin"},
                    {"Audemars Piguet"},
                    {"Hublot"},
                    {"Jaguar"},
                    {"Mido"},
                    {"Candino"},
                    {"Rado Switzerland"},
                    {"Swatch"},
                    {"Century"},
                    {"Certina"},
                    {"Roamer"},
                    {"Perrelet"},
                    {"Chronoswiss"},
                    {"Frederique Constant (FC)"},
                    {"IWC"},
                    {"BulovaBulova"},
                    {"DavenaDavena"},
                    {"Royal CrownRoyal Crown"},
                    {"SunriseSunrise"},
                    {"EarnshawEarnshaw"},
                    {"AlpinaAlpina"},
                    {"TissotTissot"},
                    {"SeikoSeiko"},
                    {"AkribosAkribos"},
                    {"Anne KleinAnne Klein"},
                    {"AolixAolix"},
                    {"ADEE KAYEADEE KAYE"},
                    {"Armani ExchangeArmani Exchange"},
                    {"ArbutusArbutus"},
                    {"B SwissB Swiss"},
                    {"Badgley MischkaBadgley Mischka"},
                    {"Armand NicoletArmand Nicolet"},
                    {"Brooklyn Watch CoBrooklyn Watch Co"},
                    {"BombergBomberg"},
                    {"BallBall"},
                    {"BalmainBalmain"},
                    {"BentleyBentley"},
                    {"BugriBugri"},
                    {"BurgiBurgi"},
                    {"Bruno MagliBruno Magli"},
                    {"BurberryBurberry"},
                    {"Caravelle New YorkCaravelle New York"},
                    {"CasioCasio"},
                    {"CarnivalCarnival"},
                    {"CaravelleCaravelle"},
                    {"Calvin KleinCalvin Klein"},
                    {"CCCPCCCP"},
                    {"CharmexCharmex"},
                    {"Christian Van SantChristian Van Sant"},
                    {"CharriolCharriol"},
                    {"Claude BernardClaude Bernard"},
                    {"CoachCoach"},
                    {"CertinaCertina"},
                    {"Daniel WellingtonDaniel Wellington"},
                    {"CorumCorum"},
                    {"CitizenCitizen"},
                    {"DKNYDKNY"},
                    {"edoxedox"},
                    {"DiorDior"},
                    {"Emporio ArmaniEmporio Armani"},
                    {"FerrariFerrari"},
                    {"EternaEterna"},
                    {"FendiFendi"},
                    {"Elini BarokasElini Barokas"},
                    {"Ferre MilanoFerre Milano"},
                    {"Frederique ConstantFrederique Constant"},
                    {"FUJIFUJI"},
                    {"FossilFossil"},
                    {"FurlaFurla"},
                    {"GCGC"},
                    {"GrovanaGrovana"},
                    {"GemaxGemax"},
                    {"GosttaGostta"},
                    {"GucciGucci"},
                    {"GevrilGevril"},
                    {"Guess CollectionGuess Collection"},
                    {"GuessGuess"},
                    {"Guess WaferGuess Wafer"},
                    {"GV2GV2"},
                    {"HamiltonHamilton"},
                    {"HermesHermes"},
                    {"HubolerHuboler"},
                    {"HublotHublot"},
                    {"GV2 VittoriaGV2 Vittoria"},
                    {"HanboroHanboro"},
                    {"InvictaInvicta"},
                    {"Jacques LemansJacques Lemans"},
                    {"JBWJBW"},
                    {"Juicy CoutureJuicy Couture"},
                    {"LonginesLongines"},
                    {"LUCIEN PICCARDLUCIEN PICCARD"},
                    {"Just CavalliJust Cavalli"},
                    {"Kate SpadeKate Spade"},
                    {"Marc JacobsMarc Jacobs"},
                    {"MATHEY-TISSOTMATHEY-TISSOT"},
                    {"MASERATIMASERATI"},
                    {"Mark & JonesMark & Jones"},
                    {"Maurice LacroixMaurice Lacroix"},
                    {"Mazzucato EgoMazzucato Ego"},
                    {"MONTBLANCMONTBLANC"},
                    {"MelissaMelissa"},
                    {"MidoMido"},
                    {"MovadoMovado"},
                    {"Michael KorsMichael Kors"},
                    {"OmegaOmega"},
                    {"OgivalOgival"},
                    {"OnissOniss"},
                    {"Olym PianusOlym Pianus"},
                    {"Olympia StarOlympia Star"},
                    {"OrisOris"},
                    {"PolicePolice"},
                    {"PeugeotPeugeot"},
                    {"PerreletPerrelet"},
                    {"OrientOrient"},
                    {"Raymond WeilRaymond Weil"},
                    {"Reef TigerReef Tiger"},
                    {"RadoRado"},
                    {"Revue ThommenRevue Thommen"},
                    {"PulsarPulsar"},
                    {"Roberto CavalliRoberto Cavalli"},
                    {"S CoifmanS Coifman"},
                    {"RotaryRotary"},
                    {"Salvatore FerragamoSalvatore Ferragamo"},
                    {"SevenFridaySevenFriday"},
                    {"SkagenSkagen"},
                    {"Serene Marceau DiamondSerene Marceau Diamond"},
                    {"SeahSeah"},
                    {"StuhrlingStuhrling"},
                    {"StarkeStarke"},
                    {"SwarovskiSwarovski"},
                    {"Speake MarinSpeake Marin"},
                    {"TED BAKERTED BAKER"},
                    {"Tory BurchTory Burch"},
                    {"TechnomarineTechnomarine"},
                    {"Tommy BahamaTommy Bahama"},
                    {"Vince CamutoVince Camuto"},
                    {"VictorinoxVictorinox"},
                    {"WengerWenger"},
                    {"versusversus"},
                    {"VersaceVersace"},
                    {"WittnauerWittnauer"},
                    {"X-cerX-cer"},
                    {"Bulova"},
                    {"Davena"},
                    {"Royal Crown"},
                    {"Sunrise"},
                    {"Earnshaw"},
                    {"Alpina"},
                    {"Akribos"},
                    {"Aolix"},
                    {"ADEE KAYE"},
                    {"thương hiệu orient"},
                    {"Armani Exchange"},
                    {"Arbutus"},
                    {"B Swiss"},
                    {"Badgley Mischka"},
                    {"Armand Nicolet"},
                    {"Brooklyn Watch Co"},
                    {"Bomberg"},
                    {"Ball"},
                    {"Balmain"},
                    {"Bentley"},
                    {"Bugri"},
                    {"Burgi"},
                    {"Bruno Magli"},
                    {"Burberry"},
                    {"thương hiệu fouetté (phiên bản giới hạn 99 chiếc trên toàn thế giới)"},
                    {"Caravelle New York"},
                    {"Carnival"},
                    {"Caravelle"},
                    {"CCCP"},
                    {"Charmex"},
                    {"Christian Van Sant"},
                    {"Charriol"},
                    {"Claude Bernard"},
                    {"Coach"},
                    {"Daniel Wellington"},
                    {"Corum"},
                    {"DKNY"},
                    {"edox"},
                    {"Dior"},
                    {"Emporio Armani"},
                    {"Ferrari"},
                    {"Eterna"},
                    {"Fendi"},
                    {"Elini Barokas"},
                    {"Ferre Milano"},
                    {"Frederique Constant"},
                    {"FUJI"},
                    {"Furla"},
                    {"GC"},
                    {"Grovana"},
                    {"Gemax"},
                    {"Gostta"},
                    {"Gucci"},
                    {"Gevril"},
                    {"Guess Collection"},
                    {"Guess Wafer"},
                    {"GV2"},
                    {"Hamilton"},
                    {"Hermes"},
                    {"Huboler"},
                    {"GV2 Vittoria"},
                    {"Hanboro"},
                    {"Invicta"},
                    {"Jacques Lemans"},
                    {"JBW"},
                    {"Juicy Couture"},
                    {"LUCIEN PICCARD"},
                    {"Just Cavalli"},
                    {"Kate Spade"},
                    {"Marc Jacobs"},
                    {"MATHEYTISSOT"},
                    {"MASERATI"},
                    {"Mark & Jones"},
                    {"Maurice Lacroix"},
                    {"Mazzucato Ego"},
                    {"MONTBLANC"},
                    {"Melissa"},
                    {"Oniss"},
                    {"Olym Pianus"},
                    {"Olympia Star"},
                    {"Oris"},
                    {"Police"},
                    {"Peugeot"},
                    {"Raymond Weil"},
                    {"Reef Tiger"},
                    {"Rado"},
                    {"Revue Thommen"},
                    {"Pulsar"},
                    {"Roberto Cavalli"},
                    {"S Coifman"},
                    {"Rotary"},
                    {"Salvatore Ferragamo"},
                    {"SevenFriday"},
                    {"Skagen"},
                    {"Serene Marceau Diamond"},
                    {"Seah"},
                    {"Stuhrling"},
                    {"Starke"},
                    {"Swarovski"},
                    {"Speake Marin"},
                    {"TED BAKER"},
                    {"Tory Burch"},
                    {"Technomarine"},
                    {"Tommy Bahama"},
                    {"Vince Camuto"},
                    {"Victorinox"},
                    {"Wenger"},
                    {"versus"},
                    {"Versace"},
                    {"Wittnauer"},
                    {"Xcer"},
                    {"Doxa"},
                    {"Saga"},
                });
            #endregion

            #region ColorClockFace
            migrationBuilder.InsertData(
                table: "ColorClockFaces",
                columns: new[] { "Name" },
                values: new object[,] {
                    {"Kính cứng"},
                    {"Kính Sapphire"},
                    {""},
                    {"Kính đặc biệt"},
                    {"Kính Hardlex"},
                    {"Kính đặc biệt, Kính Hardlex"}
                });
            #endregion

            #region Function
            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Name" },
                values: new object[,] { { "Lịch ngày" }, { "Lịch ngày giờ" },
                });
            #endregion

            #region Machine
            migrationBuilder.InsertData(
              table: "Machines",
              columns: new[] { "Name" },
              values: new object[,] {
                    {"Pin (Quartz)"},
                    {""},
                    {"Cơ (Automatic)"},
                    {"Năng Lượng Ánh Sáng"},
                    {"Năng Lượng Ánh Sáng, Pin (Quartz)"},
                    {"Kinetic (Vừa Pin – Vừa Tự Động)"},
                    {"Automatic (Tự Động)"},
                    {"Quartz (Pin)"},
            });
            //modelBuilder.Entity<Machine>().HasData(new Machine { Name = "Automatic (Tự động)" });
            //modelBuilder.Entity<Machine>().HasData(new Machine { Name = "Máy cơ" });
            #endregion

            #region MadeIn
            migrationBuilder.InsertData(
              table: "MadeIns",
              columns: new[] { "Name" },
              values: new object[,] {
                    {"Mỹ"},
                    {"Hong Kong"},
                    {"Thụy Sĩ"},
                    {"Anh"},
                    {"Nhật Bản"},
                    {"xuất xứ nhật bản"},
                    {"Italia"},
                    {"Pháp"},
                    {"Đức"},
                    {"xuất xứ hồng kông"},
                    {""},
                    {"Nga"},
                    {"Bỉ"},
                    {"Đan Mạch"},
                    {"Áo"},
                    {"Hàn Quốc"},
                    {"Thụy Sỹ"},
                    {"Thụy Điển"},
            });
            //modelBuilder.Entity<MadeIn>().HasData(new MadeIn { Name = "Thụy sỹ" });
            //modelBuilder.Entity<MadeIn>().HasData(new MadeIn { Name = "Việt nam" });
            #endregion

            #region Strap
            migrationBuilder.InsertData(
              table: "Straps",
              columns: new[] { "Name" },
              values: new object[,] {
                  {"Dây kim loại"},
                    {"Dây da"},
                    {"Dây da, Dây kim loại"},
                    {"Dây nhựa / Cao su"},
                    {"Dây đá cerramic"},
                    {"Thép Không Gỉ"},
                    {""},
                    {"Dây đá cerramic, Thép Không Gỉ"},
                    {"Dây Nhựa, Dây nhựa / Cao su"},
                    {"Dây Nhựa"},
                    {"Dây vải"},
                    {"Dây kim loại, Thép Không Gỉ"},
                    {"Dây TiTanium"},
                    {"Dây kim loại, Dây Nhựa, Dây nhựa / Cao su"},
                    {"Dây da, Dây vải"},
                    {"Dây nhựa / Cao su, Navy Silicone"},
                    {"Dây đá cerramic, Dây kim loại"},
                    {"Dây da, Dây nhựa / Cao su"},
                    {"Dây da, Dây kim loại, Dây nhựa / Cao su"},
                    {"Navy Silicone"},
                    {"Dây đá / Khoáng, Dây kim loại"},
                    {"Dây Nhựa, Thép Không Gỉ"},
                    {"Dây da, Thép Không Gỉ"},
                    {"Dây Nhựa, Dây nhựa / Cao su, Navy Silicone"},
                    {"Thép không rỉ (Inox)"},
                    {"Titanium"},
                    {"Xi"},
                    {"Da"},
                    {"Da vân nguyên bản"},
                    {"Dây da giả da cá sấu"},
                    {"Dây da giả vân"},
                    {"Dây da giả da"},
                    {"Nato"},
                    {"Vải"},
                    {"Nhựa"},
                    {"Cao su"},
                    {"Đá"},
                    {"gốm"},
                    {"ceramic"},
                    {"OYSTER"},
                    {"JUBILEE"},
                    {"PRESIDENT"},
                    {"MILANESE"},
                    {"BEADS OF RICE"},
                    {"ROYAL OAK"},
                    {"BONKLIP"},
                    {"Twist-O-Flex"},
                    {"H-link"},
                    {"Shark Mesh"},
                    {"Engineer"},
                    {"Ladder" }
            });

            #endregion

            #region Style
            migrationBuilder.InsertData(
              table: "Styles",
              columns: new[] { "Name" },
              values: new object[,] {
                  { "Lịch lãm" }, { "Trẻ trung" },
                  { "Quý phái" }, { "Năng động" },
                  {"Sang Trọng, Thời Trang"},
                {"Cá Tính, Sang Trọng, Thời Trang"},
                {"Cá Tính"},
                {"Classic ( Cổ điển ), Sang Trọng"},
                {"Cá Tính, Sang Trọng"},
                {""},
                {"Classic ( Cổ điển ), Sang Trọng, Thời Trang"},
                {"Sang Trọng"},
                {"Classic ( Cổ điển )"},
                {"Thể Thao"},
                {"Cá Tính, Thể Thao"},
                {"Beige, Classic ( Cổ điển ), Sang Trọng"},
                {"Thời Trang"},
                {"Thể Thao, Thời Trang"},
                {"Sang Trọng, Thể Thao"},
                {"Sang Trọng, Thể Thao, Thời Trang"},
                {"Classic ( Cổ điển ), Thể Thao"},
                {"Classic ( Cổ điển ), Thời Trang"},
                {"Cá Tính, Classic ( Cổ điển ), Sang Trọng"},
                {"Cá Tính, Thể Thao, Thời Trang"},
                {"Cá Tính, Classic ( Cổ điển )"},
                {"Cá Tính, Sang Trọng, Thể Thao"},
                {"Cá Tính, Thời Trang"},
                {"Parker"},
                {"Cá Tính, Sang Trọng, Thể Thao, Thời Trang"},
                {"Parker, Sang Trọng"}

            });
            #endregion

            #region Waterproof
            migrationBuilder.InsertData(
              table: "Waterproofs",
              columns: new[] { "Name" },
              values: new object[,] {
                  {"30m/3 ATM/3 Bar" },
                    {"50m/5 ATM/5 Bar:" },
                    {"100m/10 ATM/10 Bar:" },
                    {"200m/20 ATM/20 Bar" },
                    {"770m/77 ATM/77 Bar" },
                    {"1000m/100 ATM/100 Bar" },
                    {"2000m/200 ATM/200 Bar" },
            });
            #endregion

            #region Category
            migrationBuilder.InsertData(
              table: "Category",
              columns: new[] { "Name" },
              values: new object[,] {
                    {"Đồng hồ nữ"},
                    {"Đồng hồ nam"},
                    {"Đồng hồ cặp"},
                    {"Đồng hồ trẻ em"},
                    {"Chưa phân loại"},
            });
            #endregion


            #region AspNetRoles
            migrationBuilder.InsertData(
              table: "AspNetRoles",
              columns: new[] { "Id", "Name", "NormalizedName", },
              values: new object[,] {
                  {Guid.NewGuid().ToString(), "Admin","Admin" },
                  {Guid.NewGuid().ToString(), "Devleloper","Devleloper" },
                  {Guid.NewGuid().ToString(), "Agency","Agency" },
                  {Guid.NewGuid().ToString(), "Collaborators","Collaborators" },
                  {Guid.NewGuid().ToString(), "Guest","Guest" },

            });
            #endregion

            #endregion
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "Product_Functions");

            migrationBuilder.DropTable(
                name: "Product_ProductStatus");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductStatus");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "Bands");

            migrationBuilder.DropTable(
                name: "BrandProducts");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "ColorClockFaces");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "MadeIns");

            migrationBuilder.DropTable(
                name: "Straps");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "Waterproofs");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Citys");
        }
    }
}
