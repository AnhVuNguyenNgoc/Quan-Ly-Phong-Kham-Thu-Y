namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NOITRU")]
    public partial class NOITRU
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MANOITRU { get; set; }

        public int MAKH { get; set; }

        public int MATHU { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYNHAPVIEN { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYRAVIEN { get; set; }

        public virtual THU THU { get; set; }
    }
}
