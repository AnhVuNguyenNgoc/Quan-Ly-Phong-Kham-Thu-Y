namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THUOC")]
    public partial class THUOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUOC()
        {
            TIEMPHONG = new HashSet<TIEMPHONG>();
            CTTOATHUOC = new HashSet<CTTOATHUOC>();
        }

        [Key]
        public int MATHUOC { get; set; }

       
        [StringLength(50)]
        [Required(ErrorMessage = "Bạn chưa nhập tên thuốc")]
        public string TENTHUOC { get; set; }

        public int SOLUONG { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYNHAP { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HANSUDUNG { get; set; }

        public double DONGIA { get; set; }

        [Required]
        [StringLength(500)]
        public string HUONGDANSUDUNG { get; set; }

        public int? MADONVI { get; set; }

        public bool TINHTRANG { get; set; }

        public int? MALOAITHUOC { get; set; }

        public virtual DONVITHUOC DONVITHUOC { get; set; }

        public virtual LOAITHUOC LOAITHUOC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIEMPHONG> TIEMPHONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTTOATHUOC> CTTOATHUOC { get; set; }
    }
}
