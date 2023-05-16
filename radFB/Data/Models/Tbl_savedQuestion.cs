namespace radFB.db
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

        public virtual Tbl_Question Tbl_Question { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
