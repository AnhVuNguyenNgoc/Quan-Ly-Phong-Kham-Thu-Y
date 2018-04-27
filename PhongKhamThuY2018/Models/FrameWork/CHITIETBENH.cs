namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETBENH")]
    public partial class CHITIETBENH
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MACT { get; set; }

        public int? MABENHAN { get; set; }

        [Required]
        [StringLength(50)]
        public string BENH { get; set; }

        [Required]
        [StringLength(50)]
        public string TRIEUCHUNG { get; set; }

        public int MATOA { get; set; }

        public virtual BENHAN BENHAN { get; set; }

        public virtual TOATHUOC TOATHUOC { get; set; }
    }
}
