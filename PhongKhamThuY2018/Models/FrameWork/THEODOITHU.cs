namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THEODOITHU")]
    public partial class THEODOITHU
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MATHEODOI { get; set; }

        public int? MATHU { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAY { get; set; }

        [Required]
        [StringLength(50)]
        public string TINHTRANG { get; set; }

        [Required]
        [StringLength(50)]
        public string GHICHU { get; set; }

        public virtual THU THU { get; set; }
    }
}
