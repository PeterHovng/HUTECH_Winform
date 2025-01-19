namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuTra")]
    public partial class PhieuTra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuTra()
        {
            CT_PhieuTra = new HashSet<CT_PhieuTra>();
        }

        [Key]
        [StringLength(5)]
        public string MaPhieuTra { get; set; }

        [Required]
        [StringLength(5)]
        public string MaPhieuMuon { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLap { get; set; }

        [Required]
        [StringLength(5)]
        public string MaNhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhieuTra> CT_PhieuTra { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual PhieuMuon PhieuMuon { get; set; }
    }
}
