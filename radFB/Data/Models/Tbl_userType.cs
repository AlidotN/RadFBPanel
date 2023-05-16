namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Tbl_userType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_userType()
        {
            Tbl_RadFBUsers = new HashSet<Tbl_RadFBUsers>();
        }

        [Key]
        public int userTypeID { get; set; }

        public string PrUserTypeName { get; set; }

        public string EnUserTypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_RadFBUsers> Tbl_RadFBUsers { get; set; }
    }
}
