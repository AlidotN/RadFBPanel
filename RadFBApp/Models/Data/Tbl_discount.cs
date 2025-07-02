namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_discount
    {
        public Tbl_discount()
        {
            this.UserDiscounts = new HashSet<Tbl_userDiscount>();
        }

        [Key]
        public long discountID { get; set; }

        public string discountTitle { get; set; }

        public int discountPercent { get; set; }

        public string startDate { get; set; }

        public string endDate { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual ICollection<Tbl_userDiscount> UserDiscounts { get; set; }
    }
}
