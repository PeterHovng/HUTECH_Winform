namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DocGia")]
    public partial class DocGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocGia()
        {
            CT_PhieuTra = new HashSet<CT_PhieuTra>();
            PhieuMuon = new HashSet<PhieuMuon>();
        }

        [Key]
        [StringLength(5)]
        public string MaDocGia { get; set; }

        [Required]
        [StringLength(225)]
        public string HoTenDocGia { get; set; }

        [Required]
        [StringLength(10)]
        public string GioiTinh { get; set; }

        [Required]
        [StringLength(225)]
        public string DiaChi { get; set; }

        public long? DienThoai { get; set; }

        public long CMND { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLamThe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhieuTra> CT_PhieuTra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuMuon> PhieuMuon { get; set; }
    }
}
