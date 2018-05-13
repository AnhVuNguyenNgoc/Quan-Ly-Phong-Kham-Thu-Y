namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TOATHUOC")]
    public partial class TOATHUOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TOATHUOC()
        {
            BENHAN = new HashSet<BENHAN>();
            CTTOATHUOC = new HashSet<CTTOATHUOC>();
        }

        [Key]
        public int MATOATHUOC { get; set; }

        public int? THOIGIANSUDUNG { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYKETOA { get; set; }

        public double TONGTIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BENHAN> BENHAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTTOATHUOC> CTTOATHUOC { get; set; }
    }
}
