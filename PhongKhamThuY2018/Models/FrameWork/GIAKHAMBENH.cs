namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIAKHAMBENH")]
    public partial class GIAKHAMBENH
    {
        [StringLength(30)]
        public string ID { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIA { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYAPDUNG { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYHETHAN { get; set; }
    }
}
