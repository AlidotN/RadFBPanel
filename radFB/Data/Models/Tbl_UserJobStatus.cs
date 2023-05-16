namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_UserJobStatus
    {
        [Key]
        public long UserJobStatusID { get; set; }

        public long fk_JobStatusID { get; set; }

        public long fk_UserID { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual Tbl_jobStatus Tbl_jobStatus { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
