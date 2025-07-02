namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Tbl_userDiscount
    {
        [Key]
        public long userDiscountID { get; set; }

        public long fk_discountID { get; set; }

        public long fk_userID { get; set; }

        public bool DeleteStatus { get; set; }

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_discountID")]
        public Tbl_discount Discounts { get; set; }
    }
}
