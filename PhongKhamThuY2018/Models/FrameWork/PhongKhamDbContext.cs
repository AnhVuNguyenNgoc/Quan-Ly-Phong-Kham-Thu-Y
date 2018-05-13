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

        public virtual DbSet<BACSI> BACSI { get; set; }
        public virtual DbSet<BENHAN> BENHAN { get; set; }
        public virtual DbSet<DONVITHUOC> DONVITHUOC { get; set; }
        public virtual DbSet<EKIP> EKIP { get; set; }
        public virtual DbSet<GIAKHAMBENH> GIAKHAMBENH { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANG { get; set; }
        public virtual DbSet<LICHKHAM> LICHKHAM { get; set; }
        public virtual DbSet<LOAITHUOC> LOAITHUOC { get; set; }
        public virtual DbSet<LOAIXETNGHIEM> LOAIXETNGHIEM { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNG { get; set; }
        public virtual DbSet<PHAUTHUAT> PHAUTHUAT { get; set; }
        public virtual DbSet<PHIEUXETNGHIEM> PHIEUXETNGHIEM { get; set; }
        public virtual DbSet<SOTIEMPHONG> SOTIEMPHONG { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TIEMPHONG> TIEMPHONG { get; set; }
        public virtual DbSet<TOATHUOC> TOATHUOC { get; set; }
        public virtual DbSet<THU> THU { get; set; }
        public virtual DbSet<THUOC> THUOC { get; set; }
        public virtual DbSet<CTTOATHUOC> CTTOATHUOC { get; set; }
        public virtual DbSet<CHITIETXN> CHITIETXN { get; set; }
        public virtual DbSet<SOTIEMPHONG_CHITIET> SOTIEMPHONG_CHITIET { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BACSI>()
                .HasMany(e => e.EKIP)
                .WithOptional(e => e.BACSI)
                .HasForeignKey(e => e.MABSCHINH);

            modelBuilder.Entity<EKIP>()
                .HasMany(e => e.PHAUTHUAT)
                .WithRequired(e => e.EKIP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GIAKHAMBENH>()
                .Property(e => e.GIA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.TEN)
                .IsFixedLength();

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<LICHKHAM>()
                .Property(e => e.DIADIEM)
                .IsFixedLength();

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

            modelBuilder.Entity<PHIEUXETNGHIEM>()
                .Property(e => e.GIA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PHIEUXETNGHIEM>()
                .HasMany(e => e.CHITIETXN)
                .WithRequired(e => e.PHIEUXETNGHIEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SOTIEMPHONG>()
                .HasMany(e => e.SOTIEMPHONG_CHITIET)
                .WithRequired(e => e.SOTIEMPHONG)
                .HasForeignKey(e => e.MASO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TIEMPHONG>()
                .Property(e => e.DONGIA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TIEMPHONG>()
                .HasMany(e => e.SOTIEMPHONG_CHITIET)
                .WithRequired(e => e.TIEMPHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TOATHUOC>()
                .HasMany(e => e.BENHAN)
                .WithRequired(e => e.TOATHUOC)
                .HasForeignKey(e => e.MATOA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TOATHUOC>()
                .HasMany(e => e.CTTOATHUOC)
                .WithRequired(e => e.TOATHUOC)
                .HasForeignKey(e => e.MATOA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THU>()
                .Property(e => e.GIOITINH)
                .IsFixedLength();

            modelBuilder.Entity<THU>()
                .HasMany(e => e.BENHAN)
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
                .HasMany(e => e.CTTOATHUOC)
                .WithRequired(e => e.THUOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CHITIETXN>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SOTIEMPHONG_CHITIET>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(19, 4);
        }
    }
}
