using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DATABASE_FIRST.Models;

public partial class MenuContext : DbContext
{
    public MenuContext()
    {
    }

    public MenuContext(DbContextOptions<MenuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MENU;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CATEGORY__3214EC27684C08C8");

            entity.ToTable("CATEGORY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Namme)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAMME");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ITEM__3214EC27B7AE2DD4");

            entity.ToTable("ITEM");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.IdCategory).HasColumnName("ID_CATEGORY");
            entity.Property(e => e.Imagem)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IMAGEM");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRICE");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Items)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK__ITEM__ID_CATEGOR__3C69FB99");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ORDERS__3214EC2741B829DB");

            entity.ToTable("ORDERS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdUsers).HasColumnName("ID_USERS");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Timeorder)
                .HasColumnType("datetime")
                .HasColumnName("TIMEORDER");

            entity.HasOne(d => d.IdUsersNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUsers)
                .HasConstraintName("FK__ORDERS__ID_USERS__403A8C7D");

            entity.HasMany(d => d.IdItems).WithMany(p => p.IdOrders)
                .UsingEntity<Dictionary<string, object>>(
                    "Orderitem",
                    r => r.HasOne<Item>().WithMany()
                        .HasForeignKey("IdItem")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ORDERITEM__ID_IT__440B1D61"),
                    l => l.HasOne<Order>().WithMany()
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ORDERITEM__ID_OR__4316F928"),
                    j =>
                    {
                        j.HasKey("IdOrder", "IdItem").HasName("PK__ORDERITE__985401B3907A3F5D");
                        j.ToTable("ORDERITEM");
                        j.IndexerProperty<int>("IdOrder").HasColumnName("ID_ORDER");
                        j.IndexerProperty<int>("IdItem").HasColumnName("ID_ITEM");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC2739FB1EAC");

            entity.HasIndex(e => e.Password, "UQ__Users__93DCC1BE14F2BC52").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROLE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
