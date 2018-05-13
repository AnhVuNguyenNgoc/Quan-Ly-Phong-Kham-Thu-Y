namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHAUTHUAT")]
    public partial class PHAUTHUAT
    {
        [Key]
        public int MAPHAUTHUAT { get; set; }

        public int MATHU { get; set; }

        public int MAGIAYCK { get; set; }

        public int MAXN { get; set; }

        public int MAEKIP { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYPHAUTHUAT { get; set; }

        public TimeSpan THOIGIANBATDAU { get; set; }

        public TimeSpan THOIGIANKT { get; set; }

        public virtual EKIP EKIP { get; set; }

        public virtual THU THU { get; set; }
    }
}
