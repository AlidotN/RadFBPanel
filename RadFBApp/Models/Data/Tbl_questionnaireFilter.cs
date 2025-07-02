namespace RadFBApp.Models.Data
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

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_subjectID")]
        public Tbl_subject Subjects { get; set; }

    }
}
