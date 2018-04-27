namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VATTU")]
    public partial class VATTU
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAVATTU { get; set; }

        [Required]
        [StringLength(50)]
        public string TENVATTU { get; set; }

        public int SOLUONG { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYNHAP { get; set; }

        [Column(TypeName = "money")]
        public decimal GIA { get; set; }
    }
}
