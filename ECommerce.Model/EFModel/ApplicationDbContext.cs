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
      

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<BrandProduct> BrandProduct { get; set; }
        public virtual DbSet<Chatelaine> Chatelaine { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ColorClockFace> ColorClockFace { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Hem> Hem { get; set; }
        public virtual DbSet<HuntingCase> HuntingCase { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Machine> Machine { get; set; }
        public virtual DbSet<MadeIn> MadeIn { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Origin> Origin { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Ward> Ward { get; set; }
    }
}
