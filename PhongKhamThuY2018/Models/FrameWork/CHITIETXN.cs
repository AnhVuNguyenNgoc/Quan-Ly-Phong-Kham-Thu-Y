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
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAPHIEUXN { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAXN { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string KETQUA { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SOLUONG { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "money")]
        public decimal THANHTIEN { get; set; }

        public virtual LOAIXETNGHIEM LOAIXETNGHIEM { get; set; }

        public virtual PHIEUXETNGHIEM PHIEUXETNGHIEM { get; set; }
    }
}
