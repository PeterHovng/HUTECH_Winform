namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TacGia")]
    public partial class TacGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TacGia()
        {
            Sach = new HashSet<Sach>();
        }

        [Key]
        [StringLength(5)]
        public string MaTacGia { get; set; }

        [Required]
        [StringLength(225)]
        public string HoTenTacGia { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(225)]
        public string QueQuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sach> Sach { get; set; }
    }
}
