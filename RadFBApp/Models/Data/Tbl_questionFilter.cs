namespace RadFBApp.Models.Data
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

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_subjectID")]
        public Tbl_subject Subjects { get; set; }

        [ForeignKey("fk_JobCategoryID")]
        public Tbl_jobCategory JobCategories { get; set; }

    }
}
