namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BENHAN")]
    public partial class BENHAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BENHAN()
        {
            CHITIETBENH = new HashSet<CHITIETBENH>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MABENHAN { get; set; }

        public int? MATHU { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYKHAM { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYLANH { get; set; }

        public virtual THU THU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETBENH> CHITIETBENH { get; set; }
    }
}
