﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLKFC.Models
{
    public partial class QLBHKFCContext : DbContext
    {
        public QLBHKFCContext()
        {
        }

        public QLBHKFCContext(DbContextOptions<QLBHKFCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<CthoaDon> CthoaDons { get; set; }
        public virtual DbSet<CthoaDonKho> CthoaDonKhos { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HoaDonKho> HoaDonKhos { get; set; }
        public virtual DbSet<Kho> Khos { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieus { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=QLBHKFC;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.MaCv)
                    .HasName("PK__ChucVu__27258E769C3D50AA");

                entity.ToTable("ChucVu");

                entity.Property(e => e.MaCv).HasColumnName("MaCV");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TenCv)
                    .HasMaxLength(20)
                    .HasColumnName("TenCV");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.ChucVus)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__ChucVu__ID__1DE57479");
            });

            modelBuilder.Entity<CthoaDon>(entity =>
            {
                entity.HasKey(e => new { e.MaHd, e.MaSp })
                    .HasName("PK__CTHoaDon__F557F66147D80247");

                entity.ToTable("CTHoaDon");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.CthoaDons)
                    .HasForeignKey(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_hd_cthd");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.CthoaDons)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_hd_sp");
            });

            modelBuilder.Entity<CthoaDonKho>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CTHoaDonKho");

                entity.Property(e => e.MaHdk).HasColumnName("MaHDK");

                entity.Property(e => e.MaNl).HasColumnName("MaNL");

                entity.HasOne(d => d.MaHdkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaHdk)
                    .HasConstraintName("fk_hdk_cthdk");

                entity.HasOne(d => d.MaNlNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaNl)
                    .HasConstraintName("fk_hdk_nl");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HoaDon__2725A6E06D656D80");

                entity.ToTable("HoaDon");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.NgayThang).HasColumnType("datetime");

                entity.Property(e => e.Pos)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("StoreID");

                entity.Property(e => e.TenNv)
                    .HasMaxLength(20)
                    .HasColumnName("TenNV");
            });

            modelBuilder.Entity<HoaDonKho>(entity =>
            {
                entity.HasKey(e => e.MaHdk)
                    .HasName("PK__HoaDonKh__3C90E8C3C234C367");

                entity.ToTable("HoaDonKho");

                entity.Property(e => e.MaHdk).HasColumnName("MaHDK");

                entity.Property(e => e.NgayCc)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayCC");

                entity.Property(e => e.TrangThai).HasMaxLength(20);
            });

            modelBuilder.Entity<Kho>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Kho");

                entity.Property(e => e.MaNl).HasColumnName("MaNL");

                entity.HasOne(d => d.MaNlNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaNl)
                    .HasConstraintName("fk_K_SP");
            });

            modelBuilder.Entity<LoaiSanPham>(entity =>
            {
                entity.HasKey(e => e.MaLsp)
                    .HasName("PK__LoaiSanP__3B983FFE68518E4B");

                entity.ToTable("LoaiSanPham");

                entity.Property(e => e.MaLsp).HasColumnName("MaLSP");

                entity.Property(e => e.TenLsp)
                    .HasMaxLength(20)
                    .HasColumnName("TenLSP");
            });

            modelBuilder.Entity<NguyenLieu>(entity =>
            {
                entity.HasKey(e => e.MaNl)
                    .HasName("PK__NguyenLi__2725D73C37A8500A");

                entity.ToTable("NguyenLieu");

                entity.Property(e => e.MaNl).HasColumnName("MaNL");

                entity.Property(e => e.TenNl)
                    .HasMaxLength(50)
                    .HasColumnName("TenNL");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.SoCmt)
                    .HasName("PK__NhanVien__23AAFF3C76D2302B");

                entity.ToTable("NhanVien");

                entity.Property(e => e.SoCmt)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SoCMT")
                    .IsFixedLength(true);

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.MaCv).HasColumnName("MaCV");

                entity.Property(e => e.NgayBatDau).HasColumnType("datetime");

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenNv)
                    .HasMaxLength(20)
                    .HasColumnName("TenNV");

                entity.HasOne(d => d.MaCvNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaCv)
                    .HasConstraintName("fk_CV_NV");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SanPham__2725081CC2CA776F");

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.Loai).HasMaxLength(20);

                entity.Property(e => e.MaLsp).HasColumnName("MaLSP");

                entity.Property(e => e.Mota).HasMaxLength(200);

                entity.Property(e => e.TenSp)
                    .HasMaxLength(100)
                    .HasColumnName("TenSP");

                entity.HasOne(d => d.MaLspNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaLsp)
                    .HasConstraintName("fk_LSP_SP");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.ToTable("TaiKhoan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TaiKhoan1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TaiKhoan");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
