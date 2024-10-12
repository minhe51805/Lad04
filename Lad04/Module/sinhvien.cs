namespace Lad04.Module
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sinhvien")]
    public partial class sinhvien
    {
        [Key]
        [StringLength(10)]
        public string ma { get; set; }

        [Required]
        [StringLength(255)]
        public string hoten { get; set; }

        public decimal? dtb { get; set; }

        public int? makhoa { get; set; }

        public virtual Khoa Khoa { get; set; }
    }
}
