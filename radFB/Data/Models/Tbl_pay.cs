namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_pay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_pay()
        {
            Tbl_factor = new HashSet<Tbl_factor>();
        }

        [Key]
        public long payID { get; set; }

        public long fk_userID { get; set; }

        public long fk_permiumPackageID { get; set; }

        public long price { get; set; }

        public bool DeleteStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_factor> Tbl_factor { get; set; }

        public virtual Tbl_permiumPackage Tbl_permiumPackage { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
