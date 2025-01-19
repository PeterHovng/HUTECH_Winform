namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            PhieuMuon = new HashSet<PhieuMuon>();
            PhieuPhat = new HashSet<PhieuPhat>();
            PhieuTra = new HashSet<PhieuTra>();
        }

        [Key]
        [StringLength(5)]
        public string MaNhanVien { get; set; }

        [Required]
        [StringLength(225)]
        public string HoTenNhanVien { get; set; }

        public long CMND { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength(10)]
        public string GioiTinh { get; set; }

        [Required]
        [StringLength(225)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(225)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(225)]
        public string ChucVu { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayVaoLam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuMuon> PhieuMuon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuPhat> PhieuPhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuTra> PhieuTra { get; set; }
    }
}
