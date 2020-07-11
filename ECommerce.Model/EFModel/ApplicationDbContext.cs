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
    public class ApplicationDbContext: ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
               DbContextOptions options,
               IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<BrandProduct> BrandProducts { get; set; }
        public virtual DbSet<Chatelaine> Chatelaines { get; set; }
        public virtual DbSet<City> Citys { get; set; }
        public virtual DbSet<ColorClockFace> ColorClockFaces { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Hem> Hems { get; set; }
        public virtual DbSet<HuntingCase> HuntingCases { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<MadeIn> MadeIns { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Origin> Origins { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
