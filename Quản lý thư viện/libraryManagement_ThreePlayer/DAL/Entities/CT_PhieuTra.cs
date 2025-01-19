namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PhieuTra
    {
        [Key]
        public int sttPhieuTra { get; set; }

        public int sttPhieuMuon { get; set; }

        [Required]
        [StringLength(5)]
        public string MaPhieuTra { get; set; }

        [Required]
        [StringLength(5)]
        public string MaDocGia { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayTraSach { get; set; }

        public virtual CT_PhieuMuon CT_PhieuMuon { get; set; }

        public virtual DocGia DocGia { get; set; }

        public virtual PhieuTra PhieuTra { get; set; }
    }
}
