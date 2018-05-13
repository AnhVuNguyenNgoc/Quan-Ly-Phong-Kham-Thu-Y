namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            THU = new HashSet<THU>();
        }

        [Key]
        public int MAKH { get; set; }

        [Required]
        [StringLength(30)]
        public string TEN { get; set; }

        public int TUOI { get; set; }

        [Required]
        [StringLength(3)]
        public string GIOITINH { get; set; }

        [Required]
        [StringLength(50)]
        public string DIACHI { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THU> THU { get; set; }
    }
}
