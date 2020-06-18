using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ECommerce.Model.EFModel
{
    public partial class EcommerceContext : DbContext
    {
        public EcommerceContext()
        {
        }

        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options)
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
        public virtual DbSet<RoleClaims> RoleClaims { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<UserClaims> UserClaims { get; set; }
        public virtual DbSet<UserLogins> UserLogins { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<UserTokens> UserTokens { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Ward> Ward { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=DESKTOP-9BBIEQA;Database=Ecommerce;User Id=sa;Password=0306141044");
                #region NghiaTV Edit config
                EcommerceContext _context = new EcommerceContext();
                optionsBuilder.UseSqlServer(_context.Database.GetDbConnection().ConnectionString);
                #endregion

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<BrandProduct>(entity =>
            {
                entity.ToTable("Brand_Product");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<ColorClockFace>(entity =>
            {
                entity.ToTable("Color_Clock_Face");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Hobby).HasMaxLength(255);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<HuntingCase>(entity =>
            {
                entity.ToTable("Hunting_Case");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("Order_Status");

                entity.Property(e => e.Desription).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdOrderStatus).HasColumnName("IdOrder_Status");

                entity.Property(e => e.Note).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(30);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.DescriptionFull).HasColumnName("Description_Full");

                entity.Property(e => e.DescriptionShort).HasColumnName("Description_short");

                entity.Property(e => e.IdBrandProduct).HasColumnName("IdBrand_Product");

                entity.Property(e => e.IdColorClockFace).HasColumnName("IdColor_Clock_Face");

                entity.Property(e => e.IdHuntingCase).HasColumnName("IdHunting_Case");
            });

            modelBuilder.Entity<RoleClaims>(entity =>
            {
                entity.Property(e => e.RoleId).HasMaxLength(450);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<UserClaims>(entity =>
            {
                entity.Property(e => e.UserId).HasMaxLength(450);
            });

            modelBuilder.Entity<UserLogins>(entity =>
            {
                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(450);
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.Property(e => e.RoleId).HasMaxLength(450);

                entity.Property(e => e.UserId).HasMaxLength(450);
            });

            modelBuilder.Entity<UserTokens>(entity =>
            {
                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(450);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
