namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACCOUNT")]
    public partial class ACCOUNT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string USERNAME { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string PASSWORD { get; set; }
    }
}
