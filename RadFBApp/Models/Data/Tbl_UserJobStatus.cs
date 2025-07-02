namespace RadFBApp.Models.Data
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

        [ForeignKey("fk_UserID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_JobStatusID")]
        public Tbl_jobStatus JobStatus { get; set; }
    }
}
