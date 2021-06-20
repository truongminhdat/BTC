namespace baitapcuoiki.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        [StringLength(4)]
        [Display(Name = "Mã Khách Hàng")]
        public string MAKH { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên Khách Hàng")]
        public string TENKH { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        public string SoDT { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "Ngày sinh")]
        public DateTime? NGSINH { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "Ngày Đăng Ký")]
        public DateTime? NGDK { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Doanh số")]
        public decimal? DOANHSO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
