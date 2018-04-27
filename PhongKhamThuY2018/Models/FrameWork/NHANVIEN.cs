namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            CTEKIP = new HashSet<CTEKIP>();
            EKIP = new HashSet<EKIP>();
            LICHSUKHAM = new HashSet<LICHSUKHAM>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MANV { get; set; }

        [StringLength(50)]
        public string TENNV { get; set; }

        public int TUOI { get; set; }

        [Required]
        [StringLength(20)]
        public string GIOITINH { get; set; }

        public int CHUYENMON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTEKIP> CTEKIP { get; set; }

        public virtual CHUYENMON CHUYENMON1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EKIP> EKIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHSUKHAM> LICHSUKHAM { get; set; }
    }
}
