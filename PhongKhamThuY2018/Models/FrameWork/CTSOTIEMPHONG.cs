namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTSOTIEMPHONG")]
    public partial class CTSOTIEMPHONG
    {
        public int MASO { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MACTSO { get; set; }

        public int MATIEMPHONG { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYTIEM { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYHEN { get; set; }

        public int SOLUONG { get; set; }

        [Column(TypeName = "money")]
        public decimal THANHTIEN { get; set; }

        public virtual SOTIEMPHONG SOTIEMPHONG { get; set; }

        public virtual TIEMPHONG TIEMPHONG { get; set; }
    }
}
