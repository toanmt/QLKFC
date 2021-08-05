using System;
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
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.MaCv)
                    .HasName("PK__ChucVu__27258E761CAAFB69");

                entity.ToTable("ChucVu");

                entity.Property(e => e.MaCv).HasColumnName("MaCV");

                entity.Property(e => e.TenCv)
                    .HasMaxLength(20)
                    .HasColumnName("TenCV");
            });

            modelBuilder.Entity<CthoaDon>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CTHoaDon");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaHd)
                    .HasConstraintName("fk_hd_cthd");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaSp)
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
                    .HasName("PK__HoaDon__2725A6E088B3050C");

                entity.ToTable("HoaDon");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.NgayThang).HasColumnType("datetime");

                entity.Property(e => e.Pos)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("StoreID");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("fk_hd_nv");
            });

            modelBuilder.Entity<HoaDonKho>(entity =>
            {
                entity.HasKey(e => e.MaHdk)
                    .HasName("PK__HoaDonKh__3C90E8C32647C4F3");

                entity.ToTable("HoaDonKho");

                entity.Property(e => e.MaHdk).HasColumnName("MaHDK");

                entity.Property(e => e.NgayCc)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayCC");

                entity.Property(e => e.TrangThai).HasMaxLength(20);
            });

            modelBuilder.Entity<Kho>(entity =>
            {
                entity.HasKey(e => e.MaNl)
                    .HasName("PK__Kho__2725D73C1E6AE901");

                entity.ToTable("Kho");

                entity.Property(e => e.MaNl)
                    .ValueGeneratedNever()
                    .HasColumnName("MaNL");

                entity.HasOne(d => d.MaNlNavigation)
                    .WithOne(p => p.Kho)
                    .HasForeignKey<Kho>(d => d.MaNl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_K_SP");
            });

            modelBuilder.Entity<LoaiSanPham>(entity =>
            {
                entity.HasKey(e => e.MaLsp)
                    .HasName("PK__LoaiSanP__3B983FFEB80821BA");

                entity.ToTable("LoaiSanPham");

                entity.Property(e => e.MaLsp).HasColumnName("MaLSP");

                entity.Property(e => e.TenLsp)
                    .HasMaxLength(20)
                    .HasColumnName("TenLSP");
            });

            modelBuilder.Entity<NguyenLieu>(entity =>
            {
                entity.HasKey(e => e.MaNl)
                    .HasName("PK__NguyenLi__2725D73C037C1868");

                entity.ToTable("NguyenLieu");

                entity.Property(e => e.MaNl).HasColumnName("MaNL");

                entity.Property(e => e.TenNl)
                    .HasMaxLength(50)
                    .HasColumnName("TenNL");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NhanVien__2725D70A4C87A99A");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.Id).HasColumnName("ID");

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

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("fk_TK_NV");

                entity.HasOne(d => d.MaCvNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaCv)
                    .HasConstraintName("fk_CV_NV");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SanPham__2725081CB994A84B");

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.DonGia).HasColumnType("money");

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
