namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuMuon")]
    public partial class PhieuMuon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuMuon()
        {
            CT_PhieuMuon = new HashSet<CT_PhieuMuon>();
            PhieuPhat = new HashSet<PhieuPhat>();
            PhieuTra = new HashSet<PhieuTra>();
        }

        [Key]
        [StringLength(5)]
        public string MaPhieuMuon { get; set; }

        [Required]
        [StringLength(5)]
        public string MaNhanVien { get; set; }

        [Required]
        [StringLength(5)]
        public string MaDocGia { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayMuon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhieuMuon> CT_PhieuMuon { get; set; }

        public virtual DocGia DocGia { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuPhat> PhieuPhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuTra> PhieuTra { get; set; }
    }
}
