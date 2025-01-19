namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PhieuMuon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CT_PhieuMuon()
        {
            CT_PhieuTra = new HashSet<CT_PhieuTra>();
        }

        [Key]
        public int sttPhieuMuon { get; set; }

        [StringLength(5)]
        public string MaPhieuMuon { get; set; }

        [StringLength(10)]
        public string MaSach { get; set; }

        public int SoLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayTra { get; set; }

        public virtual PhieuMuon PhieuMuon { get; set; }

        public virtual Sach Sach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhieuTra> CT_PhieuTra { get; set; }
    }
}
