namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TIEMPHONG")]
    public partial class TIEMPHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIEMPHONG()
        {
            CTSOTIEMPHONG = new HashSet<CTSOTIEMPHONG>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MATIEMPHONG { get; set; }

        [StringLength(50)]
        public string TENLOAITIEM { get; set; }

        public int? MATHUOC { get; set; }

        [Column(TypeName = "money")]
        public decimal? DONGIA { get; set; }

        [Required]
        [StringLength(50)]
        public string GHICHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTSOTIEMPHONG> CTSOTIEMPHONG { get; set; }

        public virtual THUOC THUOC { get; set; }
    }
}
