namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THU")]
    public partial class THU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THU()
        {
            BENHAN = new HashSet<BENHAN>();
            LICHKHAM = new HashSet<LICHKHAM>();
            LICHSUKHAM = new HashSet<LICHSUKHAM>();
            NOITRU = new HashSet<NOITRU>();
            PHAUTHUAT = new HashSet<PHAUTHUAT>();
            PHIEUXETNGHIEM = new HashSet<PHIEUXETNGHIEM>();
            SOTIEMPHONG = new HashSet<SOTIEMPHONG>();
            THEODOITHU = new HashSet<THEODOITHU>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MATHU { get; set; }

        [Required]
        [StringLength(30)]
        public string TENTHU { get; set; }

        public int TUOI { get; set; }

        [Required]
        [StringLength(10)]
        public string GIOITINH { get; set; }

        [Required]
        [StringLength(30)]
        public string MAULONG { get; set; }

        [Required]
        [StringLength(30)]
        public string LOAI { get; set; }

        public int? MAKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BENHAN> BENHAN { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHKHAM> LICHKHAM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHSUKHAM> LICHSUKHAM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOITRU> NOITRU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHAUTHUAT> PHAUTHUAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUXETNGHIEM> PHIEUXETNGHIEM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOTIEMPHONG> SOTIEMPHONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THEODOITHU> THEODOITHU { get; set; }
    }
}
