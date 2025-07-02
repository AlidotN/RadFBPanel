namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_usersQuestions
    {
        [Key]
        public long usersQuestionsID { get; set; }

        public string usersQuestionsTitle { get; set; }

        public string usersQuestionsText { get; set; }

        public string usersQuestionDate { get; set; }

        public string usersQuestionTime { get; set; }

        public string QuestionAnswerText { get; set; }

        public string QuestionAnswerDate { get; set; }

        public string QuestionAnswerTime { get; set; }

        public int answerPoint { get; set; }

        public bool DeleteStatus { get; set; }

        public long fk_userID { get; set; }
        public string fk_admin { get; set; }

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_admin")]
        public ApplicationUser AppUsers { get; set; }

    }
}
