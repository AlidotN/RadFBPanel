namespace radFB.db
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

        public virtual Tbl_discount Tbl_discount { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
