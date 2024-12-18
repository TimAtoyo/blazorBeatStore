using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EcommerseBlazor.Models;

public partial class BeatStoreContext : DbContext
{
    public BeatStoreContext()
    {
    }

    public BeatStoreContext(DbContextOptions<BeatStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminLog> AdminLogs { get; set; }

    public virtual DbSet<Beat> Beats { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=BeatStore;User Id=sa;Password=YourStrongPassword123;TrustServerCertificate=True;Persist Security Info=False;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__AdminLog__5E5499A80530A125");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.Action).HasMaxLength(255);
            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Admin).WithMany(p => p.AdminLogs)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK_AdminLogs_Users");
        });

        modelBuilder.Entity<Beat>(entity =>
        {
            entity.HasKey(e => e.BeatId).HasName("PK__Beats__0FFC755F1C30A496");

            entity.ToTable(tb => tb.HasTrigger("TRG_Delete_Beat_Purchases"));

            entity.Property(e => e.BeatId).HasColumnName("BeatID");
            entity.Property(e => e.CoverImagePath).HasMaxLength(255);
            entity.Property(e => e.FilePath).HasMaxLength(255);
            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.UploadDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.GenreNavigation).WithMany(p => p.Beats)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Beats_Genres");

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.Beats)
                .HasForeignKey(d => d.UploadedBy)
                .HasConstraintName("FK_Beats_Users");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genres__0385055E65F0E3E1");

            entity.HasIndex(e => e.GenreName, "UQ__Genres__BBE1C339BD7F8AD6").IsUnique();

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.GenreName).HasMaxLength(50);
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PK__Purchase__6B0A6BDE1F26E219");

            entity.Property(e => e.PurchaseId).HasColumnName("PurchaseID");
            entity.Property(e => e.BeatId).HasColumnName("BeatID");
            entity.Property(e => e.PriceAtPurchase).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PurchaseDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Beat).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.BeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchases_Beats");

            entity.HasOne(d => d.User).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchases_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC4C93C8E2");

            entity.ToTable(tb => tb.HasTrigger("TRG_Delete_User_Purchases"));

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E47903314B").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534B6C89CC6").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
