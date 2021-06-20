using baitapcuoiki.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop.Areas.Admin.Data
{
    public class DonHangmodel
    {
        [Required]
        public string SOHD { get; set; }

       
        public DateTime? NGHD { get; set; }

        
        public string MAKH { get; set; }

        
        public string MANV { get; set; }

       
        public decimal? TRIGIA { get; set; }


    }
}
