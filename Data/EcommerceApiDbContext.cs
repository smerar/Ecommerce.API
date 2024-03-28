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

    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    {
          // => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EcommerceApiDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;");

    }
     

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

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC074B80C6A4");

            entity.ToTable("Category");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
