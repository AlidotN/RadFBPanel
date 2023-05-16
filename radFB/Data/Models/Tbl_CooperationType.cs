namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_CooperationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_CooperationType()
        {
            Tbl_EmploymentAdvPost = new HashSet<Tbl_EmploymentAdvPost>();
            Tbl_RealCient = new HashSet<Tbl_RealCient>();
        }

        [Key]
        public int CooperationID { get; set; }

        public string PrCooperationName { get; set; }

        public string EnCooperationName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_EmploymentAdvPost> Tbl_EmploymentAdvPost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_RealCient> Tbl_RealCient { get; set; }
    }
}
