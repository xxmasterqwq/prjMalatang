using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prjMalatang.Models;

public partial class OrderdbContext : DbContext
{
    public OrderdbContext()
    {
    }

    public OrderdbContext(DbContextOptions<OrderdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Flavor> Flavors { get; set; }

    public virtual DbSet<Ingridient> Ingridients { get; set; }

    public virtual DbSet<IngridientCategory> IngridientCategories { get; set; }

    public virtual DbSet<Malatang> Malatangs { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=orderdb;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_customer");

            entity.ToTable("customers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Point).HasColumnName("point");
            entity.Property(e => e.Suspension).HasColumnName("suspension");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.DiscountCodeId);

            entity.ToTable("discount");

            entity.Property(e => e.DiscountCodeId).HasColumnName("discountCodeID");
            entity.Property(e => e.DiscountAmount).HasColumnName("discountAmount");
            entity.Property(e => e.DiscountCode)
                .HasMaxLength(50)
                .HasColumnName("discountCode");
            entity.Property(e => e.DiscountPercentage).HasColumnName("discountPercentage");
            entity.Property(e => e.UsageLimit).HasColumnName("usageLimit");
            entity.Property(e => e.UsageTimeEnd)
                .HasColumnType("datetime")
                .HasColumnName("usageTime_end");
            entity.Property(e => e.UsageTimeStart)
                .HasColumnType("datetime")
                .HasColumnName("usageTime_start");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("employee");

            entity.Property(e => e.EmployeeId).HasColumnName("employeeID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Permission).HasColumnName("permission");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Flavor>(entity =>
        {
            entity.ToTable("flavor");

            entity.Property(e => e.FlavorId).HasColumnName("flavorID");
            entity.Property(e => e.FlavorName)
                .HasMaxLength(50)
                .HasColumnName("flavorName");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<Ingridient>(entity =>
        {
            entity.HasKey(e => e.IngridientId).HasName("PK_ingridient_1");

            entity.ToTable("ingridient");

            entity.Property(e => e.IngridientId).HasColumnName("ingridientID");
            entity.Property(e => e.IngridientCatId).HasColumnName("ingridientCatID");
            entity.Property(e => e.IngridientName)
                .HasMaxLength(50)
                .HasColumnName("ingridientName");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.IngridientCat).WithMany(p => p.Ingridients)
                .HasForeignKey(d => d.IngridientCatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ingridient_ingridientCategory");
        });

        modelBuilder.Entity<IngridientCategory>(entity =>
        {
            entity.HasKey(e => e.IngridientCatId);

            entity.ToTable("ingridientCategory");

            entity.Property(e => e.IngridientCatId).HasColumnName("ingridientCatID");
            entity.Property(e => e.IngCatName)
                .HasMaxLength(50)
                .HasColumnName("ingCatName");
        });

        modelBuilder.Entity<Malatang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_malatang_1");

            entity.ToTable("malatang");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IngredientId).HasColumnName("IngredientID");
            entity.Property(e => e.Iquantity).HasColumnName("IQuantity");
            entity.Property(e => e.PId).HasColumnName("pID");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.Malatangs)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_malatang_ingridient");

            entity.HasOne(d => d.PIdNavigation).WithMany(p => p.Malatangs)
                .HasForeignKey(d => d.PId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_malatang_product1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("orders");

            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.Datetime).HasColumnName("datetime");
            entity.Property(e => e.DiscountCodeId).HasColumnName("discountCodeID");
            entity.Property(e => e.IsTakeOut).HasColumnName("isTakeOut");
            entity.Property(e => e.StatusId).HasColumnName("statusID");
            entity.Property(e => e.Table).HasColumnName("[table");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_orders_customers");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_orders_status");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK_merchandise_1");

            entity.ToTable("product");

            entity.Property(e => e.PId).HasColumnName("pID");
            entity.Property(e => e.FlavorId).HasColumnName("flavorID");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.PQuantity).HasColumnName("pQuantity");

            entity.HasOne(d => d.Flavor).WithMany(p => p.Products)
                .HasForeignKey(d => d.FlavorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_flavor");

            entity.HasOne(d => d.Order).WithMany(p => p.Products)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_orders");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("status");

            entity.Property(e => e.StatusId).HasColumnName("statusID");
            entity.Property(e => e.Status1)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
