using System;
using System.Collections.Generic;
using FrontendMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FrontendMVC.Data;

public partial class MasterPolContext : DbContext
{
    public MasterPolContext()
    {
    }

    public MasterPolContext(DbContextOptions<MasterPolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerDirector> PartnerDirectors { get; set; }

    public virtual DbSet<PartnerProduct> PartnerProducts { get; set; }

    public virtual DbSet<PartnerType> PartnerTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.IdPartner).HasName("PRIMARY");

            entity.ToTable("Partner");

            entity.HasIndex(e => e.IdPartnerDirector, "fk_partner_partner_director1_idx");

            entity.HasIndex(e => e.IdPartnerType, "fk_partner_partner_type_idx");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Address).HasMaxLength(125);
            entity.Property(e => e.Inn)
                .HasMaxLength(45)
                .HasColumnName("INN");

            entity.HasOne(d => d.IdPartnerDirectorNavigation).WithMany(p => p.Partners)
                .HasForeignKey(d => d.IdPartnerDirector)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_partner_partner_director1");

            entity.HasOne(d => d.IdPartnerTypeNavigation).WithMany(p => p.Partners)
                .HasForeignKey(d => d.IdPartnerType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_partner_partner_type");
        });

        modelBuilder.Entity<PartnerDirector>(entity =>
        {
            entity.HasKey(e => e.IdPartnerDirector).HasName("PRIMARY");

            entity.ToTable("PartnerDirector");

            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.FirstName).HasMaxLength(45);
            entity.Property(e => e.Patronymic).HasMaxLength(45);
            entity.Property(e => e.PhoneNumber).HasMaxLength(11);
            entity.Property(e => e.Surname).HasMaxLength(45);
        });

        modelBuilder.Entity<PartnerProduct>(entity =>
        {
            entity.HasKey(e => e.IdPartnerProduct).HasName("PRIMARY");

            entity.ToTable("PartnerProduct");

            entity.HasIndex(e => e.IdPartner, "fk_PartnerProduct_Partner1_idx");

            entity.HasIndex(e => e.IdProduct, "fk_PartnerProduct_Product1_idx");

            entity.Property(e => e.OrderDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdPartnerNavigation).WithMany(e => e.OrderedProducts)
                .HasForeignKey(d => d.IdPartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_PartnerProduct_Partner1");

            entity.HasOne(d => d.IdProductNavigation).WithMany(e => e.OrderedProducts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_PartnerProduct_Product1");
        });

        modelBuilder.Entity<PartnerType>(entity =>
        {
            entity.HasKey(e => e.IdPartnerType).HasName("PRIMARY");

            entity.ToTable("PartnerType");

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PRIMARY");

            entity.ToTable("Product");

            entity.HasIndex(e => e.IdProductType, "fk_Product_ProductType1_idx");

            entity.Property(e => e.MinimalPrice).HasPrecision(7);
            entity.Property(e => e.Name).HasMaxLength(45);

            entity.HasOne(d => d.IdProductTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProductType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Product_ProductType1");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.IdProductType).HasName("PRIMARY");

            entity.ToTable("ProductType");

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
