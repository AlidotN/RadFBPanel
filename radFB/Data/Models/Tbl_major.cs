namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_major
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_major()
        {
            Tbl_UserEducationalBackground = new HashSet<Tbl_UserEducationalBackground>();
        }

        [Key]
        public long majorID { get; set; }

        [StringLength(50)]
        public string PrMajorTitle { get; set; }

        [StringLength(50)]
        public string EnMajorTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UserEducationalBackground> Tbl_UserEducationalBackground { get; set; }
    }
}
