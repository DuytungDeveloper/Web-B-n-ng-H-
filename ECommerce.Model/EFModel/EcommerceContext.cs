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

        public virtual DbSet<Product> Product { get; set; }

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
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DiscountPrice).HasColumnName("discountPrice");

                entity.Property(e => e.Images)
                    .HasColumnName("images")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MetaTags)
                    .HasColumnName("metaTags")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasColumnName("productCode")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SalePrice).HasColumnName("salePrice");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Video)
                    .HasColumnName("video")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
