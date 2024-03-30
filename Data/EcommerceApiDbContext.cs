using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Data;

public partial class EcommerceApiDbContext : DbContext
{
    public EcommerceApiDbContext()
    {
    }

    public EcommerceApiDbContext(DbContextOptions<EcommerceApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminInfo> AdminInfos { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }

    public virtual DbSet<EcommerceUser> EcommerceUsers { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ShippingAddress> ShippingAddresses { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminInfo>(entity =>
        {
            entity.ToTable("AdminInfo");

            entity.Property(e => e.CreatedOn).HasMaxLength(25);
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.LastLogin).HasMaxLength(25);
            entity.Property(e => e.Name).HasMaxLength(10);
            entity.Property(e => e.Password).HasMaxLength(6);
            entity.Property(e => e.UpdatedOn).HasMaxLength(25);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__415B03B8348A4BC1");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId).HasColumnName("cartId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC074B80C6A4");

            entity.ToTable("Category");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CustomerOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07B3BBA29D");

            entity.ToTable("CustomerOrder");

            entity.Property(e => e.CreatedOn).HasMaxLength(25);
            entity.Property(e => e.OrderId).HasMaxLength(9);
            entity.Property(e => e.PaymentMode).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasMaxLength(25);

            entity.HasOne(d => d.Address).WithMany(p => p.CustomerOrders)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__CustomerO__Addre__787EE5A0");
        });

        modelBuilder.Entity<EcommerceUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Ecommerc__CB9A1CFFEDE90065");

            entity.ToTable("EcommerceUser");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC071BBC9FE2");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.CreatedOn).HasMaxLength(25);
            entity.Property(e => e.OrderId)
                .IsRequired()
                .HasMaxLength(9);
            entity.Property(e => e.UpdatedOn).HasMaxLength(25);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC071A31438C");

            entity.ToTable("Product");

            entity.Property(e => e.ImageUrl)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProDesc)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ShippingCharges).HasColumnName("shippingCharges");
        });

        modelBuilder.Entity<ShippingAddress>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__shipping__26A111AD119CF470");

            entity.ToTable("shippingAddress");

            entity.Property(e => e.AddressId).HasColumnName("addressId");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Aptno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("aptno");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("customerName");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Pincode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("pincode");
            entity.Property(e => e.Province)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("province");
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("street");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.ShippingAddresses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__shippingA__activ__73BA3083");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
