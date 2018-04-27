namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETTOA")]
    public partial class CHITIETTOA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MACTTOA { get; set; }

        public int? MATOA { get; set; }

        public int? MATHUOC { get; set; }

        public int? SOLUONG { get; set; }

        [Column(TypeName = "money")]
        public decimal? THANHTIEN { get; set; }

        [StringLength(500)]
        public string GHICHU { get; set; }

        public virtual TOATHUOC TOATHUOC { get; set; }

        public virtual THUOC THUOC { get; set; }
    }
}
