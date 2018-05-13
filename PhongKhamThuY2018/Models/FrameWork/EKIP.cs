namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EKIP")]
    public partial class EKIP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EKIP()
        {
            PHAUTHUAT = new HashSet<PHAUTHUAT>();
        }

        [Key]
        public int MAEKIP { get; set; }

        public int? MABSCHINH { get; set; }

        public int? SOLUONGTV { get; set; }

        public virtual BACSI BACSI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHAUTHUAT> PHAUTHUAT { get; set; }
    }
}
