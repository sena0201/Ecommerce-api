using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api.Entity;

/*public partial class EcommerceDbContext : DbContext
{
    public EcommerceDbContext()
    {
    }

    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }


    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-9DKJTTRL\\SQLEXPRESS;Initial Catalog=EcommerceDB;Persist Security Info=True;User ID=sa;Password=123;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.ColorId)
                .HasMaxLength(50)
                .HasColumnName("ColorID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .HasColumnName("ProductID");
            entity.Property(e => e.SizeId)
                .HasMaxLength(50)
                .HasColumnName("SizeID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Carts_Products");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carts_Users");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Categories)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Categories_Suppliers");
        });



        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Orders_Users");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.Property(e => e.OrderDetailId)
                .HasMaxLength(50)
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.ColorId)
                .HasMaxLength(50)
                .HasColumnName("ColorID");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("OrderID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .HasColumnName("ProductID");
            entity.Property(e => e.SizeId)
                .HasMaxLength(50)
                .HasColumnName("SizeID");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderDetails_Products");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.Property(e => e.PhotoId)
                .HasMaxLength(50)
                .HasColumnName("PhotoID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .HasColumnName("ProductID");
            entity.Property(e => e.Url).HasMaxLength(250);

            entity.HasOne(d => d.Product).WithMany(p => p.Photos)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Photos_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Price).HasMaxLength(50);
            entity.Property(e => e.ProductName).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_Categories");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.SizeId).HasName("PK_Sizes_1");

            entity.Property(e => e.SizeId)
                .HasMaxLength(50)
                .HasColumnName("SizeID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .HasColumnName("ProductID");
            entity.Property(e => e.Size1)
                .HasMaxLength(50)
                .HasColumnName("Size");

            entity.HasOne(d => d.Product).WithMany(p => p.Sizes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sizes_Products");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => new { e.StatusId, e.OrderId });

            entity.ToTable("Status");

            entity.Property(e => e.StatusId)
                .ValueGeneratedOnAdd()
                .HasColumnName("StatusID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Description).HasMaxLength(50);

            entity.HasOne(d => d.Order).WithMany(p => p.Statuses)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Status_Orders");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Hotline).HasMaxLength(50);
            entity.Property(e => e.SupplierName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Photo).HasMaxLength(250);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}*/
