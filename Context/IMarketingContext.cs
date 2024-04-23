using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TiendaIMark.Models;

public partial class IMarketingContext : DbContext
{
    public IMarketingContext()
    {
    }

    public IMarketingContext(DbContextOptions<IMarketingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__Categori__CD54BC5A0FB34082");

            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.IdImages).HasName("PK__Imagenes__3DAC04382BFEB99D");

            entity.Property(e => e.IdImages).HasColumnName("id_images");
            entity.Property(e => e.Url1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("url_1");
            entity.Property(e => e.Url2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("url_2");
            entity.Property(e => e.Url3)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("url_3");
            entity.Property(e => e.Url4)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("url_4");
            entity.Property(e => e.Url5)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("url_5");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__Producto__FF341C0D96B208AD");

            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Brand)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("brand");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdImages).HasColumnName("id_images");
            entity.Property(e => e.IsNew).HasColumnName("is_new");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK__Productos__id_ca__5DCAEF64");

            entity.HasOne(d => d.IdImagesNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdImages)
                .HasConstraintName("FK__Productos__id_im__5CD6CB2B");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdSale).HasName("PK__Ventas__459533BF1ADDB711");

            entity.Property(e => e.IdSale).HasColumnName("id_sale");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdSeller).HasColumnName("id_seller");
            entity.Property(e => e.QuantitySold).HasColumnName("quantity_sold");
            entity.Property(e => e.SaleAmount)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("sale_amount");
            entity.Property(e => e.SaleDate)
                .HasColumnType("date")
                .HasColumnName("sale_date");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK__Ventas__id_produ__72C60C4A");

            entity.HasOne(d => d.IdSellerNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdSeller)
                .HasConstraintName("FK__Ventas__id_vende__71D1E811");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.IdSeller).HasName("PK__Vendedor__0093030853DB2F76");

            entity.Property(e => e.IdSeller).HasColumnName("id_seller");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("department");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IsGoodAssessment).HasColumnName("is_good_assessment");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
