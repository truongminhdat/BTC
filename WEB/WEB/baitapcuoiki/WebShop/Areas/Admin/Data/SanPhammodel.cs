using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShop.Areas.Admin.Data
{
    public class SanPhammodel
    {

        [Key]
        [StringLength(4)]
        public string MASP { get; set; }

        [Required]
        [StringLength(50)]
        public string TENSP { get; set; }

        [Required]
        [StringLength(50)]
        public string Soluong { get; set; }

        [Required]
        [StringLength(50)]
        public string NuocSX { get; set; }

        [Column(TypeName = "money")]
        public decimal? Gia { get; set; }

    }
}