namespace baitapcuoiki.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [StringLength(50)]
        [Display(Name="Mã Sản Phẩm")]
        public string ID { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên Sản Phẩm")]
        public string Name { get; set; }

        [Display(Name = "Giá Tiền")]
        public decimal? UnitCost { get; set; }

        [Display(Name = "Số Lượng")]
        public int? Quantity { get; set; }

        [StringLength(250)]
        [Display(Name = "Hình Ảnh")]
        public string Image { get; set; }

        [StringLength(250)]
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }

        [StringLength(50)]
        [Display(Name = "Trạng thái ")]
        public string Status { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã Loại Sản Phẩm")]
        public string CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
