namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_savedQuestion
    {
        [Key]
        public long savedQuestionID { get; set; }

        public long fk_userID { get; set; }

        public long fk_QuestionID { get; set; }

        public bool pin { get; set; }

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_QuestionID")]
        public Tbl_Question Questions { get; set; }

    }
}
