using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop.Areas.Admin.Data
{
    public class khachhangmodel
    {
        [Required]

        public string MAKH { get; set; }

     
        public string TENKH { get; set; }

       
        public string DiaChi { get; set; }

       
        public string SoDT { get; set; }

       
        public DateTime? NGSINH { get; set; }

    
        public DateTime? NGDK { get; set; }

       
        public decimal? DOANHSO { get; set; }
    }
}