namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_permiumPackage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_permiumPackage()
        {
            Tbl_packageOptions = new HashSet<Tbl_packageOptions>();
            Tbl_pay = new HashSet<Tbl_pay>();
        }

        [Key]
        public long permiumPackageID { get; set; }

        public string permiumPackageTitle { get; set; }

        public string selectedOptions { get; set; }

        public string price { get; set; }

        public string time { get; set; }

        public bool DeleteStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_packageOptions> Tbl_packageOptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_pay> Tbl_pay { get; set; }
    }
}
