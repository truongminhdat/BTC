namespace baitapcuoiki.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CTHDs = new HashSet<CTHD>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "Số Hóa Đơn")]
        public string SOHD { get; set; }

        [Display(Name = "Ngày Ghi Hóa Đơn")]
        [Column(TypeName = "smalldatetime")]
        public DateTime? NGHD { get; set; }

        [Display(Name = "Mã Khách Hàng")]
        [StringLength(4)]
        public string MAKH { get; set; }

        [Display(Name = "Mã Nhân Viên")]
        [StringLength(50)]
        public string MANV { get; set; }

        [Display(Name = "Trị Giá")]
        [Column(TypeName = "money")]
        public decimal? TRIGIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
