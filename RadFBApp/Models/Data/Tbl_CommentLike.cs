namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_CommentLike
    {
        [Key]
        public long CommentLikeID { get; set; }

        public long fk_AnswerToQuestionID { get; set; }

        public long fk_UserID { get; set; }

        public bool DeleteStatus { get; set; }

        [ForeignKey("fk_UserID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_AnswerToQuestionID")]
        public Tbl_AnswerToQuestion AnswersToQuestions { get; set; }

    }
}
