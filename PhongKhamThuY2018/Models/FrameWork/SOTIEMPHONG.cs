namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SOTIEMPHONG")]
    public partial class SOTIEMPHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SOTIEMPHONG()
        {
            SOTIEMPHONG_CHITIET = new HashSet<SOTIEMPHONG_CHITIET>();
        }

        [Key]
        public int MASOTIEMPHONG { get; set; }

        public int MATHU { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYCAP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOTIEMPHONG_CHITIET> SOTIEMPHONG_CHITIET { get; set; }

        public virtual THU THU { get; set; }
    }
}
