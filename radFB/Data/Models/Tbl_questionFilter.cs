namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_questionFilter
    {
        [Key]
        public long questionFilterID { get; set; }

        public long fk_subjectID { get; set; }

        public long fk_userID { get; set; }

        public long fk_JobCategoryID { get; set; }

        public bool questionFilterStatus { get; set; }

        public bool alert { get; set; }

        public virtual Tbl_jobCategory Tbl_jobCategory { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }

        public virtual Tbl_subject Tbl_subject { get; set; }
    }
}
