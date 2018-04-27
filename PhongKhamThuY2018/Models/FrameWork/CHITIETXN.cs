namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETXN")]
    public partial class CHITIETXN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MACTXN { get; set; }

        public int MAPHIEUXN { get; set; }

        public int MAXN { get; set; }

        [Required]
        [StringLength(50)]
        public string KETQUA { get; set; }

        public int SOLUONG { get; set; }

        [Column(TypeName = "money")]
        public decimal THANHTIEN { get; set; }

        public virtual LOAIXETNGHIEM LOAIXETNGHIEM { get; set; }

        public virtual PHIEUXETNGHIEM PHIEUXETNGHIEM { get; set; }
    }
}
