namespace baitapcuoiki.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CTHDs = new HashSet<CTHD>();
        }

        [Key]
        [StringLength(4)]
        [Display(Name = "Mã Sản Phẩm")]
        public string MASP { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = " Tên Sản Phẩm")]
        public string TENSP { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = " Số Lượng")]
        public string Soluong { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nước Sản Xuất")]
        public string NuocSX { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = " Giá")]
        public decimal? Gia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }
    }
}
