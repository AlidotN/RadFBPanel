namespace RadFBApp.Models.Data
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

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_QuestionnaireID")]
        public Tbl_questionnaire Questionnaires { get; set; }
    }
}
