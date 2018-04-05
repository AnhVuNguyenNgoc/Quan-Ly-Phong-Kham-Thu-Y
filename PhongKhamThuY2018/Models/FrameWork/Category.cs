namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name="Tên thuốc")]
        public string Name { get; set; }

         [Display(Name = "Còn sử dụng")]
        public bool Status { get; set; }

        [Column(TypeName = "date")]

        public DateTime? NgayNhap { get; set; }

         [Display(Name = "Số lượng")]
        public int? SoLuong { get; set; }
    }
}
