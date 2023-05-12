using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OpticartWebAPI.Models;

public partial class OptiCartDbContext : DbContext
{
    public OptiCartDbContext()
    {
    }

    public OptiCartDbContext(DbContextOptions<OptiCartDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoryTbl> CategoryTbls { get; set; }

    public virtual DbSet<CustomerTbl> CustomerTbls { get; set; }

    public virtual DbSet<FeedbackTbl> FeedbackTbls { get; set; }

    public virtual DbSet<OrderDetailsTbl> OrderDetailsTbls { get; set; }

    public virtual DbSet<OrdersTbl> OrdersTbls { get; set; }

    public virtual DbSet<PaymentTbl> PaymentTbls { get; set; }

    public virtual DbSet<ProductTbl> ProductTbls { get; set; }

    public virtual DbSet<ShipperTbl> ShipperTbls { get; set; }

    public virtual DbSet<VendorTbl> VendorTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-N8DJERI\\SQLEXPRESS;Initial Catalog=OptiCartDB;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryTbl>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.ToTable("CategoryTbl");

            entity.Property(e => e.ActiveStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Categoryname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CustomerTbl>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("CustomerTbl");

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.CustomerFname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customerFname");
            entity.Property(e => e.CustomerLname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customerLname");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Pincode).HasColumnName("pincode");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("state");
        });

        modelBuilder.Entity<FeedbackTbl>(entity =>
        {
            entity.HasKey(e => e.FdId);

            entity.ToTable("FeedbackTbl");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.FeedbackTitle).HasColumnType("text");

            entity.HasOne(d => d.Catgory).WithMany(p => p.FeedbackTbls)
                .HasForeignKey(d => d.CatgoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FeedbackTbl_CategoryTbl");

            entity.HasOne(d => d.Customer).WithMany(p => p.FeedbackTbls)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FeedbackTbl_CustomerTbl");

            entity.HasOne(d => d.Product).WithMany(p => p.FeedbackTbls)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FeedbackTbl_ProductTbl");
        });

        modelBuilder.Entity<OrderDetailsTbl>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId);

            entity.ToTable("OrderDetailsTbl");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetailsTbls)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetailsTbl_OrdersTbl");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetailsTbls)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetailsTbl_ProductTbl");
        });

        modelBuilder.Entity<OrdersTbl>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("OrdersTbl");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrdersTbls)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdersTbl_CustomerTbl");

            entity.HasOne(d => d.Payment).WithMany(p => p.OrdersTbls)
                .HasForeignKey(d => d.Paymentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdersTbl_PaymentTbl");

            entity.HasOne(d => d.Product).WithMany(p => p.OrdersTbls)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdersTbl_ProductTbl");
        });

        modelBuilder.Entity<PaymentTbl>(entity =>
        {
            entity.HasKey(e => e.PaymentId);

            entity.ToTable("PaymentTbl");

            entity.Property(e => e.Allowed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductTbl>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("ProductTbl");

            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductImage)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Product_Image");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quantity)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Category).WithMany(p => p.ProductTbls)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductTbl_CategoryTbl");

            entity.HasOne(d => d.Vendor).WithMany(p => p.ProductTbls)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductTbl_VendorTbl");
        });

        modelBuilder.Entity<ShipperTbl>(entity =>
        {
            entity.HasKey(e => e.ShipperId);

            entity.ToTable("ShipperTbl");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VendorTbl>(entity =>
        {
            entity.HasKey(e => e.VendorId);

            entity.ToTable("VendorTbl");

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.GoodsType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pin).HasColumnName("pin");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
