namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SOTIEMPHONG_CHITIET
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MASO { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MATIEMPHONG { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime NGAYTIEM { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime NGAYHEN { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SOLUONG { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "money")]
        public decimal THANHTIEN { get; set; }

        public virtual SOTIEMPHONG SOTIEMPHONG { get; set; }

        public virtual TIEMPHONG TIEMPHONG { get; set; }
    }
}
