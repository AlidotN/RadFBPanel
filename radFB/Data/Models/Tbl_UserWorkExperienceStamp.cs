namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_UserWorkExperienceStamp
    {
        [Key]
        public long UserWorkExperienceStampID { get; set; }

        public long fk_UserWorkExperienceID { get; set; }

        public long fk_UserID { get; set; }

        public long fk_stampedUSerID { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers1 { get; set; }

        public virtual Tbl_UserWorkExperience Tbl_UserWorkExperience { get; set; }
    }
}
