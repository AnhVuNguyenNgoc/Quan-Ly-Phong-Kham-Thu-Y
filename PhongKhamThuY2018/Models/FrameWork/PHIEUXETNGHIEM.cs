namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUXETNGHIEM")]
    public partial class PHIEUXETNGHIEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUXETNGHIEM()
        {
            CHITIETXN = new HashSet<CHITIETXN>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAPHIEUXN { get; set; }

        public int MATHU { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYXN { get; set; }

        [Column(TypeName = "money")]
        public decimal GIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETXN> CHITIETXN { get; set; }

        public virtual THU THU { get; set; }
    }
}
