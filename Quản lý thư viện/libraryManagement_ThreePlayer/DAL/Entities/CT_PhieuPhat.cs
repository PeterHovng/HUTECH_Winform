namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PhieuPhat
    {
        [Key]
        public int sttPhieuPhat { get; set; }

        [Required]
        [StringLength(5)]
        public string MaPhieuPhat { get; set; }

        public double? TongTien { get; set; }

        [Required]
        [StringLength(225)]
        public string NoiDung { get; set; }

        public virtual PhieuPhat PhieuPhat { get; set; }
    }
}
