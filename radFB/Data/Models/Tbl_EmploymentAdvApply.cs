namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_EmploymentAdvApply
    {
        [Key]
        public long EmploymentAdvApplyID { get; set; }

        public long fk_ApplicantUserID { get; set; }

        public long fk_postID { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual Tbl_post Tbl_post { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
