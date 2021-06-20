using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop.Areas.Admin.Data
{
    public class Categorymodel
    {
        [Required]
        [StringLength(50)]
        public string CategoryID { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
    }
}