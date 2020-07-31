using ECommerce.Model.EFModel.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Model.EFModel
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
               DbContextOptions options,
               IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public virtual DbSet<Address> Address { get; set; }
        /// <summary>
        /// Các loại niềng
        /// </summary>
        public virtual DbSet<Band> Bands { get; set; }
        /// <summary>
        /// Thương hiệu sản phẩm
        /// </summary>
        public virtual DbSet<BrandProduct> BrandProducts { get; set; }
        public virtual DbSet<City> Citys { get; set; }
        /// <summary>
        /// Màu mặt đồng hồ
        /// </summary>
        public virtual DbSet<ColorClockFace> ColorClockFaces { get; set; }
        /// <summary>
        /// Quận
        /// </summary>
        public virtual DbSet<District> Districts { get; set; }
        /// <summary>
        /// Các chức năng
        /// </summary>
        public virtual DbSet<Function> Functions { get; set; }
        /// <summary>
        /// Ảnh
        /// </summary>
        public virtual DbSet<Images> Images { get; set; }
        //public virtual DbSet<Log> Logs { get; set; }
        /// <summary>
        /// Loại máy
        /// </summary>
        public virtual DbSet<Machine> Machines { get; set; }
        /// <summary>
        /// Sản xuất từ đâu
        /// </summary>
        public virtual DbSet<MadeIn> MadeIns { get; set; }
        /// <summary>
        /// Đơn hàng
        /// </summary>
        public virtual DbSet<Order> Orders { get; set; }
        /// <summary>
        /// Chi tiết đơn hàng
        /// </summary>
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        /// <summary>
        /// Trạng thái đơn hàng
        /// </summary>
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        /// <summary>
        /// Sản phẩm
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }
        /// <summary>
        /// Trạng thái sản phẩm
        /// </summary>
        public virtual DbSet<ProductStatus> ProductStatus { get; set; }
        /// <summary>
        /// Trạng thái sản phẩm
        /// </summary>
        public virtual DbSet<Product_Function> Product_Functions { get; set; }

        //public virtual DbSet<Chatelaine> Chatelaines { get; set; }
        //public virtual DbSet<Customer> Customers { get; set; }
        //public virtual DbSet<Hem> Hems { get; set; }
        //public virtual DbSet<HuntingCase> HuntingCases { get; set; }
        //public virtual DbSet<Origin> Origins { get; set; }
        /// <summary>
        /// Dây đeo
        /// </summary>
        public virtual DbSet<Strap> Straps { get; set; }
        /// <summary>
        /// Phong cách
        /// </summary>
        public virtual DbSet<Style> Styles { get; set; }
        /// <summary>
        /// Phường , xã
        /// </summary>
        public virtual DbSet<Ward> Wards { get; set; }
        /// <summary>
        /// Chống nước
        /// </summary>
        public virtual DbSet<Waterproof> Waterproofs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Cấu hình Các bảng
            modelBuilder.Entity<Band>()
            .HasIndex(u => u.Name)
            .IsUnique();
            modelBuilder.Entity<City>()
            .HasIndex(u => u.Name)
            .IsUnique();
            //modelBuilder.Entity<District>()
            //.HasIndex(u => u.Name)
            //.IsUnique();
            //modelBuilder.Entity<Ward>()
            //.HasIndex(u => u.Name)
            //.IsUnique();
            modelBuilder.Entity<Function>()
            .HasIndex(u => u.Name)
            .IsUnique();
            modelBuilder.Entity<Images>()
            .HasIndex(u => u.Name)
            .IsUnique();
            modelBuilder.Entity<Product>()
            .HasIndex(u => u.Name)
            .IsUnique();
            modelBuilder.Entity<ProductStatus>()
            .HasIndex(u => u.Name)
            .IsUnique();
            modelBuilder.Entity<BrandProduct>()
            .HasIndex(u => u.Name)
            .IsUnique();
            modelBuilder.Entity<Machine>()
            .HasIndex(u => u.Name)
            .IsUnique();
            modelBuilder.Entity<Band>()
            .HasIndex(u => u.Name)
            .IsUnique();
            modelBuilder.Entity<Strap>()
            .HasIndex(u => u.Name)
            .IsUnique();
            modelBuilder.Entity<ColorClockFace>()
            .HasIndex(u => u.Name)
            .IsUnique();
            modelBuilder.Entity<MadeIn>()
            .HasIndex(u => u.Name)
            .IsUnique();
            modelBuilder.Entity<Style>()
            .HasIndex(u => u.Name)
            .IsUnique();
            modelBuilder.Entity<Waterproof>()
            .HasIndex(u => u.Name)
            .IsUnique();

            modelBuilder.Entity<Address>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<Address>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Band>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<Band>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<BrandProduct>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<BrandProduct>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<City>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<City>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<ColorClockFace>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<ColorClockFace>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<District>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<District>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Function>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<Function>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Images>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<Images>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Machine>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<Machine>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<MadeIn>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<MadeIn>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Order>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<Order>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<OrderItem>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<OrderItem>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<OrderStatus>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<OrderStatus>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Product>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<Product>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Strap>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<Strap>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Style>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<Style>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Ward>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<Ward>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Waterproof>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<Waterproof>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<ProductStatus>().Property(s => s.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<ProductStatus>().Property(s => s.CreateDate).HasDefaultValueSql("GETDATE()");

            #endregion


            #region Kết bảng

            #region Product
            modelBuilder.Entity<Product>()
           .HasOne<BrandProduct>(s => s.BrandProduct) // Có 1
           .WithMany(brand => brand.Products) // Brand có nhiều roduct
           .HasForeignKey(s => s.BrandProductId); // Brand có nhiều dựa trên BrandProductId 

            modelBuilder.Entity<Product>()
            .HasOne<Machine>(s => s.Machine)
            .WithMany(mac => mac.Products)
            .HasForeignKey(s => s.MachineId);

            modelBuilder.Entity<Product>()
              .HasOne<Band>(s => s.Band)
              .WithMany(mac => mac.Products)
              .HasForeignKey(s => s.BandId);

            modelBuilder.Entity<Product>()
              .HasOne<Strap>(s => s.Strap)
              .WithMany(mac => mac.Products)
              .HasForeignKey(s => s.Id);

            modelBuilder.Entity<Product>()
              .HasOne<ColorClockFace>(s => s.ColorClockFace)
              .WithMany(mac => mac.Products)
              .HasForeignKey(s => s.Id);

            modelBuilder.Entity<Product>()
              .HasOne<MadeIn>(s => s.MadeIn)
              .WithMany(mac => mac.Products)
              .HasForeignKey(s => s.Id);

            modelBuilder.Entity<Product>()
              .HasOne<Style>(s => s.Style)
              .WithMany(mac => mac.Products)
              .HasForeignKey(s => s.StyleId);

            modelBuilder.Entity<Product>()
              .HasOne<Waterproof>(s => s.Waterproof)
              .WithMany(mac => mac.Products)
              .HasForeignKey(s => s.Id);

            modelBuilder.Entity<Product_Function>().HasKey(sc => new { sc.ProductId, sc.FunctionId });

            modelBuilder.Entity<Product_Function>()
                .HasOne<Product>(sc => sc.Product)
                .WithMany(s => s.Product_Function)
                .HasForeignKey(sc => sc.ProductId);
            modelBuilder.Entity<Product_Function>()
                .HasOne<Function>(sc => sc.Function)
                .WithMany(s => s.Product_Function)
                .HasForeignKey(sc => sc.FunctionId);
            #endregion

            #region Address
            modelBuilder.Entity<Address>()
            .HasOne<Ward>(s => s.Ward) // Có 1
            .WithMany(brand => brand.Address) // Address có nhiều Ward
            .HasForeignKey(s => s.WardId); // Address có 1 Ward dựa trên WardId 
            modelBuilder.Entity<Address>()
            .HasOne<District>(s => s.District) // Có 1
            .WithMany(brand => brand.Address) // Address có nhiều Ward
            .HasForeignKey(s => s.DistrictId); // Address có 1 District dựa trên DistrictId 
            modelBuilder.Entity<Address>()
            .HasOne<City>(s => s.City) // Có 1
            .WithMany(brand => brand.Address) // Address có nhiều Ward
            .HasForeignKey(s => s.CityId); // Ward có nhiều dựa trên WardId 



            modelBuilder.Entity<Ward>()
            .HasOne<District>(s => s.District) // Ward Có 1 District
            .WithMany(brand => brand.Wards) // District có nhiều Ward
            .HasForeignKey(s => s.DistrictId); // Ward có 1 District dựa trên DistrictId 

            modelBuilder.Entity<District>()
            .HasOne<City>(s => s.City) // Ward Có 1 District
            .WithMany(brand => brand.Districts) // District có nhiều Ward
            .HasForeignKey(s => s.CityId); // Ward có 1 District dựa trên DistrictId 

            modelBuilder.Entity<ApplicationUser>()
            .HasOne<Address>(s => s.Address) // ApplicationUser Có 1 Address
            .WithMany(brand => brand.Users) // 1 Address có nhiều ApplicationUser
            .HasForeignKey(s => s.AddressId); // ApplicationUser có 1 Address dựa trên AddressId 
            #endregion


            #region Order
            modelBuilder.Entity<OrderItem>().HasKey(sc => new { sc.ProductId, sc.OrderId });

            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>(sc => sc.Order)
                .WithMany(s => s.OrderItems)
                .HasForeignKey(sc => sc.OrderId);
            modelBuilder.Entity<OrderItem>()
                .HasOne<Product>(sc => sc.Product)
                .WithMany(s => s.OrderItems)
                .HasForeignKey(sc => sc.ProductId);
            #endregion

            #region ProductStatus Product
            modelBuilder.Entity<Product_ProductStatus>().HasKey(sc => new { sc.ProductId, sc.ProductStatusId });

            modelBuilder.Entity<Product_ProductStatus>()
                .HasOne<Product>(sc => sc.Product)
                .WithMany(s => s.Product_ProductStatus)
                .HasForeignKey(sc => sc.ProductId);
            modelBuilder.Entity<Product_ProductStatus>()
                .HasOne<ProductStatus>(sc => sc.ProductStatus)
                .WithMany(s => s.Product_ProductStatus)
                .HasForeignKey(sc => sc.ProductStatusId);
            #endregion

            #endregion


            #region Seed Data

            //#region City
            //modelBuilder.Entity<City>().HasData(new City { Name = "Hồ Chí Minh", Sort = 1 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Hà Nội", Sort = 2 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Khác", Sort = 64 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "An Giang", Sort = 3 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Bắc Giang", Sort = 5 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Bắc Kạn", Sort = 6 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Bạc Liêu", Sort = 7 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Bắc Ninh", Sort = 8 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Bình Dương", Sort = 10 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Bình Phước", Sort = 11 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Bình Thuận", Sort = 12 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Bình Định", Sort = 13 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Cà Mau", Sort = 14 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Cần Thơ", Sort = 15 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Cao Bằng", Sort = 16 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Gia Lai", Sort = 17 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Hà Giang", Sort = 18 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Hà Nam", Sort = 19 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Hà Tĩnh", Sort = 20 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Hải Dương", Sort = 21 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Hải Phòng", Sort = 22 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Hậu Giang", Sort = 23 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Hoà Bình", Sort = 24 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Hưng Yên", Sort = 25 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Khánh Hòa", Sort = 26 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Kiên Giang", Sort = 27 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Kon Tum", Sort = 28 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Lai Châu", Sort = 29 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Lâm Đồng", Sort = 30 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Lạng Sơn", Sort = 31 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Lào Cai", Sort = 32 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Long An", Sort = 33 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Nam Định", Sort = 34 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Nghệ An", Sort = 35 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Ninh Bình", Sort = 36 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Ninh Thuận", Sort = 37 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Phú Thọ", Sort = 38 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Phú Yên", Sort = 39 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Quảng Bình", Sort = 40 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Quảng Nam", Sort = 41 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Quảng Ngãi", Sort = 42 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Quảng Ninh", Sort = 43 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Quảng Trị", Sort = 44 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Sóc Trăng", Sort = 45 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Sơn La", Sort = 46 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Tây Ninh", Sort = 47 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Thái Bình", Sort = 48 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Thái Nguyên", Sort = 49 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Thanh Hóa", Sort = 50 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Tiền Giang", Sort = 52 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Trà Vinh", Sort = 53 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Tuyên Quang", Sort = 54 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Vĩnh Long", Sort = 55 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Vĩnh Phúc", Sort = 56 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Yên Bái", Sort = 57 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Đà Nẵng", Sort = 58 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Đắk Lắk", Sort = 59 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Đắk Nông", Sort = 60 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Điện Biên", Sort = 61 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Đồng Nai", Sort = 62 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Đồng Tháp", Sort = 63 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Bà Rịa-Vũng Tàu", Sort = 9 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Bến Tre", Sort = 4 });
            //modelBuilder.Entity<City>().HasData(new City { Name = "Thừa Thiên Huế", Sort = 51 });
            //#endregion

            //#region District
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Ba Đình", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Hoàn Kiếm", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Tây Hồ", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Long Biên", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Cầu Giấy", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Đống Đa", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Hai Bà Trưng", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Hoàng Mai", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Thanh Xuân", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Sóc Sơn", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đông Anh", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Gia Lâm", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Nam Từ Liêm", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thanh Trì", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Bắc Từ Liêm", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Hà Giang", Sort = 0, CityId = 17 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đồng Văn", Sort = 0, CityId = 17 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mèo Vạc", Sort = 0, CityId = 17 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Yên Minh", Sort = 0, CityId = 17 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quản Bạ", Sort = 0, CityId = 17 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vị Xuyên", Sort = 0, CityId = 17 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bắc Mê", Sort = 0, CityId = 17 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hoàng Su Phì", Sort = 0, CityId = 17 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Xín Mần", Sort = 0, CityId = 17 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bắc Quang", Sort = 0, CityId = 17 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quang Bình", Sort = 0, CityId = 17 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Cao Bằng", Sort = 0, CityId = 15 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bảo Lâm", Sort = 0, CityId = 15 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bảo Lạc", Sort = 0, CityId = 15 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thông Nông", Sort = 0, CityId = 15 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hà Quảng", Sort = 0, CityId = 15 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Trà Lĩnh", Sort = 0, CityId = 15 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Trùng Khánh", Sort = 0, CityId = 15 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hạ Lang", Sort = 0, CityId = 15 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quảng Uyên", Sort = 0, CityId = 15 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phục Hòa", Sort = 0, CityId = 15 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hòa An", Sort = 0, CityId = 15 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nguyên Bình", Sort = 0, CityId = 15 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thạch An", Sort = 0, CityId = 15 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành Phố Bắc Kạn", Sort = 0, CityId = 6 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Pác Nặm", Sort = 0, CityId = 6 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ba Bể", Sort = 0, CityId = 6 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ngân Sơn", Sort = 0, CityId = 6 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bạch Thông", Sort = 0, CityId = 6 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Chợ Đồn", Sort = 0, CityId = 6 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Chợ Mới", Sort = 0, CityId = 6 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Na Rì", Sort = 0, CityId = 6 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Tuyên Quang", Sort = 0, CityId = 52 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lâm Bình", Sort = 0, CityId = 52 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Na Hang", Sort = 0, CityId = 52 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Chiêm Hóa", Sort = 0, CityId = 52 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hàm Yên", Sort = 0, CityId = 52 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Yên Sơn", Sort = 0, CityId = 52 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Sơn Dương", Sort = 0, CityId = 52 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Lào Cai", Sort = 0, CityId = 31 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bát Xát", Sort = 0, CityId = 31 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mường Khương", Sort = 0, CityId = 31 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Si Ma Cai", Sort = 0, CityId = 31 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bắc Hà", Sort = 0, CityId = 31 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bảo Thắng", Sort = 0, CityId = 31 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bảo Yên", Sort = 0, CityId = 31 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Sa Pa", Sort = 0, CityId = 31 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Văn Bàn", Sort = 0, CityId = 31 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Điện Biên Phủ", Sort = 0, CityId = 59 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị Xã Mường Lay", Sort = 0, CityId = 59 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mường Nhé", Sort = 0, CityId = 59 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mường Chà", Sort = 0, CityId = 59 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tủa Chùa", Sort = 0, CityId = 59 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tuần Giáo", Sort = 0, CityId = 59 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Điện Biên", Sort = 0, CityId = 59 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Điện Biên Đông", Sort = 0, CityId = 59 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mường Ảng", Sort = 0, CityId = 59 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nậm Pồ", Sort = 0, CityId = 59 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Lai Châu", Sort = 0, CityId = 28 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tam Đường", Sort = 0, CityId = 28 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mường Tè", Sort = 0, CityId = 28 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Sìn Hồ", Sort = 0, CityId = 28 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phong Thổ", Sort = 0, CityId = 28 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Than Uyên", Sort = 0, CityId = 28 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tân Uyên", Sort = 0, CityId = 28 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nậm Nhùn", Sort = 0, CityId = 28 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Sơn La", Sort = 0, CityId = 45 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quỳnh Nhai", Sort = 0, CityId = 45 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thuận Châu", Sort = 0, CityId = 45 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mường La", Sort = 0, CityId = 45 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bắc Yên", Sort = 0, CityId = 45 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phù Yên", Sort = 0, CityId = 45 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mộc Châu", Sort = 0, CityId = 45 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Yên Châu", Sort = 0, CityId = 45 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mai Sơn", Sort = 0, CityId = 45 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Sông Mã", Sort = 0, CityId = 45 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Sốp Cộp", Sort = 0, CityId = 45 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vân Hồ", Sort = 0, CityId = 45 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Yên Bái", Sort = 0, CityId = 55 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Nghĩa Lộ", Sort = 0, CityId = 55 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lục Yên", Sort = 0, CityId = 55 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Văn Yên", Sort = 0, CityId = 55 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mù Căng Chải", Sort = 0, CityId = 55 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Trấn Yên", Sort = 0, CityId = 55 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Trạm Tấu", Sort = 0, CityId = 55 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Văn Chấn", Sort = 0, CityId = 55 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Yên Bình", Sort = 0, CityId = 55 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Hòa Bình", Sort = 0, CityId = 23 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đà Bắc", Sort = 0, CityId = 23 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Kỳ Sơn", Sort = 0, CityId = 23 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lương Sơn", Sort = 0, CityId = 23 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Kim Bôi", Sort = 0, CityId = 23 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cao Phong", Sort = 0, CityId = 23 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tân Lạc", Sort = 0, CityId = 23 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mai Châu", Sort = 0, CityId = 23 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lạc Sơn", Sort = 0, CityId = 23 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Yên Thủy", Sort = 0, CityId = 23 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lạc Thủy", Sort = 0, CityId = 23 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Thái Nguyên", Sort = 0, CityId = 48 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Sông Công", Sort = 0, CityId = 48 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Định Hóa", Sort = 0, CityId = 48 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phú Lương", Sort = 0, CityId = 48 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đồng Hỷ", Sort = 0, CityId = 48 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Võ Nhai", Sort = 0, CityId = 48 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đại Từ", Sort = 0, CityId = 48 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Phổ Yên", Sort = 0, CityId = 48 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phú Bình", Sort = 0, CityId = 48 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Lạng Sơn", Sort = 0, CityId = 30 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tràng Định", Sort = 0, CityId = 30 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bình Gia", Sort = 0, CityId = 30 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Văn Lãng", Sort = 0, CityId = 30 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cao Lộc", Sort = 0, CityId = 30 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Văn Quan", Sort = 0, CityId = 30 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bắc Sơn", Sort = 0, CityId = 30 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hữu Lũng", Sort = 0, CityId = 30 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Chi Lăng", Sort = 0, CityId = 30 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lộc Bình", Sort = 0, CityId = 30 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đình Lập", Sort = 0, CityId = 30 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Hạ Long", Sort = 0, CityId = 42 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Móng Cái", Sort = 0, CityId = 42 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Cẩm Phả", Sort = 0, CityId = 42 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Uông Bí", Sort = 0, CityId = 42 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bình Liêu", Sort = 0, CityId = 42 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tiên Yên", Sort = 0, CityId = 42 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đầm Hà", Sort = 0, CityId = 42 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hải Hà", Sort = 0, CityId = 42 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ba Chẽ", Sort = 0, CityId = 42 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vân Đồn", Sort = 0, CityId = 42 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hoành Bồ", Sort = 0, CityId = 42 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Đông Triều", Sort = 0, CityId = 42 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Quảng Yên", Sort = 0, CityId = 42 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cô Tô", Sort = 0, CityId = 42 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Bắc Giang", Sort = 0, CityId = 5 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Yên Thế", Sort = 0, CityId = 5 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tân Yên", Sort = 0, CityId = 5 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lạng Giang", Sort = 0, CityId = 5 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lục Nam", Sort = 0, CityId = 5 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lục Ngạn", Sort = 0, CityId = 5 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Sơn Động", Sort = 0, CityId = 5 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Yên Dũng", Sort = 0, CityId = 5 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Việt Yên", Sort = 0, CityId = 5 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hiệp Hòa", Sort = 0, CityId = 5 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Việt Trì", Sort = 0, CityId = 37 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Phú Thọ", Sort = 0, CityId = 37 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đoan Hùng", Sort = 0, CityId = 37 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hạ Hòa", Sort = 0, CityId = 37 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thanh Ba", Sort = 0, CityId = 37 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phù Ninh", Sort = 0, CityId = 37 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Yên Lập", Sort = 0, CityId = 37 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cẩm Khê", Sort = 0, CityId = 37 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tam Nông", Sort = 0, CityId = 37 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lâm Thao", Sort = 0, CityId = 37 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thanh Sơn", Sort = 0, CityId = 37 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thanh Thuỷ", Sort = 0, CityId = 37 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tân Sơn", Sort = 0, CityId = 37 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Vĩnh Yên", Sort = 0, CityId = 54 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Phúc Yên", Sort = 0, CityId = 54 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lập Thạch", Sort = 0, CityId = 54 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tam Dương", Sort = 0, CityId = 54 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tam Đảo", Sort = 0, CityId = 54 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bình Xuyên", Sort = 0, CityId = 54 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mê Linh", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Yên Lạc", Sort = 0, CityId = 54 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vĩnh Tường", Sort = 0, CityId = 54 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Sông Lô", Sort = 0, CityId = 54 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Bắc Ninh", Sort = 0, CityId = 8 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Yên Phong", Sort = 0, CityId = 8 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quế Võ", Sort = 0, CityId = 8 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tiên Du", Sort = 0, CityId = 8 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Từ Sơn", Sort = 0, CityId = 8 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thuận Thành", Sort = 0, CityId = 8 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Gia Bình", Sort = 0, CityId = 8 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lương Tài", Sort = 0, CityId = 8 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Hà Đông", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Sơn Tây", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ba Vì", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phúc Thọ", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đan Phượng", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hoài Đức", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quốc Oai", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thạch Thất", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Chương Mỹ", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thanh Oai", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thường Tín", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phú Xuyên", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ứng Hòa", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mỹ Đức", Sort = 0, CityId = 2 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Hải Dương", Sort = 0, CityId = 20 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Chí Linh", Sort = 0, CityId = 20 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nam Sách", Sort = 0, CityId = 20 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Kinh Môn", Sort = 0, CityId = 20 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Kim Thành", Sort = 0, CityId = 20 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thanh Hà", Sort = 0, CityId = 20 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cẩm Giàng", Sort = 0, CityId = 20 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bình Giang", Sort = 0, CityId = 20 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Gia Lộc", Sort = 0, CityId = 20 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tứ Kỳ", Sort = 0, CityId = 20 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ninh Giang", Sort = 0, CityId = 20 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thanh Miện", Sort = 0, CityId = 20 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Hồng Bàng", Sort = 0, CityId = 21 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Ngô Quyền", Sort = 0, CityId = 21 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Lê Chân", Sort = 0, CityId = 21 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Hải An", Sort = 0, CityId = 21 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Kiến An", Sort = 0, CityId = 21 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Đồ Sơn", Sort = 0, CityId = 21 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Dương Kinh", Sort = 0, CityId = 21 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thủy Nguyên", Sort = 0, CityId = 21 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện An Dương", Sort = 0, CityId = 21 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện An Lão", Sort = 0, CityId = 21 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Kiến Thuỵ", Sort = 0, CityId = 21 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tiên Lãng", Sort = 0, CityId = 21 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vĩnh Bảo", Sort = 0, CityId = 21 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cát Hải", Sort = 0, CityId = 21 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bạch Long Vĩ", Sort = 0, CityId = 21 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Hưng Yên", Sort = 0, CityId = 24 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Văn Lâm", Sort = 0, CityId = 24 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Văn Giang", Sort = 0, CityId = 24 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Yên Mỹ", Sort = 0, CityId = 24 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mỹ Hào", Sort = 0, CityId = 24 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ân Thi", Sort = 0, CityId = 24 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Khoái Châu", Sort = 0, CityId = 24 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Kim Động", Sort = 0, CityId = 24 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tiên Lữ", Sort = 0, CityId = 24 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phù Cừ", Sort = 0, CityId = 24 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Thái Bình", Sort = 0, CityId = 47 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quỳnh Phụ", Sort = 0, CityId = 47 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hưng Hà", Sort = 0, CityId = 47 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đông Hưng", Sort = 0, CityId = 47 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thái Thụy", Sort = 0, CityId = 47 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tiền Hải", Sort = 0, CityId = 47 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Kiến Xương", Sort = 0, CityId = 47 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vũ Thư", Sort = 0, CityId = 47 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Phủ Lý", Sort = 0, CityId = 18 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Duy Tiên", Sort = 0, CityId = 18 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Kim Bảng", Sort = 0, CityId = 18 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thanh Liêm", Sort = 0, CityId = 18 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bình Lục", Sort = 0, CityId = 18 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lý Nhân", Sort = 0, CityId = 18 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Nam Định", Sort = 0, CityId = 33 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mỹ Lộc", Sort = 0, CityId = 33 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vụ Bản", Sort = 0, CityId = 33 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ý Yên", Sort = 0, CityId = 33 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nghĩa Hưng", Sort = 0, CityId = 33 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nam Trực", Sort = 0, CityId = 33 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Trực Ninh", Sort = 0, CityId = 33 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Xuân Trường", Sort = 0, CityId = 33 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Giao Thủy", Sort = 0, CityId = 33 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hải Hậu", Sort = 0, CityId = 33 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Ninh Bình", Sort = 0, CityId = 35 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Tam Điệp", Sort = 0, CityId = 35 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nho Quan", Sort = 0, CityId = 35 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Gia Viễn", Sort = 0, CityId = 35 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hoa Lư", Sort = 0, CityId = 35 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Yên Khánh", Sort = 0, CityId = 35 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Kim Sơn", Sort = 0, CityId = 35 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Yên Mô", Sort = 0, CityId = 35 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Thanh Hóa", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Bỉm Sơn", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Sầm Sơn", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mường Lát", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quan Hóa", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bá Thước", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quan Sơn", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lang Chánh", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ngọc Lặc", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cẩm Thủy", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thạch Thành", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hà Trung", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vĩnh Lộc", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Yên Định", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thọ Xuân", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thường Xuân", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Triệu Sơn", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thiệu Hóa", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hoằng Hóa", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hậu Lộc", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nga Sơn", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Như Xuân", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Như Thanh", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nông Cống", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đông Sơn", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quảng Xương", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tĩnh Gia", Sort = 0, CityId = 49 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Vinh", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Cửa Lò", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Thái Hòa", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quế Phong", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quỳ Châu", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Kỳ Sơn", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tương Dương", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nghĩa Đàn", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quỳ Hợp", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quỳnh Lưu", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Con Cuông", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tân Kỳ", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Anh Sơn", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Diễn Châu", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Yên Thành", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đô Lương", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thanh Chương", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nghi Lộc", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nam Đàn", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hưng Nguyên", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Hoàng Mai", Sort = 0, CityId = 34 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Hà Tĩnh", Sort = 0, CityId = 19 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Hồng Lĩnh", Sort = 0, CityId = 19 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hương Sơn", Sort = 0, CityId = 19 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đức Thọ", Sort = 0, CityId = 19 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vũ Quang", Sort = 0, CityId = 19 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nghi Xuân", Sort = 0, CityId = 19 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Can Lộc", Sort = 0, CityId = 19 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hương Khê", Sort = 0, CityId = 19 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thạch Hà", Sort = 0, CityId = 19 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cẩm Xuyên", Sort = 0, CityId = 19 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Kỳ Anh", Sort = 0, CityId = 19 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lộc Hà", Sort = 0, CityId = 19 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Kỳ Anh", Sort = 0, CityId = 19 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành Phố Đồng Hới", Sort = 0, CityId = 39 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Minh Hóa", Sort = 0, CityId = 39 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tuyên Hóa", Sort = 0, CityId = 39 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quảng Trạch", Sort = 0, CityId = 39 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bố Trạch", Sort = 0, CityId = 39 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quảng Ninh", Sort = 0, CityId = 39 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lệ Thủy", Sort = 0, CityId = 39 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Ba Đồn", Sort = 0, CityId = 39 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Đông Hà", Sort = 0, CityId = 43 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Quảng Trị", Sort = 0, CityId = 43 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vĩnh Linh", Sort = 0, CityId = 43 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hướng Hóa", Sort = 0, CityId = 43 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Gio Linh", Sort = 0, CityId = 43 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đakrông", Sort = 0, CityId = 43 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cam Lộ", Sort = 0, CityId = 43 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Triệu Phong", Sort = 0, CityId = 43 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hải Lăng", Sort = 0, CityId = 43 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Huế", Sort = 0, CityId = 64 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phong Điền", Sort = 0, CityId = 64 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quảng Điền", Sort = 0, CityId = 64 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phú Vang", Sort = 0, CityId = 64 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Hương Thủy", Sort = 0, CityId = 64 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Hương Trà", Sort = 0, CityId = 64 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện A Lưới", Sort = 0, CityId = 64 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phú Lộc", Sort = 0, CityId = 64 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nam Đông", Sort = 0, CityId = 64 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Liên Chiểu", Sort = 0, CityId = 56 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Thanh Khê", Sort = 0, CityId = 56 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Hải Châu", Sort = 0, CityId = 56 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Sơn Trà", Sort = 0, CityId = 56 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Ngũ Hành Sơn", Sort = 0, CityId = 56 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Cẩm Lệ", Sort = 0, CityId = 56 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hòa Vang", Sort = 0, CityId = 56 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Tam Kỳ", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Hội An", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tây Giang", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đông Giang", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đại Lộc", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Điện Bàn", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Duy Xuyên", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Quế Sơn", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nam Giang", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phước Sơn", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hiệp Đức", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thăng Bình", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tiên Phước", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bắc Trà My", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nam Trà My", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Núi Thành", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phú Ninh", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nông Sơn", Sort = 0, CityId = 40 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Quảng Ngãi", Sort = 0, CityId = 41 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bình Sơn", Sort = 0, CityId = 41 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Trà Bồng", Sort = 0, CityId = 41 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tây Trà", Sort = 0, CityId = 41 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Sơn Tịnh", Sort = 0, CityId = 41 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tư Nghĩa", Sort = 0, CityId = 41 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Sơn Hà", Sort = 0, CityId = 41 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Sơn Tây", Sort = 0, CityId = 41 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Minh Long", Sort = 0, CityId = 41 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nghĩa Hành", Sort = 0, CityId = 41 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mộ Đức", Sort = 0, CityId = 41 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đức Phổ", Sort = 0, CityId = 41 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ba Tơ", Sort = 0, CityId = 41 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lý Sơn", Sort = 0, CityId = 41 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Quy Nhơn", Sort = 0, CityId = 12 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện An Lão", Sort = 0, CityId = 12 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hoài Nhơn", Sort = 0, CityId = 12 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hoài Ân", Sort = 0, CityId = 12 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phù Mỹ", Sort = 0, CityId = 12 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vĩnh Thạnh", Sort = 0, CityId = 12 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tây Sơn", Sort = 0, CityId = 12 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phù Cát", Sort = 0, CityId = 12 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã An Nhơn", Sort = 0, CityId = 12 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tuy Phước", Sort = 0, CityId = 12 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vân Canh", Sort = 0, CityId = 12 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Tuy Hòa", Sort = 0, CityId = 38 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Sông Cầu", Sort = 0, CityId = 38 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đồng Xuân", Sort = 0, CityId = 38 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tuy An", Sort = 0, CityId = 38 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Sơn Hòa", Sort = 0, CityId = 38 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Sông Hinh", Sort = 0, CityId = 38 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tây Hòa", Sort = 0, CityId = 38 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phú Hòa", Sort = 0, CityId = 38 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đông Hòa", Sort = 0, CityId = 38 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Nha Trang", Sort = 0, CityId = 25 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Cam Ranh", Sort = 0, CityId = 25 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cam Lâm", Sort = 0, CityId = 25 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vạn Ninh", Sort = 0, CityId = 25 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Ninh Hòa", Sort = 0, CityId = 25 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Khánh Vĩnh", Sort = 0, CityId = 25 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Diên Khánh", Sort = 0, CityId = 25 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Khánh Sơn", Sort = 0, CityId = 25 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Trường Sa", Sort = 0, CityId = 25 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Phan Rang-Tháp Chàm", Sort = 0, CityId = 36 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bác Ái", Sort = 0, CityId = 36 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ninh Sơn", Sort = 0, CityId = 36 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ninh Hải", Sort = 0, CityId = 36 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ninh Phước", Sort = 0, CityId = 36 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thuận Bắc", Sort = 0, CityId = 36 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thuận Nam", Sort = 0, CityId = 36 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Phan Thiết", Sort = 0, CityId = 11 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã La Gi", Sort = 0, CityId = 11 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tuy Phong", Sort = 0, CityId = 11 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bắc Bình", Sort = 0, CityId = 11 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hàm Thuận Bắc", Sort = 0, CityId = 11 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hàm Thuận Nam", Sort = 0, CityId = 11 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tánh Linh", Sort = 0, CityId = 11 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đức Linh", Sort = 0, CityId = 11 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hàm Tân", Sort = 0, CityId = 11 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phú Quí", Sort = 0, CityId = 11 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Kon Tum", Sort = 0, CityId = 27 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đắk Glei", Sort = 0, CityId = 27 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ngọc Hồi", Sort = 0, CityId = 27 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đắk Tô", Sort = 0, CityId = 27 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Kon Plông", Sort = 0, CityId = 27 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Kon Rẫy", Sort = 0, CityId = 27 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đắk Hà", Sort = 0, CityId = 27 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Sa Thầy", Sort = 0, CityId = 27 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tu Mơ Rông", Sort = 0, CityId = 27 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ia H' Drai", Sort = 0, CityId = 27 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Pleiku", Sort = 0, CityId = 16 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã An Khê", Sort = 0, CityId = 16 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Ayun Pa", Sort = 0, CityId = 16 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện KBang", Sort = 0, CityId = 16 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đăk Đoa", Sort = 0, CityId = 16 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Chư Păh", Sort = 0, CityId = 16 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ia Grai", Sort = 0, CityId = 16 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mang Yang", Sort = 0, CityId = 16 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Kông Chro", Sort = 0, CityId = 16 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đức Cơ", Sort = 0, CityId = 16 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Chư Prông", Sort = 0, CityId = 16 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Chư Sê", Sort = 0, CityId = 16 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đăk Pơ", Sort = 0, CityId = 16 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ia Pa", Sort = 0, CityId = 16 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Krông Pa", Sort = 0, CityId = 16 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phú Thiện", Sort = 0, CityId = 16 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Chư Pưh", Sort = 0, CityId = 16 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Buôn Ma Thuột", Sort = 0, CityId = 57 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị Xã Buôn Hồ", Sort = 0, CityId = 57 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ea H'leo", Sort = 0, CityId = 57 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ea Súp", Sort = 0, CityId = 57 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Buôn Đôn", Sort = 0, CityId = 57 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cư M'gar", Sort = 0, CityId = 57 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Krông Búk", Sort = 0, CityId = 57 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Krông Năng", Sort = 0, CityId = 57 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ea Kar", Sort = 0, CityId = 57 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện M'Đrắk", Sort = 0, CityId = 57 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Krông Bông", Sort = 0, CityId = 57 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Krông Pắc", Sort = 0, CityId = 57 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Krông A Na", Sort = 0, CityId = 57 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lắk", Sort = 0, CityId = 57 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cư Kuin", Sort = 0, CityId = 57 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Gia Nghĩa", Sort = 0, CityId = 58 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đăk Glong", Sort = 0, CityId = 58 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cư Jút", Sort = 0, CityId = 58 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đắk Mil", Sort = 0, CityId = 58 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Krông Nô", Sort = 0, CityId = 58 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đắk Song", Sort = 0, CityId = 58 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đắk R'Lấp", Sort = 0, CityId = 58 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tuy Đức", Sort = 0, CityId = 58 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Đà Lạt", Sort = 0, CityId = 29 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Bảo Lộc", Sort = 0, CityId = 29 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đam Rông", Sort = 0, CityId = 29 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lạc Dương", Sort = 0, CityId = 29 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lâm Hà", Sort = 0, CityId = 29 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đơn Dương", Sort = 0, CityId = 29 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đức Trọng", Sort = 0, CityId = 29 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Di Linh", Sort = 0, CityId = 29 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bảo Lâm", Sort = 0, CityId = 29 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đạ Huoai", Sort = 0, CityId = 29 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đạ Tẻh", Sort = 0, CityId = 29 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cát Tiên", Sort = 0, CityId = 29 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Phước Long", Sort = 0, CityId = 10 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Đồng Xoài", Sort = 0, CityId = 10 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Bình Long", Sort = 0, CityId = 10 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bù Gia Mập", Sort = 0, CityId = 10 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lộc Ninh", Sort = 0, CityId = 10 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bù Đốp", Sort = 0, CityId = 10 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hớn Quản", Sort = 0, CityId = 10 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đồng Phú", Sort = 0, CityId = 10 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bù Đăng", Sort = 0, CityId = 10 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Chơn Thành", Sort = 0, CityId = 10 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phú Riềng", Sort = 0, CityId = 10 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Tây Ninh", Sort = 0, CityId = 46 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tân Biên", Sort = 0, CityId = 46 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tân Châu", Sort = 0, CityId = 46 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Dương Minh Châu", Sort = 0, CityId = 46 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Châu Thành", Sort = 0, CityId = 46 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hòa Thành", Sort = 0, CityId = 46 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Gò Dầu", Sort = 0, CityId = 46 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bến Cầu", Sort = 0, CityId = 46 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Trảng Bàng", Sort = 0, CityId = 46 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Thủ Dầu Một", Sort = 0, CityId = 9 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bàu Bàng", Sort = 0, CityId = 9 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Dầu Tiếng", Sort = 0, CityId = 9 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Bến Cát", Sort = 0, CityId = 9 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phú Giáo", Sort = 0, CityId = 9 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Tân Uyên", Sort = 0, CityId = 9 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Dĩ An", Sort = 0, CityId = 9 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Thuận An", Sort = 0, CityId = 9 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bắc Tân Uyên", Sort = 0, CityId = 9 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Biên Hòa", Sort = 0, CityId = 60 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Long Khánh", Sort = 0, CityId = 60 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tân Phú", Sort = 0, CityId = 60 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vĩnh Cửu", Sort = 0, CityId = 60 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Định Quán", Sort = 0, CityId = 60 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Trảng Bom", Sort = 0, CityId = 60 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thống Nhất", Sort = 0, CityId = 60 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cẩm Mỹ", Sort = 0, CityId = 60 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Long Thành", Sort = 0, CityId = 60 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Xuân Lộc", Sort = 0, CityId = 60 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nhơn Trạch", Sort = 0, CityId = 60 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Vũng Tàu", Sort = 0, CityId = 62 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Bà Rịa", Sort = 0, CityId = 62 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Châu Đức", Sort = 0, CityId = 62 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Xuyên Mộc", Sort = 0, CityId = 62 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Long Điền", Sort = 0, CityId = 62 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đất Đỏ", Sort = 0, CityId = 62 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tân Thành", Sort = 0, CityId = 62 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Côn Đảo", Sort = 0, CityId = 62 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận 1", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận 12", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Thủ Đức", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận 9", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Gò Vấp", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Bình Thạnh", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Tân Bình", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Tân Phú", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Phú Nhuận", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận 2", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận 3", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận 10", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận 11", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận 4", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận 5", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận 6", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận 8", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Bình Tân", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận 7", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Củ Chi", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hóc Môn", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bình Chánh", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Nhà Bè", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cần Giờ", Sort = 0, CityId = 1 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Tân An", Sort = 0, CityId = 32 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Kiến Tường", Sort = 0, CityId = 32 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tân Hưng", Sort = 0, CityId = 32 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vĩnh Hưng", Sort = 0, CityId = 32 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mộc Hóa", Sort = 0, CityId = 32 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tân Thạnh", Sort = 0, CityId = 32 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thạnh Hóa", Sort = 0, CityId = 32 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đức Huệ", Sort = 0, CityId = 32 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đức Hòa", Sort = 0, CityId = 32 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bến Lức", Sort = 0, CityId = 32 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thủ Thừa", Sort = 0, CityId = 32 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tân Trụ", Sort = 0, CityId = 32 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cần Đước", Sort = 0, CityId = 32 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cần Giuộc", Sort = 0, CityId = 32 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Châu Thành", Sort = 0, CityId = 32 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Mỹ Tho", Sort = 0, CityId = 50 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Gò Công", Sort = 0, CityId = 50 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Cai Lậy", Sort = 0, CityId = 50 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tân Phước", Sort = 0, CityId = 50 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cái Bè", Sort = 0, CityId = 50 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cai Lậy", Sort = 0, CityId = 50 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Châu Thành", Sort = 0, CityId = 50 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Chợ Gạo", Sort = 0, CityId = 50 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Gò Công Tây", Sort = 0, CityId = 50 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Gò Công Đông", Sort = 0, CityId = 50 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tân Phú Đông", Sort = 0, CityId = 50 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Bến Tre", Sort = 0, CityId = 63 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Châu Thành", Sort = 0, CityId = 63 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Chợ Lách", Sort = 0, CityId = 63 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mỏ Cày Nam", Sort = 0, CityId = 63 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Giồng Trôm", Sort = 0, CityId = 63 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bình Đại", Sort = 0, CityId = 63 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ba Tri", Sort = 0, CityId = 63 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thạnh Phú", Sort = 0, CityId = 63 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mỏ Cày Bắc", Sort = 0, CityId = 63 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Trà Vinh", Sort = 0, CityId = 51 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Càng Long", Sort = 0, CityId = 51 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cầu Kè", Sort = 0, CityId = 51 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tiểu Cần", Sort = 0, CityId = 51 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Châu Thành", Sort = 0, CityId = 51 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cầu Ngang", Sort = 0, CityId = 51 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Trà Cú", Sort = 0, CityId = 51 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Duyên Hải", Sort = 0, CityId = 51 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Duyên Hải", Sort = 0, CityId = 51 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Vĩnh Long", Sort = 0, CityId = 53 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Long Hồ", Sort = 0, CityId = 53 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mang Thít", Sort = 0, CityId = 53 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vũng Liêm", Sort = 0, CityId = 53 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tam Bình", Sort = 0, CityId = 53 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Bình Minh", Sort = 0, CityId = 53 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Trà Ôn", Sort = 0, CityId = 53 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Bình Tân", Sort = 0, CityId = 53 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Cao Lãnh", Sort = 0, CityId = 61 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Sa Đéc", Sort = 0, CityId = 61 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Hồng Ngự", Sort = 0, CityId = 61 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tân Hồng", Sort = 0, CityId = 61 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hồng Ngự", Sort = 0, CityId = 61 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tam Nông", Sort = 0, CityId = 61 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tháp Mười", Sort = 0, CityId = 61 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cao Lãnh", Sort = 0, CityId = 61 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thanh Bình", Sort = 0, CityId = 61 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lấp Vò", Sort = 0, CityId = 61 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Lai Vung", Sort = 0, CityId = 61 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Châu Thành", Sort = 0, CityId = 61 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Long Xuyên", Sort = 0, CityId = 4 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Châu Đốc", Sort = 0, CityId = 4 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện An Phú", Sort = 0, CityId = 4 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Tân Châu", Sort = 0, CityId = 4 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phú Tân", Sort = 0, CityId = 4 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Châu Phú", Sort = 0, CityId = 4 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tịnh Biên", Sort = 0, CityId = 4 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tri Tôn", Sort = 0, CityId = 4 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Châu Thành", Sort = 0, CityId = 4 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Chợ Mới", Sort = 0, CityId = 4 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thoại Sơn", Sort = 0, CityId = 4 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Rạch Giá", Sort = 0, CityId = 26 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Hà Tiên", Sort = 0, CityId = 26 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Kiên Lương", Sort = 0, CityId = 26 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hòn Đất", Sort = 0, CityId = 26 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Tân Hiệp", Sort = 0, CityId = 26 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Châu Thành", Sort = 0, CityId = 26 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Giồng Riềng", Sort = 0, CityId = 26 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Gò Quao", Sort = 0, CityId = 26 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện An Biên", Sort = 0, CityId = 26 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện An Minh", Sort = 0, CityId = 26 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vĩnh Thuận", Sort = 0, CityId = 26 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phú Quốc", Sort = 0, CityId = 26 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Kiên Hải", Sort = 0, CityId = 26 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện U Minh Thượng", Sort = 0, CityId = 26 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Giang Thành", Sort = 0, CityId = 26 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Ninh Kiều", Sort = 0, CityId = 14 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Ô Môn", Sort = 0, CityId = 14 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Bình Thuỷ", Sort = 0, CityId = 14 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Cái Răng", Sort = 0, CityId = 14 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Quận Thốt Nốt", Sort = 0, CityId = 14 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vĩnh Thạnh", Sort = 0, CityId = 14 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cờ Đỏ", Sort = 0, CityId = 14 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phong Điền", Sort = 0, CityId = 14 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thới Lai", Sort = 0, CityId = 14 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Vị Thanh", Sort = 0, CityId = 22 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Ngã Bảy", Sort = 0, CityId = 22 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Châu Thành A", Sort = 0, CityId = 22 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Châu Thành", Sort = 0, CityId = 22 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phụng Hiệp", Sort = 0, CityId = 22 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vị Thủy", Sort = 0, CityId = 22 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Long Mỹ", Sort = 0, CityId = 22 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Long Mỹ", Sort = 0, CityId = 22 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Sóc Trăng", Sort = 0, CityId = 44 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Châu Thành", Sort = 0, CityId = 44 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Kế Sách", Sort = 0, CityId = 44 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mỹ Tú", Sort = 0, CityId = 44 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cù Lao Dung", Sort = 0, CityId = 44 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Long Phú", Sort = 0, CityId = 44 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Mỹ Xuyên", Sort = 0, CityId = 44 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Ngã Năm", Sort = 0, CityId = 44 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thạnh Trị", Sort = 0, CityId = 44 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Vĩnh Châu", Sort = 0, CityId = 44 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Trần Đề", Sort = 0, CityId = 44 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Bạc Liêu", Sort = 0, CityId = 7 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hồng Dân", Sort = 0, CityId = 7 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phước Long", Sort = 0, CityId = 7 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Vĩnh Lợi", Sort = 0, CityId = 7 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thị xã Giá Rai", Sort = 0, CityId = 7 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đông Hải", Sort = 0, CityId = 7 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Hòa Bình", Sort = 0, CityId = 7 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Thành phố Cà Mau", Sort = 0, CityId = 7 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện U Minh", Sort = 0, CityId = 7 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Thới Bình", Sort = 0, CityId = 7 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Trần Văn Thời", Sort = 0, CityId = 7 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Cái Nước", Sort = 0, CityId = 7 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Đầm Dơi", Sort = 0, CityId = 7 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Năm Căn", Sort = 0, CityId = 7 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Phú Tân", Sort = 0, CityId = 7 });
            //modelBuilder.Entity<District>().HasData(new District { Name = "Huyện Ngọc Hiển", Sort = 0, CityId = 7 });

            //#endregion

            //#region Ward
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phúc Xá", Sort = 1, DistrictId = 1 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Trúc Bạch", Sort = 1, DistrictId = 1 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Vĩnh Phúc", Sort = 1, DistrictId = 1 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Cống Vị", Sort = 1, DistrictId = 1 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Liễu Giai", Sort = 1, DistrictId = 1 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Nguyễn Trung Trực", Sort = 1, DistrictId = 1 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Quán Thánh", Sort = 1, DistrictId = 1 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Ngọc Hà", Sort = 1, DistrictId = 1 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Điện Biên", Sort = 1, DistrictId = 1 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Đội Cấn", Sort = 1, DistrictId = 1 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Ngọc Khánh", Sort = 1, DistrictId = 1 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Kim Mã", Sort = 1, DistrictId = 1 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Giảng Võ", Sort = 1, DistrictId = 1 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Thành Công", Sort = 1, DistrictId = 1 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phúc Tân", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Đồng Xuân", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Hàng Mã", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Hàng Buồm", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Hàng Đào", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Hàng Bồ", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Cửa Đông", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Lý Thái Tổ", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Hàng Bạc", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Hàng Gai", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Chương Dương Độ", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Hàng Trống", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Cửa Nam", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Hàng Bông", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Tràng Tiền", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Trần Hưng Đạo", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phan Chu Trinh", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Hàng Bài", Sort = 1, DistrictId = 2 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phú Thượng", Sort = 1, DistrictId = 3 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Nhật Tân", Sort = 1, DistrictId = 3 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Tứ Liên", Sort = 1, DistrictId = 3 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Quảng An", Sort = 1, DistrictId = 3 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Xuân La", Sort = 1, DistrictId = 3 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Yên Phụ", Sort = 1, DistrictId = 3 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Bưởi", Sort = 1, DistrictId = 3 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Thụy Khuê", Sort = 1, DistrictId = 3 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Thượng Thanh", Sort = 1, DistrictId = 4 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Ngọc Thụy", Sort = 1, DistrictId = 4 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Giang Biên", Sort = 1, DistrictId = 4 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Đức Giang", Sort = 1, DistrictId = 4 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Việt Hưng", Sort = 1, DistrictId = 4 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Gia Thụy", Sort = 1, DistrictId = 4 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Ngọc Lâm", Sort = 1, DistrictId = 4 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phúc Lợi", Sort = 1, DistrictId = 4 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Bồ Đề", Sort = 1, DistrictId = 4 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Sài Đồng", Sort = 1, DistrictId = 4 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Long Biên", Sort = 1, DistrictId = 4 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Thạch Bàn", Sort = 1, DistrictId = 4 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phúc Đồng", Sort = 1, DistrictId = 4 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Cự Khối", Sort = 1, DistrictId = 4 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Nghĩa Đô", Sort = 1, DistrictId = 5 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Nghĩa Tân", Sort = 1, DistrictId = 5 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Mai Dịch", Sort = 1, DistrictId = 5 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Dịch Vọng", Sort = 1, DistrictId = 5 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Dịch Vọng Hậu", Sort = 1, DistrictId = 5 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Quan Hoa", Sort = 1, DistrictId = 5 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Yên Hòa", Sort = 1, DistrictId = 5 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Trung Hòa", Sort = 1, DistrictId = 5 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Cát Linh", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Văn Miếu", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Quốc Tử Giám", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Láng Thượng", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Ô Chợ Dừa", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Văn Chương", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Hàng Bột", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Láng Hạ", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Khâm Thiên", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Thổ Quan", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Nam Đồng", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Trung Phụng", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Quang Trung", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Trung Liệt", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phương Liên", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Thịnh Quang", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Trung Tự", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Kim Liên", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phương Mai", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Ngã Tư Sở", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Khương Thượng", Sort = 1, DistrictId = 6 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Nguyễn Du", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Bạch Đằng", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phạm Đình Hổ", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Bùi Thị Xuân", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Ngô Thì Nhậm", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Lê Đại Hành", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Đồng Nhân", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phố Huế", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Đống Mác", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Thanh Lương", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Thanh Nhàn", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Cầu Dền", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Bách Khoa", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Đồng Tâm", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Vĩnh Tuy", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Bạch Mai", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Quỳnh Mai", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Quỳnh Lôi", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Minh Khai", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Trương Định", Sort = 1, DistrictId = 7 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Thanh Trì", Sort = 1, DistrictId = 8 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Vĩnh Hưng", Sort = 1, DistrictId = 8 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Định Công", Sort = 1, DistrictId = 8 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Mai Động", Sort = 1, DistrictId = 8 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Tương Mai", Sort = 1, DistrictId = 8 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Đại Kim", Sort = 1, DistrictId = 8 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Tân Mai", Sort = 1, DistrictId = 8 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Hoàng Văn Thụ", Sort = 1, DistrictId = 8 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Giáp Bát", Sort = 1, DistrictId = 8 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Lĩnh Nam", Sort = 1, DistrictId = 8 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Thịnh Liệt", Sort = 1, DistrictId = 8 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Trần Phú", Sort = 1, DistrictId = 8 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Hoàng Liệt", Sort = 1, DistrictId = 8 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Yên Sở", Sort = 1, DistrictId = 8 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Nhân Chính", Sort = 1, DistrictId = 9 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Thượng Đình", Sort = 1, DistrictId = 9 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Khương Trung", Sort = 1, DistrictId = 9 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Khương Mai", Sort = 1, DistrictId = 9 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Thanh Xuân Trung", Sort = 1, DistrictId = 9 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phương Liệt", Sort = 1, DistrictId = 9 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Hạ Đình", Sort = 1, DistrictId = 9 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Khương Đình", Sort = 1, DistrictId = 9 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Thanh Xuân Bắc", Sort = 1, DistrictId = 9 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Thanh Xuân Nam", Sort = 1, DistrictId = 9 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Kim Giang", Sort = 1, DistrictId = 9 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Sóc Sơn", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bắc Sơn", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Minh Trí", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hồng Kỳ", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nam Sơn", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trung Giã", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Hưng", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Minh Phú", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phù Linh", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bắc Phú", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Minh", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quang Tiến", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hiền Ninh", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Dân", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tiên Dược", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Việt Long", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xuân Giang", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Mai Đình", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đức Hòa", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thanh Xuân", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đông Xuân", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kim Lũ", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phú Cường", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phú Minh", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phù Lỗ", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xuân Thu", Sort = 1, DistrictId = 16 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Đông Anh", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xuân Nộn", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thuỵ Lâm", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bắc Hồng", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nguyên Khê", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nam Hồng", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tiên Dương", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vân Hà", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Uy Nỗ", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vân Nội", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Liên Hà", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Việt Hùng", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kim Nỗ", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kim Chung", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Dục Tú", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đại Mạch", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vĩnh Ngọc", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cổ Loa", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hải Bối", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xuân Canh", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Võng La", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tầm Xá", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Mai Lâm", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đông Hội", Sort = 1, DistrictId = 17 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Yên Viên", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Thường", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Viên", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ninh Hiệp", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đình Xuyên", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Dương Hà", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phù Đổng", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trung Mầu", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lệ Chi", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cổ Bi", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đặng Xá", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phú Thị", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kim Sơn", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Trâu Quỳ", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Dương Quang", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Dương Xá", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đông Dư", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đa Tốn", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kiêu Kỵ", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bát Tràng", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kim Lan", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Văn Đức", Sort = 1, DistrictId = 18 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Cầu Diễn", Sort = 1, DistrictId = 19 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Thượng Cát", Sort = 1, DistrictId = 21 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Liên Mạc", Sort = 1, DistrictId = 21 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Đông Ngạc", Sort = 1, DistrictId = 21 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Đức Thắng", Sort = 1, DistrictId = 21 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Thụy Phương", Sort = 1, DistrictId = 21 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Tây Tựu", Sort = 1, DistrictId = 21 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Xuân Đỉnh", Sort = 1, DistrictId = 21 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Xuân Tảo", Sort = 1, DistrictId = 21 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Minh Khai", Sort = 1, DistrictId = 21 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Cổ Nhuế 1", Sort = 1, DistrictId = 21 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Cổ Nhuế 2", Sort = 1, DistrictId = 21 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phú Diễn", Sort = 1, DistrictId = 21 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phúc Diễn", Sort = 1, DistrictId = 21 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Xuân Phương", Sort = 1, DistrictId = 19 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phương Canh", Sort = 1, DistrictId = 19 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Mỹ Đình 1", Sort = 1, DistrictId = 19 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Mỹ Đình 2", Sort = 1, DistrictId = 19 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Tây Mỗ", Sort = 1, DistrictId = 19 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Mễ Trì", Sort = 1, DistrictId = 19 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phú Đô", Sort = 1, DistrictId = 19 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Đại Mỗ", Sort = 1, DistrictId = 19 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Trung Văn", Sort = 1, DistrictId = 19 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Văn Điển", Sort = 1, DistrictId = 20 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Triều", Sort = 1, DistrictId = 20 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thanh Liệt", Sort = 1, DistrictId = 20 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tả Thanh Oai", Sort = 1, DistrictId = 20 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hữu Hòa", Sort = 1, DistrictId = 20 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tam Hiệp", Sort = 1, DistrictId = 20 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tứ Hiệp", Sort = 1, DistrictId = 20 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Mỹ", Sort = 1, DistrictId = 20 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vĩnh Quỳnh", Sort = 1, DistrictId = 20 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngũ Hiệp", Sort = 1, DistrictId = 20 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Duyên Hà", Sort = 1, DistrictId = 20 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngọc Hồi", Sort = 1, DistrictId = 20 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vạn Phúc", Sort = 1, DistrictId = 20 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đại áng", Sort = 1, DistrictId = 20 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Liên Ninh", Sort = 1, DistrictId = 20 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đông Mỹ", Sort = 1, DistrictId = 20 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Quang Trung", Sort = 1, DistrictId = 24 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Trần Phú", Sort = 1, DistrictId = 24 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Ngọc Hà", Sort = 1, DistrictId = 24 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Nguyễn Trãi", Sort = 1, DistrictId = 24 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Minh Khai", Sort = 1, DistrictId = 24 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngọc Đường", Sort = 1, DistrictId = 24 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kim Thạch", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phú Linh", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kim Linh", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Phố Bảng", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lũng Cú", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Má Lé", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Đồng Văn", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lũng Táo", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phố Là", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thài Phìn Tủng", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sủng Là", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xà Phìn", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tả Phìn", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tả Lủng", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phố Cáo", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sính Lủng", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sảng Tủng", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lũng Thầu", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hố Quáng Phìn", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vần Chải", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lũng Phìn", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sủng Trái", Sort = 1, DistrictId = 26 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Mèo Vạc", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thượng Phùng", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Pải Lủng", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xín Cái", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Pả Vi", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Giàng Chu Phìn", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sủng Trà", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sủng Máng", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sơn Vĩ", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tả Lủng", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cán Chu Phìn", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lũng Pù", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lũng Chinh", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tát Ngà", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nậm Ban", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Khâu Vai", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Niêm Tòng", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Niêm Sơn", Sort = 1, DistrictId = 27 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Yên Minh", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thắng Mố", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phú Lũng", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sủng Tráng", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bạch Đích", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Na Khê", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sủng Thài", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hữu Vinh", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lao Và Chải", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Mậu Duệ", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đông Minh", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Mậu Long", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngam La", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngọc Long", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đường Thượng", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lũng Hồ", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Du Tiến", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Du Già", Sort = 1, DistrictId = 28 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Tam Sơn", Sort = 1, DistrictId = 29 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bát Đại Sơn", Sort = 1, DistrictId = 29 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nghĩa Thuận", Sort = 1, DistrictId = 29 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cán Tỷ", Sort = 1, DistrictId = 29 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cao Mã Pờ", Sort = 1, DistrictId = 29 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thanh Vân", Sort = 1, DistrictId = 29 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tùng Vài", Sort = 1, DistrictId = 29 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đông Hà", Sort = 1, DistrictId = 29 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quản Bạ", Sort = 1, DistrictId = 29 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lùng Tám", Sort = 1, DistrictId = 29 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quyết Tiến", Sort = 1, DistrictId = 29 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tả Ván", Sort = 1, DistrictId = 29 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thái An", Sort = 1, DistrictId = 29 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Vị Xuyên", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Nông Trường Việt Lâm", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Minh Tân", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thuận Hòa", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tùng Bá", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thanh Thủy", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thanh Đức", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phong Quang", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xín Chải", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phương Tiến", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lao Chải", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phương Độ", Sort = 1, DistrictId = 24 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phương Thiện", Sort = 1, DistrictId = 24 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cao Bồ", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đạo Đức", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thượng Sơn", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Linh Hồ", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quảng Ngần", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Việt Lâm", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngọc Linh", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngọc Minh", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bạch Ngọc", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trung Thành", Sort = 1, DistrictId = 30 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Minh Sơn", Sort = 1, DistrictId = 31 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Giáp Trung", Sort = 1, DistrictId = 31 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Định", Sort = 1, DistrictId = 31 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Yên Phú", Sort = 1, DistrictId = 31 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Minh Ngọc", Sort = 1, DistrictId = 31 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Phong", Sort = 1, DistrictId = 31 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lạc Nông", Sort = 1, DistrictId = 31 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phú Nam", Sort = 1, DistrictId = 31 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Cường", Sort = 1, DistrictId = 31 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thượng Tân", Sort = 1, DistrictId = 31 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đường Âm", Sort = 1, DistrictId = 31 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đường Hồng", Sort = 1, DistrictId = 31 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phiêng Luông", Sort = 1, DistrictId = 31 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Vinh Quang", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Máy", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thàng Tín", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thèn Chu Phìn", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Pố Lồ", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Phùng", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Túng Sán", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Chiến Phố", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đản Ván", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tụ Nhân", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Tiến", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nàng Đôn", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Pờ Ly Ngài", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sán Xả Hồ", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Luốc", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngàm Đăng Vài", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Nhùng", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tả Sử Choóng", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nậm Dịch", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Péo", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hồ Thầu", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nam Sơn", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nậm Tỵ", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thông Nguyên", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nậm Khòa", Sort = 1, DistrictId = 32 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Cốc Pài", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nàn Xỉn", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Díu", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Chí Cà", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xín Mần", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trung Thịnh", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thèn Phàng", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngán Chiên", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Pà Vầy Sủ", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cốc Rế", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thu Tà", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nàn Ma", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tả Nhìu", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Ngò", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Chế Là", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nấm Dẩn", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quảng Nguyên", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nà Chì", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Khuôn Lùng", Sort = 1, DistrictId = 33 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Việt Quang", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Vĩnh Tuy", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Lập", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Thành", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đồng Tiến", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đồng Tâm", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Quang", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thượng Bình", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hữu Sản", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kim Ngọc", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Việt Vinh", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bằng Hành", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quang Minh", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Liên Hiệp", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vô Điếm", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Việt Hồng", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hùng An", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đức Xuân", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tiên Kiều", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vĩnh Hảo", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vĩnh Phúc", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đồng Yên", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đông Thành", Sort = 1, DistrictId = 34 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xuân Minh", Sort = 1, DistrictId = 35 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tiên Nguyên", Sort = 1, DistrictId = 35 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Nam", Sort = 1, DistrictId = 35 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Rịa", Sort = 1, DistrictId = 35 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Thành", Sort = 1, DistrictId = 35 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Yên Bình", Sort = 1, DistrictId = 35 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Trịnh", Sort = 1, DistrictId = 35 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Bắc", Sort = 1, DistrictId = 35 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bằng Lang", Sort = 1, DistrictId = 35 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Hà", Sort = 1, DistrictId = 35 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hương Sơn", Sort = 1, DistrictId = 35 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xuân Giang", Sort = 1, DistrictId = 35 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nà Khương", Sort = 1, DistrictId = 35 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tiên Yên", Sort = 1, DistrictId = 35 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vĩ Thượng", Sort = 1, DistrictId = 35 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Sông Hiến", Sort = 1, DistrictId = 40 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Sông Bằng", Sort = 1, DistrictId = 40 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Hợp Giang", Sort = 1, DistrictId = 40 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Tân Giang", Sort = 1, DistrictId = 40 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Ngọc Xuân", Sort = 1, DistrictId = 40 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Đề Thám", Sort = 1, DistrictId = 40 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Hòa Chung", Sort = 1, DistrictId = 40 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Duyệt Trung", Sort = 1, DistrictId = 40 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Pác Miầu", Sort = 1, DistrictId = 42 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đức Hạnh", Sort = 1, DistrictId = 42 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lý Bôn", Sort = 1, DistrictId = 42 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nam Cao", Sort = 1, DistrictId = 42 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nam Quang", Sort = 1, DistrictId = 42 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vĩnh Quang", Sort = 1, DistrictId = 42 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quảng Lâm", Sort = 1, DistrictId = 42 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thạch Lâm", Sort = 1, DistrictId = 42 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Việt", Sort = 1, DistrictId = 42 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vĩnh Phong", Sort = 1, DistrictId = 42 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Mông Ân", Sort = 1, DistrictId = 42 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thái Học", Sort = 1, DistrictId = 42 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thái Sơn", Sort = 1, DistrictId = 42 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Thổ", Sort = 1, DistrictId = 42 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Bảo Lạc", Sort = 1, DistrictId = 43 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cốc Pàng", Sort = 1, DistrictId = 43 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thượng Hà", Sort = 1, DistrictId = 43 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cô Ba", Sort = 1, DistrictId = 43 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bảo Toàn", Sort = 1, DistrictId = 43 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Khánh Xuân", Sort = 1, DistrictId = 43 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xuân Trường", Sort = 1, DistrictId = 43 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hồng Trị", Sort = 1, DistrictId = 43 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kim Cúc", Sort = 1, DistrictId = 43 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phan Thanh", Sort = 1, DistrictId = 43 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hồng An", Sort = 1, DistrictId = 43 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hưng Đạo", Sort = 1, DistrictId = 43 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hưng Thịnh", Sort = 1, DistrictId = 43 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Huy Giáp", Sort = 1, DistrictId = 43 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đình Phùng", Sort = 1, DistrictId = 43 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sơn Lập", Sort = 1, DistrictId = 43 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sơn Lộ", Sort = 1, DistrictId = 43 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Thông Nông", Sort = 1, DistrictId = 44 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cần Yên", Sort = 1, DistrictId = 44 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cần Nông", Sort = 1, DistrictId = 44 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vị Quang", Sort = 1, DistrictId = 44 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lương Thông", Sort = 1, DistrictId = 44 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đa Thông", Sort = 1, DistrictId = 44 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngọc Động", Sort = 1, DistrictId = 44 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Sơn", Sort = 1, DistrictId = 44 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lương Can", Sort = 1, DistrictId = 44 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thanh Long", Sort = 1, DistrictId = 44 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bình Lãng", Sort = 1, DistrictId = 44 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Xuân Hòa", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lũng Nặm", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kéo Yên", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trường Hà", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vân An", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cải Viên", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nà Sác", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nội Thôn", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tổng Cọt", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sóc Hà", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thượng Thôn", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vần Dính", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hồng Sĩ", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sĩ Hai", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quý Quân", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Mã Ba", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phù Ngọc", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đào Ngạn", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hạ Thôn", Sort = 1, DistrictId = 45 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Hùng Quốc", Sort = 1, DistrictId = 46 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cô Mười", Sort = 1, DistrictId = 46 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tri Phương", Sort = 1, DistrictId = 46 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quang Hán", Sort = 1, DistrictId = 46 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quang Vinh", Sort = 1, DistrictId = 46 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xuân Nội", Sort = 1, DistrictId = 46 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quang Trung", Sort = 1, DistrictId = 46 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lưu Ngọc", Sort = 1, DistrictId = 46 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cao Chương", Sort = 1, DistrictId = 46 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quốc Toản", Sort = 1, DistrictId = 46 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Trùng Khánh", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngọc Khê", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngọc Côn", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phong Nậm", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngọc Chung", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đình Phong", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lăng Yên", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đàm Thuỷ", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Khâm Thành", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Chí Viễn", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lăng Hiếu", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phong Châu", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đình Minh", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cảnh Tiên", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trung Phúc", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cao Thăng", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đức Hồng", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thông Huề", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thân Giáp", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đoài Côn", Sort = 1, DistrictId = 47 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Minh Long", Sort = 1, DistrictId = 48 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lý Quốc", Sort = 1, DistrictId = 48 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thắng Lợi", Sort = 1, DistrictId = 48 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đồng Loan", Sort = 1, DistrictId = 48 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đức Quang", Sort = 1, DistrictId = 48 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kim Loan", Sort = 1, DistrictId = 48 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quang Long", Sort = 1, DistrictId = 48 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã An Lạc", Sort = 1, DistrictId = 48 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Thanh Nhật", Sort = 1, DistrictId = 48 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vinh Quý", Sort = 1, DistrictId = 48 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Việt Chu", Sort = 1, DistrictId = 48 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cô Ngân", Sort = 1, DistrictId = 48 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thái Đức", Sort = 1, DistrictId = 48 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thị Hoa", Sort = 1, DistrictId = 48 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Quảng Uyên", Sort = 1, DistrictId = 49 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phi Hải", Sort = 1, DistrictId = 49 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quảng Hưng", Sort = 1, DistrictId = 49 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bình Lăng", Sort = 1, DistrictId = 49 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quốc Dân", Sort = 1, DistrictId = 49 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quốc Phong", Sort = 1, DistrictId = 49 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Độc Lập", Sort = 1, DistrictId = 49 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cai Bộ", Sort = 1, DistrictId = 49 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đoài Khôn", Sort = 1, DistrictId = 49 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phúc Sen", Sort = 1, DistrictId = 49 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Chí Thảo", Sort = 1, DistrictId = 49 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tự Do", Sort = 1, DistrictId = 49 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hồng Định", Sort = 1, DistrictId = 49 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hồng Quang", Sort = 1, DistrictId = 49 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngọc Động", Sort = 1, DistrictId = 49 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hoàng Hải", Sort = 1, DistrictId = 49 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hạnh Phúc", Sort = 1, DistrictId = 49 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Tà Lùng", Sort = 1, DistrictId = 50 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Triệu ẩu", Sort = 1, DistrictId = 50 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hồng Đại", Sort = 1, DistrictId = 50 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cách Linh", Sort = 1, DistrictId = 50 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đại Sơn", Sort = 1, DistrictId = 50 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lương Thiện", Sort = 1, DistrictId = 50 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tiên Thành", Sort = 1, DistrictId = 50 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Hòa Thuận", Sort = 1, DistrictId = 50 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Mỹ Hưng", Sort = 1, DistrictId = 50 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Nước Hai", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Dân Chủ", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nam Tuấn", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đức Xuân", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đại Tiến", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đức Long", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngũ Lão", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trương Lương", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bình Long", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nguyễn Huệ", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Công Trừng", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hồng Việt", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bế Triều", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vĩnh Quang", Sort = 1, DistrictId = 40 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hoàng Tung", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trưng Vương", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quang Trung", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hưng Đạo", Sort = 1, DistrictId = 40 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bạch Đằng", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bình Dương", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lê Chung", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hà Trì", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Chu Trinh", Sort = 1, DistrictId = 40 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hồng Nam", Sort = 1, DistrictId = 51 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Nguyên Bình", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Tĩnh Túc", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Lạc", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Triệu Nguyên", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ca Thành", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thái Học", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vũ Nông", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Minh Tâm", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thể Dục", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bắc Hợp", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Mai Long", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lang Môn", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Minh Thanh", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hoa Thám", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phan Thanh", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quang Thành", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tam Kim", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thành Công", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thịnh Vượng", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hưng Đạo", Sort = 1, DistrictId = 52 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Đông Khê", Sort = 1, DistrictId = 53 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Canh Tân", Sort = 1, DistrictId = 53 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kim Đồng", Sort = 1, DistrictId = 53 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Minh Khai", Sort = 1, DistrictId = 53 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thị Ngân", Sort = 1, DistrictId = 53 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đức Thông", Sort = 1, DistrictId = 53 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thái Cường", Sort = 1, DistrictId = 53 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vân Trình", Sort = 1, DistrictId = 53 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thụy Hùng", Sort = 1, DistrictId = 53 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quang Trọng", Sort = 1, DistrictId = 53 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trọng Con", Sort = 1, DistrictId = 53 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lê Lai", Sort = 1, DistrictId = 53 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đức Long", Sort = 1, DistrictId = 53 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Danh Sỹ", Sort = 1, DistrictId = 53 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lê Lợi", Sort = 1, DistrictId = 53 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đức Xuân", Sort = 1, DistrictId = 53 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Nguyễn Thị Minh Khai", Sort = 1, DistrictId = 58 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Sông Cầu", Sort = 1, DistrictId = 58 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Đức Xuân", Sort = 1, DistrictId = 58 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phùng Chí Kiên", Sort = 1, DistrictId = 58 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Huyền Tụng", Sort = 1, DistrictId = 58 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Dương Quang", Sort = 1, DistrictId = 58 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nông Thượng", Sort = 1, DistrictId = 58 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Xuất Hóa", Sort = 1, DistrictId = 58 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bằng Thành", Sort = 1, DistrictId = 60 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nhạn Môn", Sort = 1, DistrictId = 60 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bộc Bố", Sort = 1, DistrictId = 60 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Công Bằng", Sort = 1, DistrictId = 60 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Giáo Hiệu", Sort = 1, DistrictId = 60 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xuân La", Sort = 1, DistrictId = 60 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã An Thắng", Sort = 1, DistrictId = 60 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cổ Linh", Sort = 1, DistrictId = 60 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nghiên Loan", Sort = 1, DistrictId = 60 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cao Tân", Sort = 1, DistrictId = 60 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Chợ Rã", Sort = 1, DistrictId = 61 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bành Trạch", Sort = 1, DistrictId = 61 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phúc Lộc", Sort = 1, DistrictId = 61 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hà Hiệu", Sort = 1, DistrictId = 61 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cao Thượng", Sort = 1, DistrictId = 61 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cao Trĩ", Sort = 1, DistrictId = 61 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Khang Ninh", Sort = 1, DistrictId = 61 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nam Mẫu", Sort = 1, DistrictId = 61 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thượng Giáo", Sort = 1, DistrictId = 61 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Địa Linh", Sort = 1, DistrictId = 61 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yến Dương", Sort = 1, DistrictId = 61 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Chu Hương", Sort = 1, DistrictId = 61 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quảng Khê", Sort = 1, DistrictId = 61 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Mỹ Phương", Sort = 1, DistrictId = 61 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hoàng Trĩ", Sort = 1, DistrictId = 61 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đồng Phúc", Sort = 1, DistrictId = 61 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Nà Phặc", Sort = 1, DistrictId = 62 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thượng Ân", Sort = 1, DistrictId = 62 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bằng Vân", Sort = 1, DistrictId = 62 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cốc Đán", Sort = 1, DistrictId = 62 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trung Hòa", Sort = 1, DistrictId = 62 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đức Vân", Sort = 1, DistrictId = 62 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vân Tùng", Sort = 1, DistrictId = 62 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thượng Quan", Sort = 1, DistrictId = 62 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lãng Ngâm", Sort = 1, DistrictId = 62 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thuần Mang", Sort = 1, DistrictId = 62 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hương Nê", Sort = 1, DistrictId = 62 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Phủ Thông", Sort = 1, DistrictId = 63 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phương Linh", Sort = 1, DistrictId = 63 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vi Hương", Sort = 1, DistrictId = 63 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sỹ Bình", Sort = 1, DistrictId = 63 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vũ Muộn", Sort = 1, DistrictId = 63 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đôn Phong", Sort = 1, DistrictId = 63 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tú Trĩ", Sort = 1, DistrictId = 63 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lục Bình", Sort = 1, DistrictId = 63 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Tiến", Sort = 1, DistrictId = 63 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quân Bình", Sort = 1, DistrictId = 63 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nguyên Phúc", Sort = 1, DistrictId = 63 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cao Sơn", Sort = 1, DistrictId = 63 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hà Vị", Sort = 1, DistrictId = 63 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cẩm Giàng", Sort = 1, DistrictId = 63 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Mỹ Thanh", Sort = 1, DistrictId = 63 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Dương Phong", Sort = 1, DistrictId = 63 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quang Thuận", Sort = 1, DistrictId = 63 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Bằng Lũng", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xuân Lạc", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nam Cường", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đồng Lạc", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Lập", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Thi", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quảng Bạch", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bằng Phúc", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Thịnh", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Thượng", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phương Viên", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngọc Phái", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Rã Bản", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đông Viên", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lương Bằng", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bằng Lãng", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đại Sảo", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nghĩa Tá", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phong Huân", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Mỹ", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bình Trung", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Nhuận", Sort = 1, DistrictId = 64 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Chợ Mới", Sort = 1, DistrictId = 65 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Sơn", Sort = 1, DistrictId = 65 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thanh Vận", Sort = 1, DistrictId = 65 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Mai Lạp", Sort = 1, DistrictId = 65 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hòa Mục", Sort = 1, DistrictId = 65 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thanh Mai", Sort = 1, DistrictId = 65 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cao Kỳ", Sort = 1, DistrictId = 65 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nông Hạ", Sort = 1, DistrictId = 65 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Cư", Sort = 1, DistrictId = 65 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nông Thịnh", Sort = 1, DistrictId = 65 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Hân", Sort = 1, DistrictId = 65 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thanh Bình", Sort = 1, DistrictId = 65 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Như Cố", Sort = 1, DistrictId = 65 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bình Văn", Sort = 1, DistrictId = 65 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Đĩnh", Sort = 1, DistrictId = 65 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quảng Chu", Sort = 1, DistrictId = 65 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Yến Lạc", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vũ Loan", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lạng San", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lương Thượng", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kim Hỷ", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Văn Học", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cường Lợi", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lương Hạ", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kim Lư", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lương Thành", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ân Tình", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lam Sơn", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Văn Minh", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Côn Minh", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cư Lễ", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hữu Thác", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hảo Nghĩa", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quang Phong", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Dương Sơn", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xuân Dương", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đổng Xá", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Liêm Thuỷ", Sort = 1, DistrictId = 66 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phan Thiết", Sort = 1, DistrictId = 70 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Minh Xuân", Sort = 1, DistrictId = 70 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Tân Quang", Sort = 1, DistrictId = 70 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tràng Đà", Sort = 1, DistrictId = 70 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Nông Tiến", Sort = 1, DistrictId = 70 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Ỷ La", Sort = 1, DistrictId = 70 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Tân Hà", Sort = 1, DistrictId = 70 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Hưng Thành", Sort = 1, DistrictId = 70 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Na Hang", Sort = 1, DistrictId = 72 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sinh Long", Sort = 1, DistrictId = 72 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thượng Giáp", Sort = 1, DistrictId = 72 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phúc Yên", Sort = 1, DistrictId = 71 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thượng Nông", Sort = 1, DistrictId = 72 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xuân Lập", Sort = 1, DistrictId = 71 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Côn Lôn", Sort = 1, DistrictId = 72 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Hoa", Sort = 1, DistrictId = 72 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Khuôn Hà", Sort = 1, DistrictId = 71 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hồng Thái", Sort = 1, DistrictId = 72 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đà Vị", Sort = 1, DistrictId = 72 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Khau Tinh", Sort = 1, DistrictId = 72 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lăng Can", Sort = 1, DistrictId = 71 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thượng Lâm", Sort = 1, DistrictId = 71 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sơn Phú", Sort = 1, DistrictId = 72 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Năng Khả", Sort = 1, DistrictId = 72 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thanh Tương", Sort = 1, DistrictId = 72 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Vĩnh Lộc", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bình An", Sort = 1, DistrictId = 71 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hồng Quang", Sort = 1, DistrictId = 71 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thổ Bình", Sort = 1, DistrictId = 71 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phúc Sơn", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Minh Quang", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trung Hà", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Mỹ", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hà Lang", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hùng Mỹ", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Lập", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân An", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bình Phú", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xuân Quang", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngọc Hội", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phú Bình", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hòa Phú", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phúc Thịnh", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kiên Đài", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Thịnh", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trung Hòa", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kim Bình", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hòa An", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vinh Quang", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tri Phú", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nhân Lý", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Nguyên", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Linh Phú", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bình Nhân", Sort = 1, DistrictId = 73 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Tân Yên", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Thuận", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bạch Xa", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Minh Khương", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Lâm", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Minh Dân", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phù Lưu", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Minh Hương", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Yên Phú", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Thành", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bình Xa", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thái Sơn", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nhân Mục", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thành Long", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bằng Cốc", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thái Hòa", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đức Ninh", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hùng Đức", Sort = 1, DistrictId = 74 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Tân Bình", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quí Quân", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lực Hành", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kiến Thiết", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trung Minh", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Chiêu Yên", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trung Trực", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xuân Vân", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phúc Ninh", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hùng Lợi", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trung Sơn", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Tiến", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tứ Quận", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đạo Viện", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Long", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thắng Quân", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kim Quan", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lang Quán", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phú Thịnh", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Công Đa", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trung Môn", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Chân Sơn", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thái Bình", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kim Phú", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tiến Bộ", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã An Khang", Sort = 1, DistrictId = 70 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Mỹ Bằng", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phú Lâm", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã An Tường", Sort = 1, DistrictId = 70 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lưỡng Vượng", Sort = 1, DistrictId = 70 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hoàng Khai", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thái Long", Sort = 1, DistrictId = 70 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đội Cấn", Sort = 1, DistrictId = 70 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nhữ Hán", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nhữ Khê", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đội Bình", Sort = 1, DistrictId = 75 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Sơn Dương", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trung Yên", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Minh Thanh", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tân Trào", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vĩnh Lợi", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thượng Ấm", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bình Yên", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lương Thiện", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tú Thịnh", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cấp Tiến", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hợp Thành", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phúc Ứng", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đông Thọ", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Kháng Nhật", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hợp Hòa", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thanh Phát", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quyết Thắng", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đồng Quý", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tuân Lộ", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vân Sơn", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Văn Phú", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Chi Thiết", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đông Lợi", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thiện Kế", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hồng Lạc", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phú Lương", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ninh Lai", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đại Phú", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sơn Nam", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hào Phú", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tam Đa", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sầm Dương", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lâm Xuyên", Sort = 1, DistrictId = 76 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Duyên Hải", Sort = 1, DistrictId = 80 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Lào Cai", Sort = 1, DistrictId = 80 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Phố Mới", Sort = 1, DistrictId = 80 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Cốc Lếu", Sort = 1, DistrictId = 80 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Kim Tân", Sort = 1, DistrictId = 80 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Bắc Lệnh", Sort = 1, DistrictId = 80 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Pom Hán", Sort = 1, DistrictId = 80 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Xuân Tăng", Sort = 1, DistrictId = 80 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Bình Minh", Sort = 1, DistrictId = 80 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Thống Nhất", Sort = 1, DistrictId = 80 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Đồng Tuyển", Sort = 1, DistrictId = 80 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Vạn Hòa", Sort = 1, DistrictId = 80 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Bắc Cường", Sort = 1, DistrictId = 80 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Phường Nam Cường", Sort = 1, DistrictId = 80 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cam Đường", Sort = 1, DistrictId = 80 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tả Phời", Sort = 1, DistrictId = 80 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hợp Thành", Sort = 1, DistrictId = 80 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Bát Xát", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã A Mú Sung", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nậm Chạc", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã A Lù", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trịnh Tường", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Ngải Thầu", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Y Tý", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cốc Mỳ", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Dền Sáng", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Vược", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sàng Ma Sáo", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Qua", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Mường Vi", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Dền Thàng", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Xèo", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Mường Hum", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trung Lèng Hồ", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quang Kim", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Pa Cheo", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nậm Pung", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phìn Ngan", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cốc San", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tòng Sành", Sort = 1, DistrictId = 82 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Pha Long", Sort = 1, DistrictId = 83 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tả Ngải Chồ", Sort = 1, DistrictId = 83 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tung Chung Phố", Sort = 1, DistrictId = 83 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Mường Khương", Sort = 1, DistrictId = 83 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Dìn Chin", Sort = 1, DistrictId = 83 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tả Gia Khâu", Sort = 1, DistrictId = 83 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nậm Chảy", Sort = 1, DistrictId = 83 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nấm Lư", Sort = 1, DistrictId = 83 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lùng Khấu Nhin", Sort = 1, DistrictId = 83 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thanh Bình", Sort = 1, DistrictId = 83 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cao Sơn", Sort = 1, DistrictId = 83 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lùng Vai", Sort = 1, DistrictId = 83 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Lầu", Sort = 1, DistrictId = 83 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã La Pan Tẩn", Sort = 1, DistrictId = 83 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tả Thàng", Sort = 1, DistrictId = 83 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Sen", Sort = 1, DistrictId = 83 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nàn Sán", Sort = 1, DistrictId = 84 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thào Chư Phìn", Sort = 1, DistrictId = 84 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Mế", Sort = 1, DistrictId = 84 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Si Ma Cai", Sort = 1, DistrictId = 84 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sán Chải", Sort = 1, DistrictId = 84 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Mản Thẩn", Sort = 1, DistrictId = 84 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lùng Sui", Sort = 1, DistrictId = 84 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cán Cấu", Sort = 1, DistrictId = 84 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sín Chéng", Sort = 1, DistrictId = 84 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cán Hồ", Sort = 1, DistrictId = 84 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Quan Thần Sán", Sort = 1, DistrictId = 84 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lử Thẩn", Sort = 1, DistrictId = 84 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nàn Xín", Sort = 1, DistrictId = 84 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Bắc Hà", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lùng Cải", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Già", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lùng Phình", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tả Van Chư", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tả Củ Tỷ", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thải Giàng Phố", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Lầu Thí Ngài", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Hoàng Thu Phố", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Phố", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Liền", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Tà Chải", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Na Hối", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cốc Ly", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nậm Mòn", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nậm Đét", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nậm Khánh", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bảo Nhai", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Nậm Lúc", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Cốc Lầu", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Cái", Sort = 1, DistrictId = 85 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn N.T Phong Hải", Sort = 1, DistrictId = 86 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Phố Lu", Sort = 1, DistrictId = 86 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Thị trấn Tằng Loỏng", Sort = 1, DistrictId = 86 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Phiệt", Sort = 1, DistrictId = 86 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Bản Cầm", Sort = 1, DistrictId = 86 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Thái Niên", Sort = 1, DistrictId = 86 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phong Niên", Sort = 1, DistrictId = 86 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Gia Phú", Sort = 1, DistrictId = 86 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xuân Quang", Sort = 1, DistrictId = 86 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sơn Hải", Sort = 1, DistrictId = 86 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Xuân Giao", Sort = 1, DistrictId = 86 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Trì Quang", Sort = 1, DistrictId = 86 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Sơn Hà", Sort = 1, DistrictId = 86 });
            //modelBuilder.Entity<Ward>().HasData(new Ward { Name = "Xã Phố Lu", Sort = 1, DistrictId = 86 });

            //#endregion

            //#region OrderStatus
            //modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus { Name = "Chờ duyệt", Desription = "Đơn hàng vừa được tạo mới và chờ quản lý duyệt!" });
            //modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus { Name = "Đã duyệt", Desription = "Đơn hàng đã được quản lý duyệt!" });
            //modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus { Name = "Đang vận chuyển", Desription = "Đơn hàng đang được vận chuyển đến người mua!" });
            //modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus { Name = "Đã thanh toán và chờ giao hàng", Desription = "Đơn hàng đã được trả tiền qua các phương thức giao dịch và đang chờ nhận hàng!" });
            //modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus { Name = "Đã giao hàng", Desription = "Đơn hàng đã giao xong và thu tiền của khách nhưng chưa đem về cho quản lý!" });
            //modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus { Name = "Hoàn thành", Desription = "Đơn hàng đã giao xong và quản lý đã cầm được tiền!" });
            //modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus { Name = "Hủy", Desription = "Đơn hàng đã bị hủy!" });
            //modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus { Name = "Trả lại", Desription = "Ví lý do gì đó mà đơn hàng đã bị trả lại!" });
            //#endregion

            //#region ProductStatus
            //modelBuilder.Entity<ProductStatus>().HasData(new ProductStatus { Name = "Bình thường", Desription = "Hàng đã ở cửa hàng lâu năm và ổn định!" });
            //modelBuilder.Entity<ProductStatus>().HasData(new ProductStatus { Name = "Mới", Desription = "Hàng mới nhập!" });
            //modelBuilder.Entity<ProductStatus>().HasData(new ProductStatus { Name = "Bán chạy", Desription = "Hàng đang bán chạy!" });
            //modelBuilder.Entity<ProductStatus>().HasData(new ProductStatus { Name = "Giảm giá", Desription = "Hàng đang giảm giá!" });
            //modelBuilder.Entity<ProductStatus>().HasData(new ProductStatus { Name = "Seccond Hand", Desription = "Hàng đã qua sử dụng!" });
            //modelBuilder.Entity<ProductStatus>().HasData(new ProductStatus { Name = "Phiên bản đặc biệt", Desription = "Phiên bản đặc biệt!" });
            //modelBuilder.Entity<ProductStatus>().HasData(new ProductStatus { Name = "Phiên bản giới hạn", Desription = "Phiên bản giới hạn!" });
            //#endregion

            //#region Band
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "Thép không rỉ (Inox)" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "Titanium" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "Xi" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "Da" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "Da vân nguyên bản" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "Dây da giả da cá sấu" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "Dây da giả vân" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "Dây da giả da" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "Nato" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "Vải" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "Nhựa" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "Cao su" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "Đá" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "gốm" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "ceramic" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "OYSTER" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "JUBILEE" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "PRESIDENT" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "MILANESE" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "BEADS OF RICE" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "ROYAL OAK" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "BONKLIP" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "Twist-O-Flex" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "H-link" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "Shark Mesh" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "Engineer" });
            //modelBuilder.Entity<Band>().HasData(new Band { Name = "Ladder" });
            //#endregion

            //#region BrandProduct
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Patek Philippe" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Tag Heuer" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Rolex Swiss Made" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Omega" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Longines" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Tissot" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Timex" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Calvin Klein" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Movado" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "SEIKO" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Citizen" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Orient" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Casio" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Fossil" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Michael Kors" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Ogival" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "OP: Olympia Star, Olym Pianus" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "DW (Daniel Wellington)" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Anne Klein" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Guess" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Breitling" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Piaget" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Breguet" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Zenith" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Vacheron Constantin" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Audemars Piguet" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Hublot" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Jaguar" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Mido" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Candino" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Rado Switzerland" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Swatch" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Century" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Certina" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Roamer" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Perrelet" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Chronoswiss" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "Frederique Constant (FC)" });
            //modelBuilder.Entity<BrandProduct>().HasData(new BrandProduct { Name = "IWC" });
            //#endregion

            //#region ColorClockFace
            //modelBuilder.Entity<ColorClockFace>().HasData(new ColorClockFace { Name = "Sapphire (Kính Chống Trầy)" });
            //#endregion

            //#region Function
            //modelBuilder.Entity<Function>().HasData(new Function { Name = "Lịch ngày" });
            //modelBuilder.Entity<Function>().HasData(new Function { Name = "Lịch ngày giờ" });
            //#endregion

            //#region Machine
            //modelBuilder.Entity<Machine>().HasData(new Machine { Name = "Automatic (Tự động)" });
            //modelBuilder.Entity<Machine>().HasData(new Machine { Name = "Máy cơ" });
            //#endregion

            //#region MadeIn
            //modelBuilder.Entity<MadeIn>().HasData(new MadeIn { Name = "Thụy sỹ" });
            //modelBuilder.Entity<MadeIn>().HasData(new MadeIn { Name = "Việt nam" });
            //#endregion

            //#region Strap
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "Thép không rỉ (Inox)" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "Titanium" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "Xi" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "Da" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "Da vân nguyên bản" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "Dây da giả da cá sấu" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "Dây da giả vân" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "Dây da giả da" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "Nato" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "Vải" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "Nhựa" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "Cao su" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "Đá" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "gốm" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "ceramic" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "OYSTER" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "JUBILEE" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "PRESIDENT" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "MILANESE" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "BEADS OF RICE" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "ROYAL OAK" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "BONKLIP" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "Twist-O-Flex" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "H-link" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "Shark Mesh" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "Engineer" });
            //modelBuilder.Entity<Strap>().HasData(new Strap { Name = "Ladder" });
            //#endregion

            //#region Style
            //modelBuilder.Entity<Style>().HasData(new Style { Name = "Lịch lãm" });
            //modelBuilder.Entity<Style>().HasData(new Style { Name = "Trẻ trung" });
            //modelBuilder.Entity<Style>().HasData(new Style { Name = "Quý phái" });
            //modelBuilder.Entity<Style>().HasData(new Style { Name = "Năng động" });
            //#endregion

            //#region Waterproof
            //modelBuilder.Entity<Waterproof>().HasData(new Waterproof { Name = "30m/3 ATM/3 Bar" });
            //modelBuilder.Entity<Waterproof>().HasData(new Waterproof { Name = "50m/5 ATM/5 Bar:" });
            //modelBuilder.Entity<Waterproof>().HasData(new Waterproof { Name = "100m/10 ATM/10 Bar:" });
            //modelBuilder.Entity<Waterproof>().HasData(new Waterproof { Name = "200m/20 ATM/20 Bar" });
            //modelBuilder.Entity<Waterproof>().HasData(new Waterproof { Name = "770m/77 ATM/77 Bar" });
            //modelBuilder.Entity<Waterproof>().HasData(new Waterproof { Name = "1000m/100 ATM/100 Bar" });
            //modelBuilder.Entity<Waterproof>().HasData(new Waterproof { Name = "2000m/200 ATM/200 Bar" });
            //#endregion
            #endregion
        }
    }
}
