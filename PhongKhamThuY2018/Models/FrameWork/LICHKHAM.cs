namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LICHKHAM")]
    public partial class LICHKHAM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MALICH { get; set; }

        public int? MATHU { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYHEN { get; set; }

        public TimeSpan? GIOHEN { get; set; }

        [Required]
        [StringLength(10)]
        public string DIADIEM { get; set; }

        public long DAPASS { get; set; }

        public virtual THU THU { get; set; }
    }
}
