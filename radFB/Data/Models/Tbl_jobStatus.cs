namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_jobStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_jobStatus()
        {
            Tbl_UserJobStatus = new HashSet<Tbl_UserJobStatus>();
        }

        [Key]
        public long jobStatusID { get; set; }

        public string PrJobStatusTitle { get; set; }

        public string EnJobStatusTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UserJobStatus> Tbl_UserJobStatus { get; set; }
    }
}
