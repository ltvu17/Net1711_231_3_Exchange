using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExchangeData.Models;

public partial class Net17112313ExchangeContext : DbContext
{
    public Net17112313ExchangeContext()
    {
    }

    public Net17112313ExchangeContext(DbContextOptions<Net17112313ExchangeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Exchange> Exchanges { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Sell> Sells { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-5056C2L\\SQLEXPRESS;uid=sa;password=12345;Initial Catalog=Net1711_231_3_Exchange;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    //"Data Source=(local);Initial Catalog=Net1711_231_3_Exchange;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83F55F52C15");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__comments__3213E83F8076DDD4");

            entity.HasOne(d => d.Product).WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__comments__produc__35BCFE0A");

            entity.HasOne(d => d.Student).WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__comments__studen__36B12243");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__company__3213E83F55CB81F5");
        });

        modelBuilder.Entity<Exchange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__exchange__3213E83F54456628");

            entity.HasOne(d => d.ExchangeNavigation).WithMany(p => p.Exchanges)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__exchanges__excha__37A5467C");

            entity.HasOne(d => d.Transaction).WithMany(p => p.Exchanges)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__exchanges__trans__38996AB5");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__products__3213E83F9AD9AE01");

            entity.HasOne(d => d.ApproveByNavigation).WithMany(p => p.Products).HasConstraintName("FK__products__approv__398D8EEE");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__products__catego__3A81B327");

            entity.HasOne(d => d.Student).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__products__studen__3B75D760");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reports__3213E83F9C0DCC65");

            entity.HasOne(d => d.ApproveByNavigation).WithMany(p => p.Reports).HasConstraintName("FK__reports__approve__3C69FB99");

            entity.HasOne(d => d.AssigneeNavigation).WithMany(p => p.ReportAssigneeNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reports__assigne__3D5E1FD2");

            entity.HasOne(d => d.Product).WithMany(p => p.Reports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reports__product__3E52440B");

            entity.HasOne(d => d.ReporterNavigation).WithMany(p => p.ReportReporterNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reports__reporte__3F466844");
        });

        modelBuilder.Entity<Sell>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sells__3213E83F1A2DC942");

            entity.Property(e => e.Payment).IsFixedLength();

            entity.HasOne(d => d.Transaction).WithMany(p => p.Sells)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sells__transacti__403A8C7D");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__students__3213E83FDD5A5007");

            entity.Property(e => e.Phone).IsFixedLength();

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__students__user_i__412EB0B6");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__transact__3213E83FAB577EF6");

            entity.HasOne(d => d.Product).WithMany(p => p.Transactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__transacti__produ__4222D4EF");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F1C7DA4C3");

            entity.Property(e => e.Role).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
