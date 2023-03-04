using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Srez_1.Models;

public partial class Gr601MaevlContext : DbContext
{
    public Gr601MaevlContext()
    {
    }

    public Gr601MaevlContext(DbContextOptions<Gr601MaevlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TableInfoUser> TableInfoUsers { get; set; }

    public virtual DbSet<TableRole> TableRoles { get; set; }

    public virtual DbSet<TableUser> TableUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=10.30.0.137;Port=5432;Database=gr601_maevl;Username=gr601_maevl;Password=RSUiamRSUiam");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TableInfoUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("table_info_user_pk");

            entity.ToTable("table_info_user");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AddressHome)
                .HasColumnType("character varying")
                .HasColumnName("address_home");
            entity.Property(e => e.BirthdayDate).HasColumnName("birthday_date");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
        });

        modelBuilder.Entity<TableRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("table_role_pk");

            entity.ToTable("table_role");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.RoleName)
                .HasColumnType("character varying")
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<TableUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("table_user_pk");

            entity.ToTable("table_user");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasColumnType("character varying")
                .HasColumnName("first_name");
            entity.Property(e => e.IdInfoUser).HasColumnName("idInfoUser");
            entity.Property(e => e.IdRole).HasColumnName("idRole");
            entity.Property(e => e.LastName)
                .HasColumnType("character varying")
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasColumnType("character varying")
                .HasColumnName("middle_name");

            entity.HasOne(d => d.IdInfoUserNavigation).WithMany(p => p.TableUsers)
                .HasForeignKey(d => d.IdInfoUser)
                .HasConstraintName("table_user_table_info_user_null_fk");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.TableUsers)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("table_user_table_role_null_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
