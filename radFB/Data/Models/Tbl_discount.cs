namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_discount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_discount()
        {
            Tbl_userDiscount = new HashSet<Tbl_userDiscount>();
        }

        [Key]
        public long discountID { get; set; }

        public string discountTitle { get; set; }

        public int discountPercent { get; set; }

        public string startDate { get; set; }

        public string endDate { get; set; }

        public bool DeleteStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_userDiscount> Tbl_userDiscount { get; set; }
    }
}
