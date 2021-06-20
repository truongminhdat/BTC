namespace baitapcuoiki.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccount")]
    public partial class UserAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã Người Dùng")]
        public int ID { get; set; }

        [Key]
        [StringLength(20)]
        [Display(Name = "Tên Đăng Nhập")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Trạng Thái")]
        public string Status { get; set; }
    }
}
