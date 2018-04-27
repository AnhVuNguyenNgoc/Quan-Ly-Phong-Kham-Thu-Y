namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIXETNGHIEM")]
    public partial class LOAIXETNGHIEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIXETNGHIEM()
        {
            CHITIETXN = new HashSet<CHITIETXN>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAXN { get; set; }

        [Required]
        [StringLength(50)]
        public string TENXETNGHIEM { get; set; }

        public TimeSpan THOIGIAN { get; set; }

        [Column(TypeName = "money")]
        public decimal DONGIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETXN> CHITIETXN { get; set; }
    }
}
