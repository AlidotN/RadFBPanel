namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_UserEducationalBackground
    {
        [Key]
        public long UserEduBackID { get; set; }

        public string InstituteName { get; set; }

        public string FromDate { get; set; }

        public string UpToDate { get; set; }

        public long fk_majorID { get; set; }

        public long fk_gradeID { get; set; }

        public long fk_UserID { get; set; }

        public bool DeleteStatus { get; set; }

        [ForeignKey("fk_UserID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_gradeID")]
        public Tbl_grade Grades { get; set; }

        [ForeignKey("fk_majorID")]
        public Tbl_major Majors { get; set; }
    }
}
