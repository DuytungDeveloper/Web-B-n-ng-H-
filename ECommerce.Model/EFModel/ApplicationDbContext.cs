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

            #endregion


        }
    }
}
