namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    public partial class Tbl_questionnaireFilter
    {
        [Key]
        public long questionnaireFilterID { get; set; }

        public long fk_userID { get; set; }

        public long fk_subjectID { get; set; }

        public string benefits { get; set; }

        public bool Status { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }

        public virtual Tbl_subject Tbl_subject { get; set; }
    }
}
