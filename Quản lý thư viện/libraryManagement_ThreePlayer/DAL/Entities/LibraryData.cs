using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Entities
{
    public partial class LibraryData : DbContext
    {
        public LibraryData()
            : base("name=LibraryData")
        {
        }

        public virtual DbSet<CT_PhieuMuon> CT_PhieuMuon { get; set; }
        public virtual DbSet<CT_PhieuPhat> CT_PhieuPhat { get; set; }
        public virtual DbSet<CT_PhieuTra> CT_PhieuTra { get; set; }
        public virtual DbSet<DocGia> DocGia { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<PhieuMuon> PhieuMuon { get; set; }
        public virtual DbSet<PhieuPhat> PhieuPhat { get; set; }
        public virtual DbSet<PhieuTra> PhieuTra { get; set; }
        public virtual DbSet<Sach> Sach { get; set; }
        public virtual DbSet<TacGia> TacGia { get; set; }
        public virtual DbSet<TheLoai> TheLoai { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CT_PhieuMuon>()
                .Property(e => e.MaPhieuMuon)
                .IsUnicode(false);

            modelBuilder.Entity<CT_PhieuMuon>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<CT_PhieuMuon>()
                .HasMany(e => e.CT_PhieuTra)
                .WithRequired(e => e.CT_PhieuMuon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CT_PhieuPhat>()
                .Property(e => e.MaPhieuPhat)
                .IsUnicode(false);

            modelBuilder.Entity<CT_PhieuTra>()
                .Property(e => e.MaPhieuTra)
                .IsUnicode(false);

            modelBuilder.Entity<CT_PhieuTra>()
                .Property(e => e.MaDocGia)
                .IsUnicode(false);

            modelBuilder.Entity<DocGia>()
                .Property(e => e.MaDocGia)
                .IsUnicode(false);

            modelBuilder.Entity<DocGia>()
                .HasMany(e => e.CT_PhieuTra)
                .WithRequired(e => e.DocGia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DocGia>()
                .HasMany(e => e.PhieuMuon)
                .WithRequired(e => e.DocGia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.PhieuMuon)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.PhieuPhat)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.PhieuTra)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuMuon>()
                .Property(e => e.MaPhieuMuon)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuMuon>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuMuon>()
                .Property(e => e.MaDocGia)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuMuon>()
                .HasMany(e => e.PhieuPhat)
                .WithRequired(e => e.PhieuMuon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuMuon>()
                .HasMany(e => e.PhieuTra)
                .WithRequired(e => e.PhieuMuon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuPhat>()
                .Property(e => e.MaPhieuPhat)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuPhat>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuPhat>()
                .Property(e => e.MaPhieuMuon)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuPhat>()
                .HasMany(e => e.CT_PhieuPhat)
                .WithRequired(e => e.PhieuPhat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuTra>()
                .Property(e => e.MaPhieuTra)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuTra>()
                .Property(e => e.MaPhieuMuon)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuTra>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuTra>()
                .HasMany(e => e.CT_PhieuTra)
                .WithRequired(e => e.PhieuTra)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaTheLoai)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaTacGia)
                .IsUnicode(false);

            modelBuilder.Entity<TacGia>()
                .Property(e => e.MaTacGia)
                .IsUnicode(false);

            modelBuilder.Entity<TacGia>()
                .HasMany(e => e.Sach)
                .WithRequired(e => e.TacGia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TheLoai>()
                .Property(e => e.MaTheLoai)
                .IsUnicode(false);

            modelBuilder.Entity<TheLoai>()
                .HasMany(e => e.Sach)
                .WithRequired(e => e.TheLoai)
                .WillCascadeOnDelete(false);
        }
    }
}
