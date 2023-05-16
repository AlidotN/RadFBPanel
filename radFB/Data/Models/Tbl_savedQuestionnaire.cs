namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_savedQuestionnaire
    {
        [Key]
        public long savedQuestionnaireID { get; set; }

        public long fk_userID { get; set; }

        public long fk_QuestionnaireID { get; set; }

        public bool pin { get; set; }

        public virtual Tbl_questionnaire Tbl_questionnaire { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
