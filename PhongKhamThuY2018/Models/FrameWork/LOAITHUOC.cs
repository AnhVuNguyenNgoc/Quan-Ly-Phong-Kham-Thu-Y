namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAITHUOC")]
    public partial class LOAITHUOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAITHUOC()
        {
            THUOC = new HashSet<THUOC>();
        }

        [Key]
        public int MALOAITHUOC { get; set; }

        [Required]
        [StringLength(50)]
        public string TENLOAITHUOC { get; set; }

        public bool TINHTRANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THUOC> THUOC { get; set; }
    }
}
