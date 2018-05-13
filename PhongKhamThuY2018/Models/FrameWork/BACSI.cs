namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BACSI")]
    public partial class BACSI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BACSI()
        {
            EKIP = new HashSet<EKIP>();
        }

        [Key]
        public int MABACSI { get; set; }

        [Required]
        [StringLength(50)]
        public string TENBACSI { get; set; }

        public int TUOI { get; set; }

        [Required]
        [StringLength(20)]
        public string GIOITINH { get; set; }

        public int CHUYENMON { get; set; }

        public bool TINHTRANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EKIP> EKIP { get; set; }
    }
}
