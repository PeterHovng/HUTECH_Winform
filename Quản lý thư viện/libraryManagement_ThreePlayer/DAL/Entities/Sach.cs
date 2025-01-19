namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            CT_PhieuMuon = new HashSet<CT_PhieuMuon>();
        }

        [Key]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Required]
        [StringLength(225)]
        public string TenSach { get; set; }

        [Required]
        [StringLength(5)]
        public string MaTheLoai { get; set; }

        [Required]
        [StringLength(225)]
        public string NhaXuatBan { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayXuatBan { get; set; }

        [Required]
        [StringLength(5)]
        public string MaTacGia { get; set; }

        public int SoLuong { get; set; }

        public double GiaTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhieuMuon> CT_PhieuMuon { get; set; }

        public virtual TacGia TacGia { get; set; }

        public virtual TheLoai TheLoai { get; set; }
    }
}
