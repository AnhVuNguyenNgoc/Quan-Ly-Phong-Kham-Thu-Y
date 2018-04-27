namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THUOC")]
    public partial class THUOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUOC()
        {
            CHITIETTOA = new HashSet<CHITIETTOA>();
            TIEMPHONG = new HashSet<TIEMPHONG>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã thuốc")]
        public int MATHUOC { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tên thuốc")]
        public string TENTHUOC { get; set; }

        [DisplayName("Số lượng")]
        public int SOLUONG { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày nhập")]
        public DateTime NGAYNHAP { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Hạn sử dụng")]
        public DateTime HANSUDUNG { get; set; }

        [DisplayName("Đơn giá")]
        public double DONGIA { get; set; }

        [Required]
        [StringLength(500)]
        [DisplayName("Hướng dẫn sử dụng")]
        public string HUONGDANSUDUNG { get; set; }

        [DisplayName("Đơn vị")]
        public int MADONVI { get; set; }

        [DisplayName("Tình trạng")]
        public bool TINHTRANG { get; set; }

        public int? MALOAITHUOC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETTOA> CHITIETTOA { get; set; }

        public virtual DONVITHUOC DONVITHUOC { get; set; }

        public virtual LOAITHUOC LOAITHUOC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIEMPHONG> TIEMPHONG { get; set; }
    }
}
