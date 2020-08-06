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
                    InternationalWarrantyTime = table.Column<int>(nullable: true),
                    StoreWarrantyTime = table.Column<int>(nullable: true),
                    Diameter = table.Column<int>(nullable: true),
                    ThicknessOfClass = table.Column<int>(nullable: true),
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

            #region City
            migrationBuilder.InsertData(
                table: "Citys",
                columns: new[] { "Name", "Sort" },
                values: new object[,] { { "Hồ Chí Minh", 1 }, { "Hà Nội", 2 }, { "Khác", 64 }, { "An Giang", 3 }, { "Bắc Giang", 5 }, { "Bắc Kạn", 6 }, { "Bạc Liêu", 7 }, { "Bắc Ninh", 8 }, { "Bình Dương", 10 }, { "Bình Phước", 11 }, { "Bình Thuận", 12 }, { "Bình Định", 13 }, { "Cà Mau", 14 }, { "Cần Thơ", 15 }, { "Cao Bằng", 16 }, { "Gia Lai", 17 }, { "Hà Giang", 18 }, { "Hà Nam", 19 }, { "Hà Tĩnh", 20 }, { "Hải Dương", 21 }, { "Hải Phòng", 22 }, { "Hậu Giang", 23 }, { "Hoà Bình", 24 }, { "Hưng Yên", 25 }, { "Khánh Hòa", 26 }, { "Kiên Giang", 27 }, { "Kon Tum", 28 }, { "Lai Châu", 29 }, { "Lâm Đồng", 30 }, { "Lạng Sơn", 31 }, { "Lào Cai", 32 }, { "Long An", 33 }, { "Nam Định", 34 }, { "Nghệ An", 35 }, { "Ninh Bình", 36 }, { "Ninh Thuận", 37 }, { "Phú Thọ", 38 }, { "Phú Yên", 39 }, { "Quảng Bình", 40 }, { "Quảng Nam", 41 }, { "Quảng Ngãi", 42 }, { "Quảng Ninh", 43 }, { "Quảng Trị", 44 }, { "Sóc Trăng", 45 }, { "Sơn La", 46 }, { "Tây Ninh", 47 }, { "Thái Bình", 48 }, { "Thái Nguyên", 49 }, { "Thanh Hóa", 50 }, { "Tiền Giang", 52 }, { "Trà Vinh", 53 }, { "Tuyên Quang", 54 }, { "Vĩnh Long", 55 }, { "Vĩnh Phúc", 56 }, { "Yên Bái", 57 }, { "Đà Nẵng", 58 }, { "Đắk Lắk", 59 }, { "Đắk Nông", 60 }, { "Điện Biên", 61 }, { "Đồng Nai", 62 }, { "Đồng Tháp", 63 }, { "Bà Rịa-Vũng Tàu", 9 }, { "Bến Tre", 4 }, { "Thừa Thiên Huế", 51 }
                });
            #endregion

            #region District
            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Name", "Sort", "CityId" },
                values: new object[,] { { "Quận Ba Đình", 0, 2 }, { "Quận Hoàn Kiếm", 0, 2 }, { "Quận Tây Hồ", 0, 2 }, { "Quận Long Biên", 0, 2 }, { "Quận Cầu Giấy", 0, 2 }, { "Quận Đống Đa", 0, 2 }, { "Quận Hai Bà Trưng", 0, 2 }, { "Quận Hoàng Mai", 0, 2 }, { "Quận Thanh Xuân", 0, 2 }, { "Huyện Sóc Sơn", 0, 2 }, { "Huyện Đông Anh", 0, 2 }, { "Huyện Gia Lâm", 0, 2 }, { "Quận Nam Từ Liêm", 0, 2 }, { "Huyện Thanh Trì", 0, 2 }, { "Quận Bắc Từ Liêm", 0, 2 }, { "Thành phố Hà Giang", 0, 17 }, { "Huyện Đồng Văn", 0, 17 }, { "Huyện Mèo Vạc", 0, 17 }, { "Huyện Yên Minh", 0, 17 }, { "Huyện Quản Bạ", 0, 17 }, { "Huyện Vị Xuyên", 0, 17 }, { "Huyện Bắc Mê", 0, 17 }, { "Huyện Hoàng Su Phì", 0, 17 }, { "Huyện Xín Mần", 0, 17 }, { "Huyện Bắc Quang", 0, 17 }, { "Huyện Quang Bình", 0, 17 }, { "Thành phố Cao Bằng", 0, 15 }, { "Huyện Bảo Lâm", 0, 15 }, { "Huyện Bảo Lạc", 0, 15 }, { "Huyện Thông Nông", 0, 15 }, { "Huyện Hà Quảng", 0, 15 }, { "Huyện Trà Lĩnh", 0, 15 }, { "Huyện Trùng Khánh", 0, 15 }, { "Huyện Hạ Lang", 0, 15 }, { "Huyện Quảng Uyên", 0, 15 }, { "Huyện Phục Hòa", 0, 15 }, { "Huyện Hòa An", 0, 15 }, { "Huyện Nguyên Bình", 0, 15 }, { "Huyện Thạch An", 0, 15 }, { "Thành Phố Bắc Kạn", 0, 6 }, { "Huyện Pác Nặm", 0, 6 }, { "Huyện Ba Bể", 0, 6 }, { "Huyện Ngân Sơn", 0, 6 }, { "Huyện Bạch Thông", 0, 6 }, { "Huyện Chợ Đồn", 0, 6 }, { "Huyện Chợ Mới", 0, 6 }, { "Huyện Na Rì", 0, 6 }, { "Thành phố Tuyên Quang", 0, 52 }, { "Huyện Lâm Bình", 0, 52 }, { "Huyện Na Hang", 0, 52 }, { "Huyện Chiêm Hóa", 0, 52 }, { "Huyện Hàm Yên", 0, 52 }, { "Huyện Yên Sơn", 0, 52 }, { "Huyện Sơn Dương", 0, 52 }, { "Thành phố Lào Cai", 0, 31 }, { "Huyện Bát Xát", 0, 31 }, { "Huyện Mường Khương", 0, 31 }, { "Huyện Si Ma Cai", 0, 31 }, { "Huyện Bắc Hà", 0, 31 }, { "Huyện Bảo Thắng", 0, 31 }, { "Huyện Bảo Yên", 0, 31 }, { "Huyện Sa Pa", 0, 31 }, { "Huyện Văn Bàn", 0, 31 }, { "Thành phố Điện Biên Phủ", 0, 59 }, { "Thị Xã Mường Lay", 0, 59 }, { "Huyện Mường Nhé", 0, 59 }, { "Huyện Mường Chà", 0, 59 }, { "Huyện Tủa Chùa", 0, 59 }, { "Huyện Tuần Giáo", 0, 59 }, { "Huyện Điện Biên", 0, 59 }, { "Huyện Điện Biên Đông", 0, 59 }, { "Huyện Mường Ảng", 0, 59 }, { "Huyện Nậm Pồ", 0, 59 }, { "Thành phố Lai Châu", 0, 28 }, { "Huyện Tam Đường", 0, 28 }, { "Huyện Mường Tè", 0, 28 }, { "Huyện Sìn Hồ", 0, 28 }, { "Huyện Phong Thổ", 0, 28 }, { "Huyện Than Uyên", 0, 28 }, { "Huyện Tân Uyên", 0, 28 }, { "Huyện Nậm Nhùn", 0, 28 }, { "Thành phố Sơn La", 0, 45 }, { "Huyện Quỳnh Nhai", 0, 45 }, { "Huyện Thuận Châu", 0, 45 }, { "Huyện Mường La", 0, 45 }, { "Huyện Bắc Yên", 0, 45 }, { "Huyện Phù Yên", 0, 45 }, { "Huyện Mộc Châu", 0, 45 }, { "Huyện Yên Châu", 0, 45 }, { "Huyện Mai Sơn", 0, 45 }, { "Huyện Sông Mã", 0, 45 }, { "Huyện Sốp Cộp", 0, 45 }, { "Huyện Vân Hồ", 0, 45 }, { "Thành phố Yên Bái", 0, 55 }, { "Thị xã Nghĩa Lộ", 0, 55 }, { "Huyện Lục Yên", 0, 55 }, { "Huyện Văn Yên", 0, 55 }, { "Huyện Mù Căng Chải", 0, 55 }, { "Huyện Trấn Yên", 0, 55 }, { "Huyện Trạm Tấu", 0, 55 }, { "Huyện Văn Chấn", 0, 55 }, { "Huyện Yên Bình", 0, 55 }, { "Thành phố Hòa Bình", 0, 23 }, { "Huyện Đà Bắc", 0, 23 }, { "Huyện Kỳ Sơn", 0, 23 }, { "Huyện Lương Sơn", 0, 23 }, { "Huyện Kim Bôi", 0, 23 }, { "Huyện Cao Phong", 0, 23 }, { "Huyện Tân Lạc", 0, 23 }, { "Huyện Mai Châu", 0, 23 }, { "Huyện Lạc Sơn", 0, 23 }, { "Huyện Yên Thủy", 0, 23 }, { "Huyện Lạc Thủy", 0, 23 }, { "Thành phố Thái Nguyên", 0, 48 }, { "Thành phố Sông Công", 0, 48 }, { "Huyện Định Hóa", 0, 48 }, { "Huyện Phú Lương", 0, 48 }, { "Huyện Đồng Hỷ", 0, 48 }, { "Huyện Võ Nhai", 0, 48 }, { "Huyện Đại Từ", 0, 48 }, { "Thị xã Phổ Yên", 0, 48 }, { "Huyện Phú Bình", 0, 48 }, { "Thành phố Lạng Sơn", 0, 30 }, { "Huyện Tràng Định", 0, 30 }, { "Huyện Bình Gia", 0, 30 }, { "Huyện Văn Lãng", 0, 30 }, { "Huyện Cao Lộc", 0, 30 }, { "Huyện Văn Quan", 0, 30 }, { "Huyện Bắc Sơn", 0, 30 }, { "Huyện Hữu Lũng", 0, 30 }, { "Huyện Chi Lăng", 0, 30 }, { "Huyện Lộc Bình", 0, 30 }, { "Huyện Đình Lập", 0, 30 }, { "Thành phố Hạ Long", 0, 42 }, { "Thành phố Móng Cái", 0, 42 }, { "Thành phố Cẩm Phả", 0, 42 }, { "Thành phố Uông Bí", 0, 42 }, { "Huyện Bình Liêu", 0, 42 }, { "Huyện Tiên Yên", 0, 42 }, { "Huyện Đầm Hà", 0, 42 }, { "Huyện Hải Hà", 0, 42 }, { "Huyện Ba Chẽ", 0, 42 }, { "Huyện Vân Đồn", 0, 42 }, { "Huyện Hoành Bồ", 0, 42 }, { "Thị xã Đông Triều", 0, 42 }, { "Thị xã Quảng Yên", 0, 42 }, { "Huyện Cô Tô", 0, 42 }, { "Thành phố Bắc Giang", 0, 5 }, { "Huyện Yên Thế", 0, 5 }, { "Huyện Tân Yên", 0, 5 }, { "Huyện Lạng Giang", 0, 5 }, { "Huyện Lục Nam", 0, 5 }, { "Huyện Lục Ngạn", 0, 5 }, { "Huyện Sơn Động", 0, 5 }, { "Huyện Yên Dũng", 0, 5 }, { "Huyện Việt Yên", 0, 5 }, { "Huyện Hiệp Hòa", 0, 5 }, { "Thành phố Việt Trì", 0, 37 }, { "Thị xã Phú Thọ", 0, 37 }, { "Huyện Đoan Hùng", 0, 37 }, { "Huyện Hạ Hòa", 0, 37 }, { "Huyện Thanh Ba", 0, 37 }, { "Huyện Phù Ninh", 0, 37 }, { "Huyện Yên Lập", 0, 37 }, { "Huyện Cẩm Khê", 0, 37 }, { "Huyện Tam Nông", 0, 37 }, { "Huyện Lâm Thao", 0, 37 }, { "Huyện Thanh Sơn", 0, 37 }, { "Huyện Thanh Thuỷ", 0, 37 }, { "Huyện Tân Sơn", 0, 37 }, { "Thành phố Vĩnh Yên", 0, 54 }, { "Thị xã Phúc Yên", 0, 54 }, { "Huyện Lập Thạch", 0, 54 }, { "Huyện Tam Dương", 0, 54 }, { "Huyện Tam Đảo", 0, 54 }, { "Huyện Bình Xuyên", 0, 54 }, { "Huyện Mê Linh", 0, 2 }, { "Huyện Yên Lạc", 0, 54 }, { "Huyện Vĩnh Tường", 0, 54 }, { "Huyện Sông Lô", 0, 54 }, { "Thành phố Bắc Ninh", 0, 8 }, { "Huyện Yên Phong", 0, 8 }, { "Huyện Quế Võ", 0, 8 }, { "Huyện Tiên Du", 0, 8 }, { "Thị xã Từ Sơn", 0, 8 }, { "Huyện Thuận Thành", 0, 8 }, { "Huyện Gia Bình", 0, 8 }, { "Huyện Lương Tài", 0, 8 }, { "Quận Hà Đông", 0, 2 }, { "Thị xã Sơn Tây", 0, 2 }, { "Huyện Ba Vì", 0, 2 }, { "Huyện Phúc Thọ", 0, 2 }, { "Huyện Đan Phượng", 0, 2 }, { "Huyện Hoài Đức", 0, 2 }, { "Huyện Quốc Oai", 0, 2 }, { "Huyện Thạch Thất", 0, 2 }, { "Huyện Chương Mỹ", 0, 2 }, { "Huyện Thanh Oai", 0, 2 }, { "Huyện Thường Tín", 0, 2 }, { "Huyện Phú Xuyên", 0, 2 }, { "Huyện Ứng Hòa", 0, 2 }, { "Huyện Mỹ Đức", 0, 2 }, { "Thành phố Hải Dương", 0, 20 }, { "Thị xã Chí Linh", 0, 20 }, { "Huyện Nam Sách", 0, 20 }, { "Huyện Kinh Môn", 0, 20 }, { "Huyện Kim Thành", 0, 20 }, { "Huyện Thanh Hà", 0, 20 }, { "Huyện Cẩm Giàng", 0, 20 }, { "Huyện Bình Giang", 0, 20 }, { "Huyện Gia Lộc", 0, 20 }, { "Huyện Tứ Kỳ", 0, 20 }, { "Huyện Ninh Giang", 0, 20 }, { "Huyện Thanh Miện", 0, 20 }, { "Quận Hồng Bàng", 0, 21 }, { "Quận Ngô Quyền", 0, 21 }, { "Quận Lê Chân", 0, 21 }, { "Quận Hải An", 0, 21 }, { "Quận Kiến An", 0, 21 }, { "Quận Đồ Sơn", 0, 21 }, { "Quận Dương Kinh", 0, 21 }, { "Huyện Thủy Nguyên", 0, 21 }, { "Huyện An Dương", 0, 21 }, { "Huyện An Lão", 0, 21 }, { "Huyện Kiến Thuỵ", 0, 21 }, { "Huyện Tiên Lãng", 0, 21 }, { "Huyện Vĩnh Bảo", 0, 21 }, { "Huyện Cát Hải", 0, 21 }, { "Huyện Bạch Long Vĩ", 0, 21 }, { "Thành phố Hưng Yên", 0, 24 }, { "Huyện Văn Lâm", 0, 24 }, { "Huyện Văn Giang", 0, 24 }, { "Huyện Yên Mỹ", 0, 24 }, { "Huyện Mỹ Hào", 0, 24 }, { "Huyện Ân Thi", 0, 24 }, { "Huyện Khoái Châu", 0, 24 }, { "Huyện Kim Động", 0, 24 }, { "Huyện Tiên Lữ", 0, 24 }, { "Huyện Phù Cừ", 0, 24 }, { "Thành phố Thái Bình", 0, 47 }, { "Huyện Quỳnh Phụ", 0, 47 }, { "Huyện Hưng Hà", 0, 47 }, { "Huyện Đông Hưng", 0, 47 }, { "Huyện Thái Thụy", 0, 47 }, { "Huyện Tiền Hải", 0, 47 }, { "Huyện Kiến Xương", 0, 47 }, { "Huyện Vũ Thư", 0, 47 }, { "Thành phố Phủ Lý", 0, 18 }, { "Huyện Duy Tiên", 0, 18 }, { "Huyện Kim Bảng", 0, 18 }, { "Huyện Thanh Liêm", 0, 18 }, { "Huyện Bình Lục", 0, 18 }, { "Huyện Lý Nhân", 0, 18 }, { "Thành phố Nam Định", 0, 33 }, { "Huyện Mỹ Lộc", 0, 33 }, { "Huyện Vụ Bản", 0, 33 }, { "Huyện Ý Yên", 0, 33 }, { "Huyện Nghĩa Hưng", 0, 33 }, { "Huyện Nam Trực", 0, 33 }, { "Huyện Trực Ninh", 0, 33 }, { "Huyện Xuân Trường", 0, 33 }, { "Huyện Giao Thủy", 0, 33 }, { "Huyện Hải Hậu", 0, 33 }, { "Thành phố Ninh Bình", 0, 35 }, { "Thành phố Tam Điệp", 0, 35 }, { "Huyện Nho Quan", 0, 35 }, { "Huyện Gia Viễn", 0, 35 }, { "Huyện Hoa Lư", 0, 35 }, { "Huyện Yên Khánh", 0, 35 }, { "Huyện Kim Sơn", 0, 35 }, { "Huyện Yên Mô", 0, 35 }, { "Thành phố Thanh Hóa", 0, 49 }, { "Thị xã Bỉm Sơn", 0, 49 }, { "Thành phố Sầm Sơn", 0, 49 }, { "Huyện Mường Lát", 0, 49 }, { "Huyện Quan Hóa", 0, 49 }, { "Huyện Bá Thước", 0, 49 }, { "Huyện Quan Sơn", 0, 49 }, { "Huyện Lang Chánh", 0, 49 }, { "Huyện Ngọc Lặc", 0, 49 }, { "Huyện Cẩm Thủy", 0, 49 }, { "Huyện Thạch Thành", 0, 49 }, { "Huyện Hà Trung", 0, 49 }, { "Huyện Vĩnh Lộc", 0, 49 }, { "Huyện Yên Định", 0, 49 }, { "Huyện Thọ Xuân", 0, 49 }, { "Huyện Thường Xuân", 0, 49 }, { "Huyện Triệu Sơn", 0, 49 }, { "Huyện Thiệu Hóa", 0, 49 }, { "Huyện Hoằng Hóa", 0, 49 }, { "Huyện Hậu Lộc", 0, 49 }, { "Huyện Nga Sơn", 0, 49 }, { "Huyện Như Xuân", 0, 49 }, { "Huyện Như Thanh", 0, 49 }, { "Huyện Nông Cống", 0, 49 }, { "Huyện Đông Sơn", 0, 49 }, { "Huyện Quảng Xương", 0, 49 }, { "Huyện Tĩnh Gia", 0, 49 }, { "Thành phố Vinh", 0, 34 }, { "Thị xã Cửa Lò", 0, 34 }, { "Thị xã Thái Hòa", 0, 34 }, { "Huyện Quế Phong", 0, 34 }, { "Huyện Quỳ Châu", 0, 34 }, { "Huyện Kỳ Sơn", 0, 34 }, { "Huyện Tương Dương", 0, 34 }, { "Huyện Nghĩa Đàn", 0, 34 }, { "Huyện Quỳ Hợp", 0, 34 }, { "Huyện Quỳnh Lưu", 0, 34 }, { "Huyện Con Cuông", 0, 34 }, { "Huyện Tân Kỳ", 0, 34 }, { "Huyện Anh Sơn", 0, 34 }, { "Huyện Diễn Châu", 0, 34 }, { "Huyện Yên Thành", 0, 34 }, { "Huyện Đô Lương", 0, 34 }, { "Huyện Thanh Chương", 0, 34 }, { "Huyện Nghi Lộc", 0, 34 }, { "Huyện Nam Đàn", 0, 34 }, { "Huyện Hưng Nguyên", 0, 34 }, { "Thị xã Hoàng Mai", 0, 34 }, { "Thành phố Hà Tĩnh", 0, 19 }, { "Thị xã Hồng Lĩnh", 0, 19 }, { "Huyện Hương Sơn", 0, 19 }, { "Huyện Đức Thọ", 0, 19 }, { "Huyện Vũ Quang", 0, 19 }, { "Huyện Nghi Xuân", 0, 19 }, { "Huyện Can Lộc", 0, 19 }, { "Huyện Hương Khê", 0, 19 }, { "Huyện Thạch Hà", 0, 19 }, { "Huyện Cẩm Xuyên", 0, 19 }, { "Huyện Kỳ Anh", 0, 19 }, { "Huyện Lộc Hà", 0, 19 }, { "Thị xã Kỳ Anh", 0, 19 }, { "Thành Phố Đồng Hới", 0, 39 }, { "Huyện Minh Hóa", 0, 39 }, { "Huyện Tuyên Hóa", 0, 39 }, { "Huyện Quảng Trạch", 0, 39 }, { "Huyện Bố Trạch", 0, 39 }, { "Huyện Quảng Ninh", 0, 39 }, { "Huyện Lệ Thủy", 0, 39 }, { "Thị xã Ba Đồn", 0, 39 }, { "Thành phố Đông Hà", 0, 43 }, { "Thị xã Quảng Trị", 0, 43 }, { "Huyện Vĩnh Linh", 0, 43 }, { "Huyện Hướng Hóa", 0, 43 }, { "Huyện Gio Linh", 0, 43 }, { "Huyện Đakrông", 0, 43 }, { "Huyện Cam Lộ", 0, 43 }, { "Huyện Triệu Phong", 0, 43 }, { "Huyện Hải Lăng", 0, 43 }, { "Thành phố Huế", 0, 64 }, { "Huyện Phong Điền", 0, 64 }, { "Huyện Quảng Điền", 0, 64 }, { "Huyện Phú Vang", 0, 64 }, { "Thị xã Hương Thủy", 0, 64 }, { "Thị xã Hương Trà", 0, 64 }, { "Huyện A Lưới", 0, 64 }, { "Huyện Phú Lộc", 0, 64 }, { "Huyện Nam Đông", 0, 64 }, { "Quận Liên Chiểu", 0, 56 }, { "Quận Thanh Khê", 0, 56 }, { "Quận Hải Châu", 0, 56 }, { "Quận Sơn Trà", 0, 56 }, { "Quận Ngũ Hành Sơn", 0, 56 }, { "Quận Cẩm Lệ", 0, 56 }, { "Huyện Hòa Vang", 0, 56 }, { "Thành phố Tam Kỳ", 0, 40 }, { "Thành phố Hội An", 0, 40 }, { "Huyện Tây Giang", 0, 40 }, { "Huyện Đông Giang", 0, 40 }, { "Huyện Đại Lộc", 0, 40 }, { "Thị xã Điện Bàn", 0, 40 }, { "Huyện Duy Xuyên", 0, 40 }, { "Huyện Quế Sơn", 0, 40 }, { "Huyện Nam Giang", 0, 40 }, { "Huyện Phước Sơn", 0, 40 }, { "Huyện Hiệp Đức", 0, 40 }, { "Huyện Thăng Bình", 0, 40 }, { "Huyện Tiên Phước", 0, 40 }, { "Huyện Bắc Trà My", 0, 40 }, { "Huyện Nam Trà My", 0, 40 }, { "Huyện Núi Thành", 0, 40 }, { "Huyện Phú Ninh", 0, 40 }, { "Huyện Nông Sơn", 0, 40 }, { "Thành phố Quảng Ngãi", 0, 41 }, { "Huyện Bình Sơn", 0, 41 }, { "Huyện Trà Bồng", 0, 41 }, { "Huyện Tây Trà", 0, 41 }, { "Huyện Sơn Tịnh", 0, 41 }, { "Huyện Tư Nghĩa", 0, 41 }, { "Huyện Sơn Hà", 0, 41 }, { "Huyện Sơn Tây", 0, 41 }, { "Huyện Minh Long", 0, 41 }, { "Huyện Nghĩa Hành", 0, 41 }, { "Huyện Mộ Đức", 0, 41 }, { "Huyện Đức Phổ", 0, 41 }, { "Huyện Ba Tơ", 0, 41 }, { "Huyện Lý Sơn", 0, 41 }, { "Thành phố Quy Nhơn", 0, 12 }, { "Huyện An Lão", 0, 12 }, { "Huyện Hoài Nhơn", 0, 12 }, { "Huyện Hoài Ân", 0, 12 }, { "Huyện Phù Mỹ", 0, 12 }, { "Huyện Vĩnh Thạnh", 0, 12 }, { "Huyện Tây Sơn", 0, 12 }, { "Huyện Phù Cát", 0, 12 }, { "Thị xã An Nhơn", 0, 12 }, { "Huyện Tuy Phước", 0, 12 }, { "Huyện Vân Canh", 0, 12 }, { "Thành phố Tuy Hòa", 0, 38 }, { "Thị xã Sông Cầu", 0, 38 }, { "Huyện Đồng Xuân", 0, 38 }, { "Huyện Tuy An", 0, 38 }, { "Huyện Sơn Hòa", 0, 38 }, { "Huyện Sông Hinh", 0, 38 }, { "Huyện Tây Hòa", 0, 38 }, { "Huyện Phú Hòa", 0, 38 }, { "Huyện Đông Hòa", 0, 38 }, { "Thành phố Nha Trang", 0, 25 }, { "Thành phố Cam Ranh", 0, 25 }, { "Huyện Cam Lâm", 0, 25 }, { "Huyện Vạn Ninh", 0, 25 }, { "Thị xã Ninh Hòa", 0, 25 }, { "Huyện Khánh Vĩnh", 0, 25 }, { "Huyện Diên Khánh", 0, 25 }, { "Huyện Khánh Sơn", 0, 25 }, { "Huyện Trường Sa", 0, 25 }, { "Thành phố Phan Rang-Tháp Chàm", 0, 36 }, { "Huyện Bác Ái", 0, 36 }, { "Huyện Ninh Sơn", 0, 36 }, { "Huyện Ninh Hải", 0, 36 }, { "Huyện Ninh Phước", 0, 36 }, { "Huyện Thuận Bắc", 0, 36 }, { "Huyện Thuận Nam", 0, 36 }, { "Thành phố Phan Thiết", 0, 11 }, { "Thị xã La Gi", 0, 11 }, { "Huyện Tuy Phong", 0, 11 }, { "Huyện Bắc Bình", 0, 11 }, { "Huyện Hàm Thuận Bắc", 0, 11 }, { "Huyện Hàm Thuận Nam", 0, 11 }, { "Huyện Tánh Linh", 0, 11 }, { "Huyện Đức Linh", 0, 11 }, { "Huyện Hàm Tân", 0, 11 }, { "Huyện Phú Quí", 0, 11 }, { "Thành phố Kon Tum", 0, 27 }, { "Huyện Đắk Glei", 0, 27 }, { "Huyện Ngọc Hồi", 0, 27 }, { "Huyện Đắk Tô", 0, 27 }, { "Huyện Kon Plông", 0, 27 }, { "Huyện Kon Rẫy", 0, 27 }, { "Huyện Đắk Hà", 0, 27 }, { "Huyện Sa Thầy", 0, 27 }, { "Huyện Tu Mơ Rông", 0, 27 }, { "Huyện Ia H' Drai", 0, 27 }, { "Thành phố Pleiku", 0, 16 }, { "Thị xã An Khê", 0, 16 }, { "Thị xã Ayun Pa", 0, 16 }, { "Huyện KBang", 0, 16 }, { "Huyện Đăk Đoa", 0, 16 }, { "Huyện Chư Păh", 0, 16 }, { "Huyện Ia Grai", 0, 16 }, { "Huyện Mang Yang", 0, 16 }, { "Huyện Kông Chro", 0, 16 }, { "Huyện Đức Cơ", 0, 16 }, { "Huyện Chư Prông", 0, 16 }, { "Huyện Chư Sê", 0, 16 }, { "Huyện Đăk Pơ", 0, 16 }, { "Huyện Ia Pa", 0, 16 }, { "Huyện Krông Pa", 0, 16 }, { "Huyện Phú Thiện", 0, 16 }, { "Huyện Chư Pưh", 0, 16 }, { "Thành phố Buôn Ma Thuột", 0, 57 }, { "Thị Xã Buôn Hồ", 0, 57 }, { "Huyện Ea H'leo", 0, 57 }, { "Huyện Ea Súp", 0, 57 }, { "Huyện Buôn Đôn", 0, 57 }, { "Huyện Cư M'gar", 0, 57 }, { "Huyện Krông Búk", 0, 57 }, { "Huyện Krông Năng", 0, 57 }, { "Huyện Ea Kar", 0, 57 }, { "Huyện M'Đrắk", 0, 57 }, { "Huyện Krông Bông", 0, 57 }, { "Huyện Krông Pắc", 0, 57 }, { "Huyện Krông A Na", 0, 57 }, { "Huyện Lắk", 0, 57 }, { "Huyện Cư Kuin", 0, 57 }, { "Thị xã Gia Nghĩa", 0, 58 }, { "Huyện Đăk Glong", 0, 58 }, { "Huyện Cư Jút", 0, 58 }, { "Huyện Đắk Mil", 0, 58 }, { "Huyện Krông Nô", 0, 58 }, { "Huyện Đắk Song", 0, 58 }, { "Huyện Đắk R'Lấp", 0, 58 }, { "Huyện Tuy Đức", 0, 58 }, { "Thành phố Đà Lạt", 0, 29 }, { "Thành phố Bảo Lộc", 0, 29 }, { "Huyện Đam Rông", 0, 29 }, { "Huyện Lạc Dương", 0, 29 }, { "Huyện Lâm Hà", 0, 29 }, { "Huyện Đơn Dương", 0, 29 }, { "Huyện Đức Trọng", 0, 29 }, { "Huyện Di Linh", 0, 29 }, { "Huyện Bảo Lâm", 0, 29 }, { "Huyện Đạ Huoai", 0, 29 }, { "Huyện Đạ Tẻh", 0, 29 }, { "Huyện Cát Tiên", 0, 29 }, { "Thị xã Phước Long", 0, 10 }, { "Thị xã Đồng Xoài", 0, 10 }, { "Thị xã Bình Long", 0, 10 }, { "Huyện Bù Gia Mập", 0, 10 }, { "Huyện Lộc Ninh", 0, 10 }, { "Huyện Bù Đốp", 0, 10 }, { "Huyện Hớn Quản", 0, 10 }, { "Huyện Đồng Phú", 0, 10 }, { "Huyện Bù Đăng", 0, 10 }, { "Huyện Chơn Thành", 0, 10 }, { "Huyện Phú Riềng", 0, 10 }, { "Thành phố Tây Ninh", 0, 46 }, { "Huyện Tân Biên", 0, 46 }, { "Huyện Tân Châu", 0, 46 }, { "Huyện Dương Minh Châu", 0, 46 }, { "Huyện Châu Thành", 0, 46 }, { "Huyện Hòa Thành", 0, 46 }, { "Huyện Gò Dầu", 0, 46 }, { "Huyện Bến Cầu", 0, 46 }, { "Huyện Trảng Bàng", 0, 46 }, { "Thành phố Thủ Dầu Một", 0, 9 }, { "Huyện Bàu Bàng", 0, 9 }, { "Huyện Dầu Tiếng", 0, 9 }, { "Thị xã Bến Cát", 0, 9 }, { "Huyện Phú Giáo", 0, 9 }, { "Thị xã Tân Uyên", 0, 9 }, { "Thị xã Dĩ An", 0, 9 }, { "Thị xã Thuận An", 0, 9 }, { "Huyện Bắc Tân Uyên", 0, 9 }, { "Thành phố Biên Hòa", 0, 60 }, { "Thị xã Long Khánh", 0, 60 }, { "Huyện Tân Phú", 0, 60 }, { "Huyện Vĩnh Cửu", 0, 60 }, { "Huyện Định Quán", 0, 60 }, { "Huyện Trảng Bom", 0, 60 }, { "Huyện Thống Nhất", 0, 60 }, { "Huyện Cẩm Mỹ", 0, 60 }, { "Huyện Long Thành", 0, 60 }, { "Huyện Xuân Lộc", 0, 60 }, { "Huyện Nhơn Trạch", 0, 60 }, { "Thành phố Vũng Tàu", 0, 62 }, { "Thành phố Bà Rịa", 0, 62 }, { "Huyện Châu Đức", 0, 62 }, { "Huyện Xuyên Mộc", 0, 62 }, { "Huyện Long Điền", 0, 62 }, { "Huyện Đất Đỏ", 0, 62 }, { "Huyện Tân Thành", 0, 62 }, { "Huyện Côn Đảo", 0, 62 }, { "Quận 1", 0, 1 }, { "Quận 12", 0, 1 }, { "Quận Thủ Đức", 0, 1 }, { "Quận 9", 0, 1 }, { "Quận Gò Vấp", 0, 1 }, { "Quận Bình Thạnh", 0, 1 }, { "Quận Tân Bình", 0, 1 }, { "Quận Tân Phú", 0, 1 }, { "Quận Phú Nhuận", 0, 1 }, { "Quận 2", 0, 1 }, { "Quận 3", 0, 1 }, { "Quận 10", 0, 1 }, { "Quận 11", 0, 1 }, { "Quận 4", 0, 1 }, { "Quận 5", 0, 1 }, { "Quận 6", 0, 1 }, { "Quận 8", 0, 1 }, { "Quận Bình Tân", 0, 1 }, { "Quận 7", 0, 1 }, { "Huyện Củ Chi", 0, 1 }, { "Huyện Hóc Môn", 0, 1 }, { "Huyện Bình Chánh", 0, 1 }, { "Huyện Nhà Bè", 0, 1 }, { "Huyện Cần Giờ", 0, 1 }, { "Thành phố Tân An", 0, 32 }, { "Thị xã Kiến Tường", 0, 32 }, { "Huyện Tân Hưng", 0, 32 }, { "Huyện Vĩnh Hưng", 0, 32 }, { "Huyện Mộc Hóa", 0, 32 }, { "Huyện Tân Thạnh", 0, 32 }, { "Huyện Thạnh Hóa", 0, 32 }, { "Huyện Đức Huệ", 0, 32 }, { "Huyện Đức Hòa", 0, 32 }, { "Huyện Bến Lức", 0, 32 }, { "Huyện Thủ Thừa", 0, 32 }, { "Huyện Tân Trụ", 0, 32 }, { "Huyện Cần Đước", 0, 32 }, { "Huyện Cần Giuộc", 0, 32 }, { "Huyện Châu Thành", 0, 32 }, { "Thành phố Mỹ Tho", 0, 50 }, { "Thị xã Gò Công", 0, 50 }, { "Thị xã Cai Lậy", 0, 50 }, { "Huyện Tân Phước", 0, 50 }, { "Huyện Cái Bè", 0, 50 }, { "Huyện Cai Lậy", 0, 50 }, { "Huyện Châu Thành", 0, 50 }, { "Huyện Chợ Gạo", 0, 50 }, { "Huyện Gò Công Tây", 0, 50 }, { "Huyện Gò Công Đông", 0, 50 }, { "Huyện Tân Phú Đông", 0, 50 }, { "Thành phố Bến Tre", 0, 63 }, { "Huyện Châu Thành", 0, 63 }, { "Huyện Chợ Lách", 0, 63 }, { "Huyện Mỏ Cày Nam", 0, 63 }, { "Huyện Giồng Trôm", 0, 63 }, { "Huyện Bình Đại", 0, 63 }, { "Huyện Ba Tri", 0, 63 }, { "Huyện Thạnh Phú", 0, 63 }, { "Huyện Mỏ Cày Bắc", 0, 63 }, { "Thành phố Trà Vinh", 0, 51 }, { "Huyện Càng Long", 0, 51 }, { "Huyện Cầu Kè", 0, 51 }, { "Huyện Tiểu Cần", 0, 51 }, { "Huyện Châu Thành", 0, 51 }, { "Huyện Cầu Ngang", 0, 51 }, { "Huyện Trà Cú", 0, 51 }, { "Huyện Duyên Hải", 0, 51 }, { "Thị xã Duyên Hải", 0, 51 }, { "Thành phố Vĩnh Long", 0, 53 }, { "Huyện Long Hồ", 0, 53 }, { "Huyện Mang Thít", 0, 53 }, { "Huyện Vũng Liêm", 0, 53 }, { "Huyện Tam Bình", 0, 53 }, { "Thị xã Bình Minh", 0, 53 }, { "Huyện Trà Ôn", 0, 53 }, { "Huyện Bình Tân", 0, 53 }, { "Thành phố Cao Lãnh", 0, 61 }, { "Thành phố Sa Đéc", 0, 61 }, { "Thị xã Hồng Ngự", 0, 61 }, { "Huyện Tân Hồng", 0, 61 }, { "Huyện Hồng Ngự", 0, 61 }, { "Huyện Tam Nông", 0, 61 }, { "Huyện Tháp Mười", 0, 61 }, { "Huyện Cao Lãnh", 0, 61 }, { "Huyện Thanh Bình", 0, 61 }, { "Huyện Lấp Vò", 0, 61 }, { "Huyện Lai Vung", 0, 61 }, { "Huyện Châu Thành", 0, 61 }, { "Thành phố Long Xuyên", 0, 4 }, { "Thành phố Châu Đốc", 0, 4 }, { "Huyện An Phú", 0, 4 }, { "Thị xã Tân Châu", 0, 4 }, { "Huyện Phú Tân", 0, 4 }, { "Huyện Châu Phú", 0, 4 }, { "Huyện Tịnh Biên", 0, 4 }, { "Huyện Tri Tôn", 0, 4 }, { "Huyện Châu Thành", 0, 4 }, { "Huyện Chợ Mới", 0, 4 }, { "Huyện Thoại Sơn", 0, 4 }, { "Thành phố Rạch Giá", 0, 26 }, { "Thị xã Hà Tiên", 0, 26 }, { "Huyện Kiên Lương", 0, 26 }, { "Huyện Hòn Đất", 0, 26 }, { "Huyện Tân Hiệp", 0, 26 }, { "Huyện Châu Thành", 0, 26 }, { "Huyện Giồng Riềng", 0, 26 }, { "Huyện Gò Quao", 0, 26 }, { "Huyện An Biên", 0, 26 }, { "Huyện An Minh", 0, 26 }, { "Huyện Vĩnh Thuận", 0, 26 }, { "Huyện Phú Quốc", 0, 26 }, { "Huyện Kiên Hải", 0, 26 }, { "Huyện U Minh Thượng", 0, 26 }, { "Huyện Giang Thành", 0, 26 }, { "Quận Ninh Kiều", 0, 14 }, { "Quận Ô Môn", 0, 14 }, { "Quận Bình Thuỷ", 0, 14 }, { "Quận Cái Răng", 0, 14 }, { "Quận Thốt Nốt", 0, 14 }, { "Huyện Vĩnh Thạnh", 0, 14 }, { "Huyện Cờ Đỏ", 0, 14 }, { "Huyện Phong Điền", 0, 14 }, { "Huyện Thới Lai", 0, 14 }, { "Thành phố Vị Thanh", 0, 22 }, { "Thị xã Ngã Bảy", 0, 22 }, { "Huyện Châu Thành A", 0, 22 }, { "Huyện Châu Thành", 0, 22 }, { "Huyện Phụng Hiệp", 0, 22 }, { "Huyện Vị Thủy", 0, 22 }, { "Huyện Long Mỹ", 0, 22 }, { "Thị xã Long Mỹ", 0, 22 }, { "Thành phố Sóc Trăng", 0, 44 }, { "Huyện Châu Thành", 0, 44 }, { "Huyện Kế Sách", 0, 44 }, { "Huyện Mỹ Tú", 0, 44 }, { "Huyện Cù Lao Dung", 0, 44 }, { "Huyện Long Phú", 0, 44 }, { "Huyện Mỹ Xuyên", 0, 44 }, { "Thị xã Ngã Năm", 0, 44 }, { "Huyện Thạnh Trị", 0, 44 }, { "Thị xã Vĩnh Châu", 0, 44 }, { "Huyện Trần Đề", 0, 44 }, { "Thành phố Bạc Liêu", 0, 7 }, { "Huyện Hồng Dân", 0, 7 }, { "Huyện Phước Long", 0, 7 }, { "Huyện Vĩnh Lợi", 0, 7 }, { "Thị xã Giá Rai", 0, 7 }, { "Huyện Đông Hải", 0, 7 }, { "Huyện Hòa Bình", 0, 7 }, { "Thành phố Cà Mau", 0, 7 }, { "Huyện U Minh", 0, 7 }, { "Huyện Thới Bình", 0, 7 }, { "Huyện Trần Văn Thời", 0, 7 }, { "Huyện Cái Nước", 0, 7 }, { "Huyện Đầm Dơi", 0, 7 }, { "Huyện Năm Căn", 0, 7 }, { "Huyện Phú Tân", 0, 7 }, { "Huyện Ngọc Hiển", 0, 7 },
                });
            #endregion

            #region Ward
            migrationBuilder.InsertData(
                table: "Wards",
                columns: new[] { "Name", "Sort", "DistrictId" },
                values: new object[,] { { "Phường Phúc Xá", 0, 1 }, { "Phường Trúc Bạch", 0, 1 }, { "Phường Vĩnh Phúc", 0, 1 }, { "Phường Cống Vị", 0, 1 }, { "Phường Liễu Giai", 0, 1 }, { "Phường Nguyễn Trung Trực", 0, 1 }, { "Phường Quán Thánh", 0, 1 }, { "Phường Ngọc Hà", 0, 1 }, { "Phường Điện Biên", 0, 1 }, { "Phường Đội Cấn", 0, 1 }, { "Phường Ngọc Khánh", 0, 1 }, { "Phường Kim Mã", 0, 1 }, { "Phường Giảng Võ", 0, 1 }, { "Phường Thành Công", 0, 1 }, { "Phường Phúc Tân", 0, 2 }, { "Phường Đồng Xuân", 0, 2 }, { "Phường Hàng Mã", 0, 2 }, { "Phường Hàng Buồm", 0, 2 }, { "Phường Hàng Đào", 0, 2 }, { "Phường Hàng Bồ", 0, 2 }, { "Phường Cửa Đông", 0, 2 }, { "Phường Lý Thái Tổ", 0, 2 }, { "Phường Hàng Bạc", 0, 2 }, { "Phường Hàng Gai", 0, 2 }, { "Phường Chương Dương Độ", 0, 2 }, { "Phường Hàng Trống", 0, 2 }, { "Phường Cửa Nam", 0, 2 }, { "Phường Hàng Bông", 0, 2 }, { "Phường Tràng Tiền", 0, 2 }, { "Phường Trần Hưng Đạo", 0, 2 }, { "Phường Phan Chu Trinh", 0, 2 }, { "Phường Hàng Bài", 0, 2 }, { "Phường Phú Thượng", 0, 3 }, { "Phường Nhật Tân", 0, 3 }, { "Phường Tứ Liên", 0, 3 }, { "Phường Quảng An", 0, 3 }, { "Phường Xuân La", 0, 3 }, { "Phường Yên Phụ", 0, 3 }, { "Phường Bưởi", 0, 3 }, { "Phường Thụy Khuê", 0, 3 }, { "Phường Thượng Thanh", 0, 4 }, { "Phường Ngọc Thụy", 0, 4 }, { "Phường Giang Biên", 0, 4 }, { "Phường Đức Giang", 0, 4 }, { "Phường Việt Hưng", 0, 4 }, { "Phường Gia Thụy", 0, 4 }, { "Phường Ngọc Lâm", 0, 4 }, { "Phường Phúc Lợi", 0, 4 }, { "Phường Bồ Đề", 0, 4 }, { "Phường Sài Đồng", 0, 4 }, { "Phường Long Biên", 0, 4 }, { "Phường Thạch Bàn", 0, 4 }, { "Phường Phúc Đồng", 0, 4 }, { "Phường Cự Khối", 0, 4 }, { "Phường Nghĩa Đô", 0, 5 }, { "Phường Nghĩa Tân", 0, 5 }, { "Phường Mai Dịch", 0, 5 }, { "Phường Dịch Vọng", 0, 5 }, { "Phường Dịch Vọng Hậu", 0, 5 }, { "Phường Quan Hoa", 0, 5 }, { "Phường Yên Hòa", 0, 5 }, { "Phường Trung Hòa", 0, 5 }, { "Phường Cát Linh", 0, 6 }, { "Phường Văn Miếu", 0, 6 }, { "Phường Quốc Tử Giám", 0, 6 }, { "Phường Láng Thượng", 0, 6 }, { "Phường Ô Chợ Dừa", 0, 6 }, { "Phường Văn Chương", 0, 6 }, { "Phường Hàng Bột", 0, 6 }, { "Phường Láng Hạ", 0, 6 }, { "Phường Khâm Thiên", 0, 6 }, { "Phường Thổ Quan", 0, 6 }, { "Phường Nam Đồng", 0, 6 }, { "Phường Trung Phụng", 0, 6 }, { "Phường Quang Trung", 0, 6 }, { "Phường Trung Liệt", 0, 6 }, { "Phường Phương Liên", 0, 6 }, { "Phường Thịnh Quang", 0, 6 }, { "Phường Trung Tự", 0, 6 }, { "Phường Kim Liên", 0, 6 }, { "Phường Phương Mai", 0, 6 }, { "Phường Ngã Tư Sở", 0, 6 }, { "Phường Khương Thượng", 0, 6 }, { "Phường Nguyễn Du", 0, 7 }, { "Phường Bạch Đằng", 0, 7 }, { "Phường Phạm Đình Hổ", 0, 7 }, { "Phường Bùi Thị Xuân", 0, 7 }, { "Phường Ngô Thì Nhậm", 0, 7 }, { "Phường Lê Đại Hành", 0, 7 }, { "Phường Đồng Nhân", 0, 7 }, { "Phường Phố Huế", 0, 7 }, { "Phường Đống Mác", 0, 7 }, { "Phường Thanh Lương", 0, 7 }, { "Phường Thanh Nhàn", 0, 7 }, { "Phường Cầu Dền", 0, 7 }, { "Phường Bách Khoa", 0, 7 }, { "Phường Đồng Tâm", 0, 7 }, { "Phường Vĩnh Tuy", 0, 7 }, { "Phường Bạch Mai", 0, 7 }, { "Phường Quỳnh Mai", 0, 7 }, { "Phường Quỳnh Lôi", 0, 7 }, { "Phường Minh Khai", 0, 7 }, { "Phường Trương Định", 0, 7 }, { "Phường Thanh Trì", 0, 8 }, { "Phường Vĩnh Hưng", 0, 8 }, { "Phường Định Công", 0, 8 }, { "Phường Mai Động", 0, 8 }, { "Phường Tương Mai", 0, 8 }, { "Phường Đại Kim", 0, 8 }, { "Phường Tân Mai", 0, 8 }, { "Phường Hoàng Văn Thụ", 0, 8 }, { "Phường Giáp Bát", 0, 8 }, { "Phường Lĩnh Nam", 0, 8 }, { "Phường Thịnh Liệt", 0, 8 }, { "Phường Trần Phú", 0, 8 }, { "Phường Hoàng Liệt", 0, 8 }, { "Phường Yên Sở", 0, 8 }, { "Phường Nhân Chính", 0, 9 }, { "Phường Thượng Đình", 0, 9 }, { "Phường Khương Trung", 0, 9 }, { "Phường Khương Mai", 0, 9 }, { "Phường Thanh Xuân Trung", 0, 9 }, { "Phường Phương Liệt", 0, 9 }, { "Phường Hạ Đình", 0, 9 }, { "Phường Khương Đình", 0, 9 }, { "Phường Thanh Xuân Bắc", 0, 9 }, { "Phường Thanh Xuân Nam", 0, 9 }, { "Phường Kim Giang", 0, 9 }, { "Thị trấn Sóc Sơn", 0, 16 }, { "Xã Bắc Sơn", 0, 16 }, { "Xã Minh Trí", 0, 16 }, { "Xã Hồng Kỳ", 0, 16 }, { "Xã Nam Sơn", 0, 16 }, { "Xã Trung Giã", 0, 16 }, { "Xã Tân Hưng", 0, 16 }, { "Xã Minh Phú", 0, 16 }, { "Xã Phù Linh", 0, 16 }, { "Xã Bắc Phú", 0, 16 }, { "Xã Tân Minh", 0, 16 }, { "Xã Quang Tiến", 0, 16 }, { "Xã Hiền Ninh", 0, 16 }, { "Xã Tân Dân", 0, 16 }, { "Xã Tiên Dược", 0, 16 }, { "Xã Việt Long", 0, 16 }, { "Xã Xuân Giang", 0, 16 }, { "Xã Mai Đình", 0, 16 }, { "Xã Đức Hòa", 0, 16 }, { "Xã Thanh Xuân", 0, 16 }, { "Xã Đông Xuân", 0, 16 }, { "Xã Kim Lũ", 0, 16 }, { "Xã Phú Cường", 0, 16 }, { "Xã Phú Minh", 0, 16 }, { "Xã Phù Lỗ", 0, 16 }, { "Xã Xuân Thu", 0, 16 }, { "Thị trấn Đông Anh", 0, 17 }, { "Xã Xuân Nộn", 0, 17 }, { "Xã Thuỵ Lâm", 0, 17 }, { "Xã Bắc Hồng", 0, 17 }, { "Xã Nguyên Khê", 0, 17 }, { "Xã Nam Hồng", 0, 17 }, { "Xã Tiên Dương", 0, 17 }, { "Xã Vân Hà", 0, 17 }, { "Xã Uy Nỗ", 0, 17 }, { "Xã Vân Nội", 0, 17 }, { "Xã Liên Hà", 0, 17 }, { "Xã Việt Hùng", 0, 17 }, { "Xã Kim Nỗ", 0, 17 }, { "Xã Kim Chung", 0, 17 }, { "Xã Dục Tú", 0, 17 }, { "Xã Đại Mạch", 0, 17 }, { "Xã Vĩnh Ngọc", 0, 17 }, { "Xã Cổ Loa", 0, 17 }, { "Xã Hải Bối", 0, 17 }, { "Xã Xuân Canh", 0, 17 }, { "Xã Võng La", 0, 17 }, { "Xã Tầm Xá", 0, 17 }, { "Xã Mai Lâm", 0, 17 }, { "Xã Đông Hội", 0, 17 }, { "Thị trấn Yên Viên", 0, 18 }, { "Xã Yên Thường", 0, 18 }, { "Xã Yên Viên", 0, 18 }, { "Xã Ninh Hiệp", 0, 18 }, { "Xã Đình Xuyên", 0, 18 }, { "Xã Dương Hà", 0, 18 }, { "Xã Phù Đổng", 0, 18 }, { "Xã Trung Mầu", 0, 18 }, { "Xã Lệ Chi", 0, 18 }, { "Xã Cổ Bi", 0, 18 }, { "Xã Đặng Xá", 0, 18 }, { "Xã Phú Thị", 0, 18 }, { "Xã Kim Sơn", 0, 18 }, { "Thị trấn Trâu Quỳ", 0, 18 }, { "Xã Dương Quang", 0, 18 }, { "Xã Dương Xá", 0, 18 }, { "Xã Đông Dư", 0, 18 }, { "Xã Đa Tốn", 0, 18 }, { "Xã Kiêu Kỵ", 0, 18 }, { "Xã Bát Tràng", 0, 18 }, { "Xã Kim Lan", 0, 18 }, { "Xã Văn Đức", 0, 18 }, { "Phường Cầu Diễn", 0, 19 }, { "Phường Thượng Cát", 0, 21 }, { "Phường Liên Mạc", 0, 21 }, { "Phường Đông Ngạc", 0, 21 }, { "Phường Đức Thắng", 0, 21 }, { "Phường Thụy Phương", 0, 21 }, { "Phường Tây Tựu", 0, 21 }, { "Phường Xuân Đỉnh", 0, 21 }, { "Phường Xuân Tảo", 0, 21 }, { "Phường Minh Khai", 0, 21 }, { "Phường Cổ Nhuế 1", 0, 21 }, { "Phường Cổ Nhuế 2", 0, 21 }, { "Phường Phú Diễn", 0, 21 }, { "Phường Phúc Diễn", 0, 21 }, { "Phường Xuân Phương", 0, 19 }, { "Phường Phương Canh", 0, 19 }, { "Phường Mỹ Đình 1", 0, 19 }, { "Phường Mỹ Đình 2", 0, 19 }, { "Phường Tây Mỗ", 0, 19 }, { "Phường Mễ Trì", 0, 19 }, { "Phường Phú Đô", 0, 19 }, { "Phường Đại Mỗ", 0, 19 }, { "Phường Trung Văn", 0, 19 }, { "Thị trấn Văn Điển", 0, 20 }, { "Xã Tân Triều", 0, 20 }, { "Xã Thanh Liệt", 0, 20 }, { "Xã Tả Thanh Oai", 0, 20 }, { "Xã Hữu Hòa", 0, 20 }, { "Xã Tam Hiệp", 0, 20 }, { "Xã Tứ Hiệp", 0, 20 }, { "Xã Yên Mỹ", 0, 20 }, { "Xã Vĩnh Quỳnh", 0, 20 }, { "Xã Ngũ Hiệp", 0, 20 }, { "Xã Duyên Hà", 0, 20 }, { "Xã Ngọc Hồi", 0, 20 }, { "Xã Vạn Phúc", 0, 20 }, { "Xã Đại áng", 0, 20 }, { "Xã Liên Ninh", 0, 20 }, { "Xã Đông Mỹ", 0, 20 }, { "Phường Quang Trung", 0, 24 }, { "Phường Trần Phú", 0, 24 }, { "Phường Ngọc Hà", 0, 24 }, { "Phường Nguyễn Trãi", 0, 24 }, { "Phường Minh Khai", 0, 24 }, { "Xã Ngọc Đường", 0, 24 }, { "Xã Kim Thạch", 0, 30 }, { "Xã Phú Linh", 0, 30 }, { "Xã Kim Linh", 0, 30 }, { "Thị trấn Phố Bảng", 0, 26 }, { "Xã Lũng Cú", 0, 26 }, { "Xã Má Lé", 0, 26 }, { "Thị trấn Đồng Văn", 0, 26 }, { "Xã Lũng Táo", 0, 26 }, { "Xã Phố Là", 0, 26 }, { "Xã Thài Phìn Tủng", 0, 26 }, { "Xã Sủng Là", 0, 26 }, { "Xã Xà Phìn", 0, 26 }, { "Xã Tả Phìn", 0, 26 }, { "Xã Tả Lủng", 0, 26 }, { "Xã Phố Cáo", 0, 26 }, { "Xã Sính Lủng", 0, 26 }, { "Xã Sảng Tủng", 0, 26 }, { "Xã Lũng Thầu", 0, 26 }, { "Xã Hố Quáng Phìn", 0, 26 }, { "Xã Vần Chải", 0, 26 }, { "Xã Lũng Phìn", 0, 26 }, { "Xã Sủng Trái", 0, 26 }, { "Thị trấn Mèo Vạc", 0, 27 }, { "Xã Thượng Phùng", 0, 27 }, { "Xã Pải Lủng", 0, 27 }, { "Xã Xín Cái", 0, 27 }, { "Xã Pả Vi", 0, 27 }, { "Xã Giàng Chu Phìn", 0, 27 }, { "Xã Sủng Trà", 0, 27 }, { "Xã Sủng Máng", 0, 27 }, { "Xã Sơn Vĩ", 0, 27 }, { "Xã Tả Lủng", 0, 27 }, { "Xã Cán Chu Phìn", 0, 27 }, { "Xã Lũng Pù", 0, 27 }, { "Xã Lũng Chinh", 0, 27 }, { "Xã Tát Ngà", 0, 27 }, { "Xã Nậm Ban", 0, 27 }, { "Xã Khâu Vai", 0, 27 }, { "Xã Niêm Tòng", 0, 27 }, { "Xã Niêm Sơn", 0, 27 }, { "Thị trấn Yên Minh", 0, 28 }, { "Xã Thắng Mố", 0, 28 }, { "Xã Phú Lũng", 0, 28 }, { "Xã Sủng Tráng", 0, 28 }, { "Xã Bạch Đích", 0, 28 }, { "Xã Na Khê", 0, 28 }, { "Xã Sủng Thài", 0, 28 }, { "Xã Hữu Vinh", 0, 28 }, { "Xã Lao Và Chải", 0, 28 }, { "Xã Mậu Duệ", 0, 28 }, { "Xã Đông Minh", 0, 28 }, { "Xã Mậu Long", 0, 28 }, { "Xã Ngam La", 0, 28 }, { "Xã Ngọc Long", 0, 28 }, { "Xã Đường Thượng", 0, 28 }, { "Xã Lũng Hồ", 0, 28 }, { "Xã Du Tiến", 0, 28 }, { "Xã Du Già", 0, 28 }, { "Thị trấn Tam Sơn", 0, 29 }, { "Xã Bát Đại Sơn", 0, 29 }, { "Xã Nghĩa Thuận", 0, 29 }, { "Xã Cán Tỷ", 0, 29 }, { "Xã Cao Mã Pờ", 0, 29 }, { "Xã Thanh Vân", 0, 29 }, { "Xã Tùng Vài", 0, 29 }, { "Xã Đông Hà", 0, 29 }, { "Xã Quản Bạ", 0, 29 }, { "Xã Lùng Tám", 0, 29 }, { "Xã Quyết Tiến", 0, 29 }, { "Xã Tả Ván", 0, 29 }, { "Xã Thái An", 0, 29 }, { "Thị trấn Vị Xuyên", 0, 30 }, { "Thị trấn Nông Trường Việt Lâm", 0, 30 }, { "Xã Minh Tân", 0, 30 }, { "Xã Thuận Hòa", 0, 30 }, { "Xã Tùng Bá", 0, 30 }, { "Xã Thanh Thủy", 0, 30 }, { "Xã Thanh Đức", 0, 30 }, { "Xã Phong Quang", 0, 30 }, { "Xã Xín Chải", 0, 30 }, { "Xã Phương Tiến", 0, 30 }, { "Xã Lao Chải", 0, 30 }, { "Xã Phương Độ", 0, 24 }, { "Xã Phương Thiện", 0, 24 }, { "Xã Cao Bồ", 0, 30 }, { "Xã Đạo Đức", 0, 30 }, { "Xã Thượng Sơn", 0, 30 }, { "Xã Linh Hồ", 0, 30 }, { "Xã Quảng Ngần", 0, 30 }, { "Xã Việt Lâm", 0, 30 }, { "Xã Ngọc Linh", 0, 30 }, { "Xã Ngọc Minh", 0, 30 }, { "Xã Bạch Ngọc", 0, 30 }, { "Xã Trung Thành", 0, 30 }, { "Xã Minh Sơn", 0, 31 }, { "Xã Giáp Trung", 0, 31 }, { "Xã Yên Định", 0, 31 }, { "Thị trấn Yên Phú", 0, 31 }, { "Xã Minh Ngọc", 0, 31 }, { "Xã Yên Phong", 0, 31 }, { "Xã Lạc Nông", 0, 31 }, { "Xã Phú Nam", 0, 31 }, { "Xã Yên Cường", 0, 31 }, { "Xã Thượng Tân", 0, 31 }, { "Xã Đường Âm", 0, 31 }, { "Xã Đường Hồng", 0, 31 }, { "Xã Phiêng Luông", 0, 31 }, { "Thị trấn Vinh Quang", 0, 32 }, { "Xã Bản Máy", 0, 32 }, { "Xã Thàng Tín", 0, 32 }, { "Xã Thèn Chu Phìn", 0, 32 }, { "Xã Pố Lồ", 0, 32 }, { "Xã Bản Phùng", 0, 32 }, { "Xã Túng Sán", 0, 32 }, { "Xã Chiến Phố", 0, 32 }, { "Xã Đản Ván", 0, 32 }, { "Xã Tụ Nhân", 0, 32 }, { "Xã Tân Tiến", 0, 32 }, { "Xã Nàng Đôn", 0, 32 }, { "Xã Pờ Ly Ngài", 0, 32 }, { "Xã Sán Xả Hồ", 0, 32 }, { "Xã Bản Luốc", 0, 32 }, { "Xã Ngàm Đăng Vài", 0, 32 }, { "Xã Bản Nhùng", 0, 32 }, { "Xã Tả Sử Choóng", 0, 32 }, { "Xã Nậm Dịch", 0, 32 }, { "Xã Bản Péo", 0, 32 }, { "Xã Hồ Thầu", 0, 32 }, { "Xã Nam Sơn", 0, 32 }, { "Xã Nậm Tỵ", 0, 32 }, { "Xã Thông Nguyên", 0, 32 }, { "Xã Nậm Khòa", 0, 32 }, { "Thị trấn Cốc Pài", 0, 33 }, { "Xã Nàn Xỉn", 0, 33 }, { "Xã Bản Díu", 0, 33 }, { "Xã Chí Cà", 0, 33 }, { "Xã Xín Mần", 0, 33 }, { "Xã Trung Thịnh", 0, 33 }, { "Xã Thèn Phàng", 0, 33 }, { "Xã Ngán Chiên", 0, 33 }, { "Xã Pà Vầy Sủ", 0, 33 }, { "Xã Cốc Rế", 0, 33 }, { "Xã Thu Tà", 0, 33 }, { "Xã Nàn Ma", 0, 33 }, { "Xã Tả Nhìu", 0, 33 }, { "Xã Bản Ngò", 0, 33 }, { "Xã Chế Là", 0, 33 }, { "Xã Nấm Dẩn", 0, 33 }, { "Xã Quảng Nguyên", 0, 33 }, { "Xã Nà Chì", 0, 33 }, { "Xã Khuôn Lùng", 0, 33 }, { "Thị trấn Việt Quang", 0, 34 }, { "Thị trấn Vĩnh Tuy", 0, 34 }, { "Xã Tân Lập", 0, 34 }, { "Xã Tân Thành", 0, 34 }, { "Xã Đồng Tiến", 0, 34 }, { "Xã Đồng Tâm", 0, 34 }, { "Xã Tân Quang", 0, 34 }, { "Xã Thượng Bình", 0, 34 }, { "Xã Hữu Sản", 0, 34 }, { "Xã Kim Ngọc", 0, 34 }, { "Xã Việt Vinh", 0, 34 }, { "Xã Bằng Hành", 0, 34 }, { "Xã Quang Minh", 0, 34 }, { "Xã Liên Hiệp", 0, 34 }, { "Xã Vô Điếm", 0, 34 }, { "Xã Việt Hồng", 0, 34 }, { "Xã Hùng An", 0, 34 }, { "Xã Đức Xuân", 0, 34 }, { "Xã Tiên Kiều", 0, 34 }, { "Xã Vĩnh Hảo", 0, 34 }, { "Xã Vĩnh Phúc", 0, 34 }, { "Xã Đồng Yên", 0, 34 }, { "Xã Đông Thành", 0, 34 }, { "Xã Xuân Minh", 0, 35 }, { "Xã Tiên Nguyên", 0, 35 }, { "Xã Tân Nam", 0, 35 }, { "Xã Bản Rịa", 0, 35 }, { "Xã Yên Thành", 0, 35 }, { "Thị trấn Yên Bình", 0, 35 }, { "Xã Tân Trịnh", 0, 35 }, { "Xã Tân Bắc", 0, 35 }, { "Xã Bằng Lang", 0, 35 }, { "Xã Yên Hà", 0, 35 }, { "Xã Hương Sơn", 0, 35 }, { "Xã Xuân Giang", 0, 35 }, { "Xã Nà Khương", 0, 35 }, { "Xã Tiên Yên", 0, 35 }, { "Xã Vĩ Thượng", 0, 35 }, { "Phường Sông Hiến", 0, 40 }, { "Phường Sông Bằng", 0, 40 }, { "Phường Hợp Giang", 0, 40 }, { "Phường Tân Giang", 0, 40 }, { "Phường Ngọc Xuân", 0, 40 }, { "Phường Đề Thám", 0, 40 }, { "Phường Hòa Chung", 0, 40 }, { "Phường Duyệt Trung", 0, 40 }, { "Thị trấn Pác Miầu", 0, 42 }, { "Xã Đức Hạnh", 0, 42 }, { "Xã Lý Bôn", 0, 42 }, { "Xã Nam Cao", 0, 42 }, { "Xã Nam Quang", 0, 42 }, { "Xã Vĩnh Quang", 0, 42 }, { "Xã Quảng Lâm", 0, 42 }, { "Xã Thạch Lâm", 0, 42 }, { "Xã Tân Việt", 0, 42 }, { "Xã Vĩnh Phong", 0, 42 }, { "Xã Mông Ân", 0, 42 }, { "Xã Thái Học", 0, 42 }, { "Xã Thái Sơn", 0, 42 }, { "Xã Yên Thổ", 0, 42 }, { "Thị trấn Bảo Lạc", 0, 43 }, { "Xã Cốc Pàng", 0, 43 }, { "Xã Thượng Hà", 0, 43 }, { "Xã Cô Ba", 0, 43 }, { "Xã Bảo Toàn", 0, 43 }, { "Xã Khánh Xuân", 0, 43 }, { "Xã Xuân Trường", 0, 43 }, { "Xã Hồng Trị", 0, 43 }, { "Xã Kim Cúc", 0, 43 }, { "Xã Phan Thanh", 0, 43 }, { "Xã Hồng An", 0, 43 }, { "Xã Hưng Đạo", 0, 43 }, { "Xã Hưng Thịnh", 0, 43 }, { "Xã Huy Giáp", 0, 43 }, { "Xã Đình Phùng", 0, 43 }, { "Xã Sơn Lập", 0, 43 }, { "Xã Sơn Lộ", 0, 43 }, { "Thị trấn Thông Nông", 0, 44 }, { "Xã Cần Yên", 0, 44 }, { "Xã Cần Nông", 0, 44 }, { "Xã Vị Quang", 0, 44 }, { "Xã Lương Thông", 0, 44 }, { "Xã Đa Thông", 0, 44 }, { "Xã Ngọc Động", 0, 44 }, { "Xã Yên Sơn", 0, 44 }, { "Xã Lương Can", 0, 44 }, { "Xã Thanh Long", 0, 44 }, { "Xã Bình Lãng", 0, 44 }, { "Thị trấn Xuân Hòa", 0, 45 }, { "Xã Lũng Nặm", 0, 45 }, { "Xã Kéo Yên", 0, 45 }, { "Xã Trường Hà", 0, 45 }, { "Xã Vân An", 0, 45 }, { "Xã Cải Viên", 0, 45 }, { "Xã Nà Sác", 0, 45 }, { "Xã Nội Thôn", 0, 45 }, { "Xã Tổng Cọt", 0, 45 }, { "Xã Sóc Hà", 0, 45 }, { "Xã Thượng Thôn", 0, 45 }, { "Xã Vần Dính", 0, 45 }, { "Xã Hồng Sĩ", 0, 45 }, { "Xã Sĩ Hai", 0, 45 }, { "Xã Quý Quân", 0, 45 }, { "Xã Mã Ba", 0, 45 }, { "Xã Phù Ngọc", 0, 45 }, { "Xã Đào Ngạn", 0, 45 }, { "Xã Hạ Thôn", 0, 45 }, { "Thị trấn Hùng Quốc", 0, 46 }, { "Xã Cô Mười", 0, 46 }, { "Xã Tri Phương", 0, 46 }, { "Xã Quang Hán", 0, 46 }, { "Xã Quang Vinh", 0, 46 }, { "Xã Xuân Nội", 0, 46 }, { "Xã Quang Trung", 0, 46 }, { "Xã Lưu Ngọc", 0, 46 }, { "Xã Cao Chương", 0, 46 }, { "Xã Quốc Toản", 0, 46 }, { "Thị trấn Trùng Khánh", 0, 47 }, { "Xã Ngọc Khê", 0, 47 }, { "Xã Ngọc Côn", 0, 47 }, { "Xã Phong Nậm", 0, 47 }, { "Xã Ngọc Chung", 0, 47 }, { "Xã Đình Phong", 0, 47 }, { "Xã Lăng Yên", 0, 47 }, { "Xã Đàm Thuỷ", 0, 47 }, { "Xã Khâm Thành", 0, 47 }, { "Xã Chí Viễn", 0, 47 }, { "Xã Lăng Hiếu", 0, 47 }, { "Xã Phong Châu", 0, 47 }, { "Xã Đình Minh", 0, 47 }, { "Xã Cảnh Tiên", 0, 47 }, { "Xã Trung Phúc", 0, 47 }, { "Xã Cao Thăng", 0, 47 }, { "Xã Đức Hồng", 0, 47 }, { "Xã Thông Huề", 0, 47 }, { "Xã Thân Giáp", 0, 47 }, { "Xã Đoài Côn", 0, 47 }, { "Xã Minh Long", 0, 48 }, { "Xã Lý Quốc", 0, 48 }, { "Xã Thắng Lợi", 0, 48 }, { "Xã Đồng Loan", 0, 48 }, { "Xã Đức Quang", 0, 48 }, { "Xã Kim Loan", 0, 48 }, { "Xã Quang Long", 0, 48 }, { "Xã An Lạc", 0, 48 }, { "Thị trấn Thanh Nhật", 0, 48 }, { "Xã Vinh Quý", 0, 48 }, { "Xã Việt Chu", 0, 48 }, { "Xã Cô Ngân", 0, 48 }, { "Xã Thái Đức", 0, 48 }, { "Xã Thị Hoa", 0, 48 }, { "Thị trấn Quảng Uyên", 0, 49 }, { "Xã Phi Hải", 0, 49 }, { "Xã Quảng Hưng", 0, 49 }, { "Xã Bình Lăng", 0, 49 }, { "Xã Quốc Dân", 0, 49 }, { "Xã Quốc Phong", 0, 49 }, { "Xã Độc Lập", 0, 49 }, { "Xã Cai Bộ", 0, 49 }, { "Xã Đoài Khôn", 0, 49 }, { "Xã Phúc Sen", 0, 49 }, { "Xã Chí Thảo", 0, 49 }, { "Xã Tự Do", 0, 49 }, { "Xã Hồng Định", 0, 49 }, { "Xã Hồng Quang", 0, 49 }, { "Xã Ngọc Động", 0, 49 }, { "Xã Hoàng Hải", 0, 49 }, { "Xã Hạnh Phúc", 0, 49 }, { "Thị trấn Tà Lùng", 0, 50 }, { "Xã Triệu ẩu", 0, 50 }, { "Xã Hồng Đại", 0, 50 }, { "Xã Cách Linh", 0, 50 }, { "Xã Đại Sơn", 0, 50 }, { "Xã Lương Thiện", 0, 50 }, { "Xã Tiên Thành", 0, 50 }, { "Thị trấn Hòa Thuận", 0, 50 }, { "Xã Mỹ Hưng", 0, 50 }, { "Thị trấn Nước Hai", 0, 51 }, { "Xã Dân Chủ", 0, 51 }, { "Xã Nam Tuấn", 0, 51 }, { "Xã Đức Xuân", 0, 51 }, { "Xã Đại Tiến", 0, 51 }, { "Xã Đức Long", 0, 51 }, { "Xã Ngũ Lão", 0, 51 }, { "Xã Trương Lương", 0, 51 }, { "Xã Bình Long", 0, 51 }, { "Xã Nguyễn Huệ", 0, 51 }, { "Xã Công Trừng", 0, 51 }, { "Xã Hồng Việt", 0, 51 }, { "Xã Bế Triều", 0, 51 }, { "Xã Vĩnh Quang", 0, 40 }, { "Xã Hoàng Tung", 0, 51 }, { "Xã Trưng Vương", 0, 51 }, { "Xã Quang Trung", 0, 51 }, { "Xã Hưng Đạo", 0, 40 }, { "Xã Bạch Đằng", 0, 51 }, { "Xã Bình Dương", 0, 51 }, { "Xã Lê Chung", 0, 51 }, { "Xã Hà Trì", 0, 51 }, { "Xã Chu Trinh", 0, 40 }, { "Xã Hồng Nam", 0, 51 }, { "Thị trấn Nguyên Bình", 0, 52 }, { "Thị trấn Tĩnh Túc", 0, 52 }, { "Xã Yên Lạc", 0, 52 }, { "Xã Triệu Nguyên", 0, 52 }, { "Xã Ca Thành", 0, 52 }, { "Xã Thái Học", 0, 52 }, { "Xã Vũ Nông", 0, 52 }, { "Xã Minh Tâm", 0, 52 }, { "Xã Thể Dục", 0, 52 }, { "Xã Bắc Hợp", 0, 52 }, { "Xã Mai Long", 0, 52 }, { "Xã Lang Môn", 0, 52 }, { "Xã Minh Thanh", 0, 52 }, { "Xã Hoa Thám", 0, 52 }, { "Xã Phan Thanh", 0, 52 }, { "Xã Quang Thành", 0, 52 }, { "Xã Tam Kim", 0, 52 }, { "Xã Thành Công", 0, 52 }, { "Xã Thịnh Vượng", 0, 52 }, { "Xã Hưng Đạo", 0, 52 }, { "Thị trấn Đông Khê", 0, 53 }, { "Xã Canh Tân", 0, 53 }, { "Xã Kim Đồng", 0, 53 }, { "Xã Minh Khai", 0, 53 }, { "Xã Thị Ngân", 0, 53 }, { "Xã Đức Thông", 0, 53 }, { "Xã Thái Cường", 0, 53 }, { "Xã Vân Trình", 0, 53 }, { "Xã Thụy Hùng", 0, 53 }, { "Xã Quang Trọng", 0, 53 }, { "Xã Trọng Con", 0, 53 }, { "Xã Lê Lai", 0, 53 }, { "Xã Đức Long", 0, 53 }, { "Xã Danh Sỹ", 0, 53 }, { "Xã Lê Lợi", 0, 53 }, { "Xã Đức Xuân", 0, 53 }, { "Phường Nguyễn Thị Minh Khai", 0, 58 }, { "Phường Sông Cầu", 0, 58 }, { "Phường Đức Xuân", 0, 58 }, { "Phường Phùng Chí Kiên", 0, 58 }, { "Phường Huyền Tụng", 0, 58 }, { "Xã Dương Quang", 0, 58 }, { "Xã Nông Thượng", 0, 58 }, { "Phường Xuất Hóa", 0, 58 }, { "Xã Bằng Thành", 0, 60 }, { "Xã Nhạn Môn", 0, 60 }, { "Xã Bộc Bố", 0, 60 }, { "Xã Công Bằng", 0, 60 }, { "Xã Giáo Hiệu", 0, 60 }, { "Xã Xuân La", 0, 60 }, { "Xã An Thắng", 0, 60 }, { "Xã Cổ Linh", 0, 60 }, { "Xã Nghiên Loan", 0, 60 }, { "Xã Cao Tân", 0, 60 }, { "Thị trấn Chợ Rã", 0, 61 }, { "Xã Bành Trạch", 0, 61 }, { "Xã Phúc Lộc", 0, 61 }, { "Xã Hà Hiệu", 0, 61 }, { "Xã Cao Thượng", 0, 61 }, { "Xã Cao Trĩ", 0, 61 }, { "Xã Khang Ninh", 0, 61 }, { "Xã Nam Mẫu", 0, 61 }, { "Xã Thượng Giáo", 0, 61 }, { "Xã Địa Linh", 0, 61 }, { "Xã Yến Dương", 0, 61 }, { "Xã Chu Hương", 0, 61 }, { "Xã Quảng Khê", 0, 61 }, { "Xã Mỹ Phương", 0, 61 }, { "Xã Hoàng Trĩ", 0, 61 }, { "Xã Đồng Phúc", 0, 61 }, { "Thị trấn Nà Phặc", 0, 62 }, { "Xã Thượng Ân", 0, 62 }, { "Xã Bằng Vân", 0, 62 }, { "Xã Cốc Đán", 0, 62 }, { "Xã Trung Hòa", 0, 62 }, { "Xã Đức Vân", 0, 62 }, { "Xã Vân Tùng", 0, 62 }, { "Xã Thượng Quan", 0, 62 }, { "Xã Lãng Ngâm", 0, 62 }, { "Xã Thuần Mang", 0, 62 }, { "Xã Hương Nê", 0, 62 }, { "Thị trấn Phủ Thông", 0, 63 }, { "Xã Phương Linh", 0, 63 }, { "Xã Vi Hương", 0, 63 }, { "Xã Sỹ Bình", 0, 63 }, { "Xã Vũ Muộn", 0, 63 }, { "Xã Đôn Phong", 0, 63 }, { "Xã Tú Trĩ", 0, 63 }, { "Xã Lục Bình", 0, 63 }, { "Xã Tân Tiến", 0, 63 }, { "Xã Quân Bình", 0, 63 }, { "Xã Nguyên Phúc", 0, 63 }, { "Xã Cao Sơn", 0, 63 }, { "Xã Hà Vị", 0, 63 }, { "Xã Cẩm Giàng", 0, 63 }, { "Xã Mỹ Thanh", 0, 63 }, { "Xã Dương Phong", 0, 63 }, { "Xã Quang Thuận", 0, 63 }, { "Thị trấn Bằng Lũng", 0, 64 }, { "Xã Xuân Lạc", 0, 64 }, { "Xã Nam Cường", 0, 64 }, { "Xã Đồng Lạc", 0, 64 }, { "Xã Tân Lập", 0, 64 }, { "Xã Bản Thi", 0, 64 }, { "Xã Quảng Bạch", 0, 64 }, { "Xã Bằng Phúc", 0, 64 }, { "Xã Yên Thịnh", 0, 64 }, { "Xã Yên Thượng", 0, 64 }, { "Xã Phương Viên", 0, 64 }, { "Xã Ngọc Phái", 0, 64 }, { "Xã Rã Bản", 0, 64 }, { "Xã Đông Viên", 0, 64 }, { "Xã Lương Bằng", 0, 64 }, { "Xã Bằng Lãng", 0, 64 }, { "Xã Đại Sảo", 0, 64 }, { "Xã Nghĩa Tá", 0, 64 }, { "Xã Phong Huân", 0, 64 }, { "Xã Yên Mỹ", 0, 64 }, { "Xã Bình Trung", 0, 64 }, { "Xã Yên Nhuận", 0, 64 }, { "Thị trấn Chợ Mới", 0, 65 }, { "Xã Tân Sơn", 0, 65 }, { "Xã Thanh Vận", 0, 65 }, { "Xã Mai Lạp", 0, 65 }, { "Xã Hòa Mục", 0, 65 }, { "Xã Thanh Mai", 0, 65 }, { "Xã Cao Kỳ", 0, 65 }, { "Xã Nông Hạ", 0, 65 }, { "Xã Yên Cư", 0, 65 }, { "Xã Nông Thịnh", 0, 65 }, { "Xã Yên Hân", 0, 65 }, { "Xã Thanh Bình", 0, 65 }, { "Xã Như Cố", 0, 65 }, { "Xã Bình Văn", 0, 65 }, { "Xã Yên Đĩnh", 0, 65 }, { "Xã Quảng Chu", 0, 65 }, { "Thị trấn Yến Lạc", 0, 66 }, { "Xã Vũ Loan", 0, 66 }, { "Xã Lạng San", 0, 66 }, { "Xã Lương Thượng", 0, 66 }, { "Xã Kim Hỷ", 0, 66 }, { "Xã Văn Học", 0, 66 }, { "Xã Cường Lợi", 0, 66 }, { "Xã Lương Hạ", 0, 66 }, { "Xã Kim Lư", 0, 66 }, { "Xã Lương Thành", 0, 66 }, { "Xã Ân Tình", 0, 66 }, { "Xã Lam Sơn", 0, 66 }, { "Xã Văn Minh", 0, 66 }, { "Xã Côn Minh", 0, 66 }, { "Xã Cư Lễ", 0, 66 }, { "Xã Hữu Thác", 0, 66 }, { "Xã Hảo Nghĩa", 0, 66 }, { "Xã Quang Phong", 0, 66 }, { "Xã Dương Sơn", 0, 66 }, { "Xã Xuân Dương", 0, 66 }, { "Xã Đổng Xá", 0, 66 }, { "Xã Liêm Thuỷ", 0, 66 }, { "Phường Phan Thiết", 0, 70 }, { "Phường Minh Xuân", 0, 70 }, { "Phường Tân Quang", 0, 70 }, { "Xã Tràng Đà", 0, 70 }, { "Phường Nông Tiến", 0, 70 }, { "Phường Ỷ La", 0, 70 }, { "Phường Tân Hà", 0, 70 }, { "Phường Hưng Thành", 0, 70 }, { "Thị trấn Na Hang", 0, 72 }, { "Xã Sinh Long", 0, 72 }, { "Xã Thượng Giáp", 0, 72 }, { "Xã Phúc Yên", 0, 71 }, { "Xã Thượng Nông", 0, 72 }, { "Xã Xuân Lập", 0, 71 }, { "Xã Côn Lôn", 0, 72 }, { "Xã Yên Hoa", 0, 72 }, { "Xã Khuôn Hà", 0, 71 }, { "Xã Hồng Thái", 0, 72 }, { "Xã Đà Vị", 0, 72 }, { "Xã Khau Tinh", 0, 72 }, { "Xã Lăng Can", 0, 71 }, { "Xã Thượng Lâm", 0, 71 }, { "Xã Sơn Phú", 0, 72 }, { "Xã Năng Khả", 0, 72 }, { "Xã Thanh Tương", 0, 72 }, { "Thị trấn Vĩnh Lộc", 0, 73 }, { "Xã Bình An", 0, 71 }, { "Xã Hồng Quang", 0, 71 }, { "Xã Thổ Bình", 0, 71 }, { "Xã Phúc Sơn", 0, 73 }, { "Xã Minh Quang", 0, 73 }, { "Xã Trung Hà", 0, 73 }, { "Xã Tân Mỹ", 0, 73 }, { "Xã Hà Lang", 0, 73 }, { "Xã Hùng Mỹ", 0, 73 }, { "Xã Yên Lập", 0, 73 }, { "Xã Tân An", 0, 73 }, { "Xã Bình Phú", 0, 73 }, { "Xã Xuân Quang", 0, 73 }, { "Xã Ngọc Hội", 0, 73 }, { "Xã Phú Bình", 0, 73 }, { "Xã Hòa Phú", 0, 73 }, { "Xã Phúc Thịnh", 0, 73 }, { "Xã Kiên Đài", 0, 73 }, { "Xã Tân Thịnh", 0, 73 }, { "Xã Trung Hòa", 0, 73 }, { "Xã Kim Bình", 0, 73 }, { "Xã Hòa An", 0, 73 }, { "Xã Vinh Quang", 0, 73 }, { "Xã Tri Phú", 0, 73 }, { "Xã Nhân Lý", 0, 73 }, { "Xã Yên Nguyên", 0, 73 }, { "Xã Linh Phú", 0, 73 }, { "Xã Bình Nhân", 0, 73 }, { "Thị trấn Tân Yên", 0, 74 }, { "Xã Yên Thuận", 0, 74 }, { "Xã Bạch Xa", 0, 74 }, { "Xã Minh Khương", 0, 74 }, { "Xã Yên Lâm", 0, 74 }, { "Xã Minh Dân", 0, 74 }, { "Xã Phù Lưu", 0, 74 }, { "Xã Minh Hương", 0, 74 }, { "Xã Yên Phú", 0, 74 }, { "Xã Tân Thành", 0, 74 }, { "Xã Bình Xa", 0, 74 }, { "Xã Thái Sơn", 0, 74 }, { "Xã Nhân Mục", 0, 74 }, { "Xã Thành Long", 0, 74 }, { "Xã Bằng Cốc", 0, 74 }, { "Xã Thái Hòa", 0, 74 }, { "Xã Đức Ninh", 0, 74 }, { "Xã Hùng Đức", 0, 74 }, { "Thị trấn Tân Bình", 0, 75 }, { "Xã Quí Quân", 0, 75 }, { "Xã Lực Hành", 0, 75 }, { "Xã Kiến Thiết", 0, 75 }, { "Xã Trung Minh", 0, 75 }, { "Xã Chiêu Yên", 0, 75 }, { "Xã Trung Trực", 0, 75 }, { "Xã Xuân Vân", 0, 75 }, { "Xã Phúc Ninh", 0, 75 }, { "Xã Hùng Lợi", 0, 75 }, { "Xã Trung Sơn", 0, 75 }, { "Xã Tân Tiến", 0, 75 }, { "Xã Tứ Quận", 0, 75 }, { "Xã Đạo Viện", 0, 75 }, { "Xã Tân Long", 0, 75 }, { "Xã Thắng Quân", 0, 75 }, { "Xã Kim Quan", 0, 75 }, { "Xã Lang Quán", 0, 75 }, { "Xã Phú Thịnh", 0, 75 }, { "Xã Công Đa", 0, 75 }, { "Xã Trung Môn", 0, 75 }, { "Xã Chân Sơn", 0, 75 }, { "Xã Thái Bình", 0, 75 }, { "Xã Kim Phú", 0, 75 }, { "Xã Tiến Bộ", 0, 75 }, { "Xã An Khang", 0, 70 }, { "Xã Mỹ Bằng", 0, 75 }, { "Xã Phú Lâm", 0, 75 }, { "Xã An Tường", 0, 70 }, { "Xã Lưỡng Vượng", 0, 70 }, { "Xã Hoàng Khai", 0, 75 }, { "Xã Thái Long", 0, 70 }, { "Xã Đội Cấn", 0, 70 }, { "Xã Nhữ Hán", 0, 75 }, { "Xã Nhữ Khê", 0, 75 }, { "Xã Đội Bình", 0, 75 }, { "Thị trấn Sơn Dương", 0, 76 }, { "Xã Trung Yên", 0, 76 }, { "Xã Minh Thanh", 0, 76 }, { "Xã Tân Trào", 0, 76 }, { "Xã Vĩnh Lợi", 0, 76 }, { "Xã Thượng Ấm", 0, 76 }, { "Xã Bình Yên", 0, 76 }, { "Xã Lương Thiện", 0, 76 }, { "Xã Tú Thịnh", 0, 76 }, { "Xã Cấp Tiến", 0, 76 }, { "Xã Hợp Thành", 0, 76 }, { "Xã Phúc Ứng", 0, 76 }, { "Xã Đông Thọ", 0, 76 }, { "Xã Kháng Nhật", 0, 76 }, { "Xã Hợp Hòa", 0, 76 }, { "Xã Thanh Phát", 0, 76 }, { "Xã Quyết Thắng", 0, 76 }, { "Xã Đồng Quý", 0, 76 }, { "Xã Tuân Lộ", 0, 76 }, { "Xã Vân Sơn", 0, 76 }, { "Xã Văn Phú", 0, 76 }, { "Xã Chi Thiết", 0, 76 }, { "Xã Đông Lợi", 0, 76 }, { "Xã Thiện Kế", 0, 76 }, { "Xã Hồng Lạc", 0, 76 }, { "Xã Phú Lương", 0, 76 }, { "Xã Ninh Lai", 0, 76 }, { "Xã Đại Phú", 0, 76 }, { "Xã Sơn Nam", 0, 76 }, { "Xã Hào Phú", 0, 76 }, { "Xã Tam Đa", 0, 76 }, { "Xã Sầm Dương", 0, 76 }, { "Xã Lâm Xuyên", 0, 76 }, { "Phường Duyên Hải", 0, 80 }, { "Phường Lào Cai", 0, 80 }, { "Phường Phố Mới", 0, 80 }, { "Phường Cốc Lếu", 0, 80 }, { "Phường Kim Tân", 0, 80 }, { "Phường Bắc Lệnh", 0, 80 }, { "Phường Pom Hán", 0, 80 }, { "Phường Xuân Tăng", 0, 80 }, { "Phường Bình Minh", 0, 80 }, { "Phường Thống Nhất", 0, 80 }, { "Xã Đồng Tuyển", 0, 80 }, { "Xã Vạn Hòa", 0, 80 }, { "Phường Bắc Cường", 0, 80 }, { "Phường Nam Cường", 0, 80 }, { "Xã Cam Đường", 0, 80 }, { "Xã Tả Phời", 0, 80 }, { "Xã Hợp Thành", 0, 80 }, { "Thị trấn Bát Xát", 0, 82 }, { "Xã A Mú Sung", 0, 82 }, { "Xã Nậm Chạc", 0, 82 }, { "Xã A Lù", 0, 82 }, { "Xã Trịnh Tường", 0, 82 }, { "Xã Ngải Thầu", 0, 82 }, { "Xã Y Tý", 0, 82 }, { "Xã Cốc Mỳ", 0, 82 }, { "Xã Dền Sáng", 0, 82 }, { "Xã Bản Vược", 0, 82 }, { "Xã Sàng Ma Sáo", 0, 82 }, { "Xã Bản Qua", 0, 82 }, { "Xã Mường Vi", 0, 82 }, { "Xã Dền Thàng", 0, 82 }, { "Xã Bản Xèo", 0, 82 }, { "Xã Mường Hum", 0, 82 }, { "Xã Trung Lèng Hồ", 0, 82 }, { "Xã Quang Kim", 0, 82 }, { "Xã Pa Cheo", 0, 82 }, { "Xã Nậm Pung", 0, 82 }, { "Xã Phìn Ngan", 0, 82 }, { "Xã Cốc San", 0, 82 }, { "Xã Tòng Sành", 0, 82 }, { "Xã Pha Long", 0, 83 }, { "Xã Tả Ngải Chồ", 0, 83 }, { "Xã Tung Chung Phố", 0, 83 }, { "Thị trấn Mường Khương", 0, 83 }, { "Xã Dìn Chin", 0, 83 }, { "Xã Tả Gia Khâu", 0, 83 }, { "Xã Nậm Chảy", 0, 83 }, { "Xã Nấm Lư", 0, 83 }, { "Xã Lùng Khấu Nhin", 0, 83 }, { "Xã Thanh Bình", 0, 83 }, { "Xã Cao Sơn", 0, 83 }, { "Xã Lùng Vai", 0, 83 }, { "Xã Bản Lầu", 0, 83 }, { "Xã La Pan Tẩn", 0, 83 }, { "Xã Tả Thàng", 0, 83 }, { "Xã Bản Sen", 0, 83 }, { "Xã Nàn Sán", 0, 84 }, { "Xã Thào Chư Phìn", 0, 84 }, { "Xã Bản Mế", 0, 84 }, { "Xã Si Ma Cai", 0, 84 }, { "Xã Sán Chải", 0, 84 }, { "Xã Mản Thẩn", 0, 84 }, { "Xã Lùng Sui", 0, 84 }, { "Xã Cán Cấu", 0, 84 }, { "Xã Sín Chéng", 0, 84 }, { "Xã Cán Hồ", 0, 84 }, { "Xã Quan Thần Sán", 0, 84 }, { "Xã Lử Thẩn", 0, 84 }, { "Xã Nàn Xín", 0, 84 }, { "Thị trấn Bắc Hà", 0, 85 }, { "Xã Lùng Cải", 0, 85 }, { "Xã Bản Già", 0, 85 }, { "Xã Lùng Phình", 0, 85 }, { "Xã Tả Van Chư", 0, 85 }, { "Xã Tả Củ Tỷ", 0, 85 }, { "Xã Thải Giàng Phố", 0, 85 }, { "Xã Lầu Thí Ngài", 0, 85 }, { "Xã Hoàng Thu Phố", 0, 85 }, { "Xã Bản Phố", 0, 85 }, { "Xã Bản Liền", 0, 85 }, { "Xã Tà Chải", 0, 85 }, { "Xã Na Hối", 0, 85 }, { "Xã Cốc Ly", 0, 85 }, { "Xã Nậm Mòn", 0, 85 }, { "Xã Nậm Đét", 0, 85 }, { "Xã Nậm Khánh", 0, 85 }, { "Xã Bảo Nhai", 0, 85 }, { "Xã Nậm Lúc", 0, 85 }, { "Xã Cốc Lầu", 0, 85 }, { "Xã Bản Cái", 0, 85 }, { "Thị trấn N.T Phong Hải", 0, 86 }, { "Thị trấn Phố Lu", 0, 86 }, { "Thị trấn Tằng Loỏng", 0, 86 }, { "Xã Bản Phiệt", 0, 86 }, { "Xã Bản Cầm", 0, 86 }, { "Xã Thái Niên", 0, 86 }, { "Xã Phong Niên", 0, 86 }, { "Xã Gia Phú", 0, 86 }, { "Xã Xuân Quang", 0, 86 }, { "Xã Sơn Hải", 0, 86 }, { "Xã Xuân Giao", 0, 86 }, { "Xã Trì Quang", 0, 86 }, { "Xã Sơn Hà", 0, 86 }, { "Xã Phố Lu", 0, 86 },
                });
            #endregion

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
                values: new object[,] { { "Bình thường", "Hàng đã ở cửa hàng lâu năm và ổn định!" }, { "Mới", "Hàng mới nhập!" }, { "Bán chạy", "Hàng đang bán chạy!" }, { "Giảm giá", "Hàng đang giảm giá!" }, { "Seccond Hand", "Hàng đã qua sử dụng!" }, { "Phiên bản đặc biệt", "Phiên bản đặc biệt!" }, { "Phiên bản giới hạn", "Phiên bản giới hạn!" },
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
