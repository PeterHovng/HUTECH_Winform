namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuPhat")]
    public partial class PhieuPhat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuPhat()
        {
            CT_PhieuPhat = new HashSet<CT_PhieuPhat>();
        }

        [Key]
        [StringLength(5)]
        public string MaPhieuPhat { get; set; }

        [Required]
        [StringLength(5)]
        public string MaNhanVien { get; set; }

        [Required]
        [StringLength(5)]
        public string MaPhieuMuon { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhieuPhat> CT_PhieuPhat { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual PhieuMuon PhieuMuon { get; set; }
    }
}
