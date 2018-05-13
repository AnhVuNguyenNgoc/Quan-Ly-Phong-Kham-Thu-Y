namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BENHAN")]
    public partial class BENHAN
    {
        [Key]
        public int MABENHAN { get; set; }

        public int MATHU { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYKHAM { get; set; }

        [Required]
        [StringLength(100)]
        public string BENH { get; set; }

        [Required]
        public string TRIEUCHUNG { get; set; }

        public int MATOA { get; set; }

        public virtual TOATHUOC TOATHUOC { get; set; }

        public virtual THU THU { get; set; }
    }
}
