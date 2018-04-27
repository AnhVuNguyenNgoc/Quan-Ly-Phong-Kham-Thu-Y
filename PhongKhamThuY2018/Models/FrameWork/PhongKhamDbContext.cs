namespace Models.FrameWork
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PhongKhamDbContext : DbContext
    {
        public PhongKhamDbContext()
            : base("name=PhongKhamDbContext1")
        {
        }

        public virtual DbSet<BENHAN> BENHAN { get; set; }
        public virtual DbSet<CTEKIP> CTEKIP { get; set; }
        public virtual DbSet<CTSOTIEMPHONG> CTSOTIEMPHONG { get; set; }
        public virtual DbSet<CHITIETBENH> CHITIETBENH { get; set; }
        public virtual DbSet<CHITIETTOA> CHITIETTOA { get; set; }
        public virtual DbSet<CHITIETXN> CHITIETXN { get; set; }
        public virtual DbSet<CHUYENMON> CHUYENMON { get; set; }
        public virtual DbSet<DONVITHUOC> DONVITHUOC { get; set; }
        public virtual DbSet<EKIP> EKIP { get; set; }
        public virtual DbSet<GIAKHAMBENH> GIAKHAMBENH { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANG { get; set; }
        public virtual DbSet<LICHKHAM> LICHKHAM { get; set; }
        public virtual DbSet<LICHSUKHAM> LICHSUKHAM { get; set; }
        public virtual DbSet<LOAITHUOC> LOAITHUOC { get; set; }
        public virtual DbSet<LOAIXETNGHIEM> LOAIXETNGHIEM { get; set; }
        public virtual DbSet<NOITRU> NOITRU { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNG { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIEN { get; set; }
        public virtual DbSet<PHAUTHUAT> PHAUTHUAT { get; set; }
        public virtual DbSet<PHIEUXETNGHIEM> PHIEUXETNGHIEM { get; set; }
        public virtual DbSet<SOTIEMPHONG> SOTIEMPHONG { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TIEMPHONG> TIEMPHONG { get; set; }
        public virtual DbSet<TOATHUOC> TOATHUOC { get; set; }
        public virtual DbSet<THEODOITHU> THEODOITHU { get; set; }
        public virtual DbSet<THU> THU { get; set; }
        public virtual DbSet<THUOC> THUOC { get; set; }
        public virtual DbSet<VATTU> VATTU { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTSOTIEMPHONG>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CHITIETTOA>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CHITIETXN>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CHUYENMON>()
                .HasMany(e => e.NHANVIEN)
                .WithRequired(e => e.CHUYENMON1)
                .HasForeignKey(e => e.CHUYENMON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DONVITHUOC>()
                .HasMany(e => e.THUOC)
                .WithRequired(e => e.DONVITHUOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EKIP>()
                .HasMany(e => e.PHAUTHUAT)
                .WithRequired(e => e.EKIP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GIAKHAMBENH>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<GIAKHAMBENH>()
                .Property(e => e.GIA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.TEN)
                .IsFixedLength();

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<LICHKHAM>()
                .Property(e => e.DIADIEM)
                .IsFixedLength();

            modelBuilder.Entity<LICHSUKHAM>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LOAIXETNGHIEM>()
                .Property(e => e.DONGIA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LOAIXETNGHIEM>()
                .HasMany(e => e.CHITIETXN)
                .WithRequired(e => e.LOAIXETNGHIEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.CTEKIP)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.MABS);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.EKIP)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.MABSCHINH);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.LICHSUKHAM)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUXETNGHIEM>()
                .Property(e => e.GIA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PHIEUXETNGHIEM>()
                .HasMany(e => e.CHITIETXN)
                .WithRequired(e => e.PHIEUXETNGHIEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SOTIEMPHONG>()
                .HasMany(e => e.CTSOTIEMPHONG)
                .WithRequired(e => e.SOTIEMPHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TIEMPHONG>()
                .Property(e => e.DONGIA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TIEMPHONG>()
                .HasMany(e => e.CTSOTIEMPHONG)
                .WithRequired(e => e.TIEMPHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TOATHUOC>()
                .HasMany(e => e.CHITIETBENH)
                .WithRequired(e => e.TOATHUOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THU>()
                .Property(e => e.GIOITINH)
                .IsFixedLength();

            modelBuilder.Entity<THU>()
                .HasMany(e => e.LICHSUKHAM)
                .WithRequired(e => e.THU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THU>()
                .HasMany(e => e.NOITRU)
                .WithRequired(e => e.THU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THU>()
                .HasMany(e => e.PHAUTHUAT)
                .WithRequired(e => e.THU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THU>()
                .HasMany(e => e.PHIEUXETNGHIEM)
                .WithRequired(e => e.THU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THU>()
                .HasMany(e => e.SOTIEMPHONG)
                .WithRequired(e => e.THU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUOC>()
                .HasMany(e => e.CHITIETTOA)
                .WithOptional(e => e.THUOC)
                .HasForeignKey(e => e.MATOA);

            modelBuilder.Entity<VATTU>()
                .Property(e => e.GIA)
                .HasPrecision(19, 4);
        }
    }
}
