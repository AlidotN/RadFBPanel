namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_jobStatus
    {
        public Tbl_jobStatus()
        {
            this.UserJobStatus = new HashSet<Tbl_UserJobStatus>();
        }

        [Key]
        public long jobStatusID { get; set; }

        public string PrJobStatusTitle { get; set; }

        public string EnJobStatusTitle { get; set; }

        public virtual ICollection<Tbl_UserJobStatus> UserJobStatus { get; set; }
    }
}
