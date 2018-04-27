namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTEKIP")]
    public partial class CTEKIP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MACTEKIP { get; set; }

        public int? MAEKIP { get; set; }

        public int? MABS { get; set; }

        public virtual EKIP EKIP { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
