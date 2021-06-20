namespace baitapcuoiki.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "Tên Đăng Nhập")]
        public string Username { get; set; }

        [StringLength(50)]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }
    }
}
