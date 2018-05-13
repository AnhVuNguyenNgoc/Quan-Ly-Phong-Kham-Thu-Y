namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTTOATHUOC")]
    public partial class CTTOATHUOC
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MATOA { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MATHUOC { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SOLUONG { get; set; }

        [Key]
        [Column(Order = 3)]
        public double GIATIEN { get; set; }

        [Key]
        [Column(Order = 4)]
        public string GHICHU { get; set; }

        public virtual TOATHUOC TOATHUOC { get; set; }

        public virtual THUOC THUOC { get; set; }
    }
}
