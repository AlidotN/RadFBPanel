namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_reportUsers
    {
        [Key]
        public long reportUsersID { get; set; }

        public long fk_ReportingUSerID { get; set; }

        public long fk_ReportedUserID { get; set; }

        public bool isChecked { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers1 { get; set; }
    }
}
