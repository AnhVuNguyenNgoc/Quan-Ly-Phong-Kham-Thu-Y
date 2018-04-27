namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LICHSUKHAM")]
    public partial class LICHSUKHAM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MALS { get; set; }

        public int MAKH { get; set; }

        public int MATHU { get; set; }

        public int MANV { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYKHAM { get; set; }

        [Required]
        [StringLength(50)]
        public string BENH { get; set; }

        [Column(TypeName = "money")]
        public decimal THANHTIEN { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual THU THU { get; set; }
    }
}
