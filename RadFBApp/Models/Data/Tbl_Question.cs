namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_Question
    {
        public Tbl_Question()
        {
            Tbl_AnswerToQuestion = new HashSet<Tbl_AnswerToQuestion>();
            this.SavedQuestions = new HashSet<Tbl_savedQuestion>();
        }

        [Key]
        public long QuestionID { get; set; }

        public long fk_JobCategoryID { get; set; }

        public long fk_subjectID { get; set; }

        public long fk_postID { get; set; }

        public bool DeleteStatus { get; set; }

        [ForeignKey("fk_JobCategoryID")]
        public Tbl_jobCategory JobCategories { get; set; }

        [ForeignKey("fk_subjectID")]
        public Tbl_subject Subjects { get; set; }

        [ForeignKey("fk_postID")]
        public Tbl_post Posts { get; set; }

        public virtual ICollection<Tbl_AnswerToQuestion> Tbl_AnswerToQuestion { get; set; }

        public virtual ICollection<Tbl_savedQuestion> SavedQuestions { get; set; }
    }
}
