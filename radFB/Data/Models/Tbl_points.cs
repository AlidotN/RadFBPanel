namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_points
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_points()
        {
            Tbl_pointsDetail = new HashSet<Tbl_pointsDetail>();
        }

        [Key]
        public long pointID { get; set; }

        public string pointTitle { get; set; }

        public int pointValue { get; set; }

        public bool DeleteStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_pointsDetail> Tbl_pointsDetail { get; set; }
    }
}
