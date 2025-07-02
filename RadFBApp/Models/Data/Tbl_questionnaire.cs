namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    public partial class Tbl_questionnaire
    {
        public Tbl_questionnaire()
        {
            this.Declarations = new HashSet<Tbl_DeclarationOfReadiness>();
            this.SavedQuestionnaires = new HashSet<Tbl_savedQuestionnaire>();
        }

        [Key]
        public long questionnaireID { get; set; }

        public long fk_JobCategoryID { get; set; }

        public long fk_subjectID { get; set; }

        public long fk_postID { get; set; }

        public string benefit { get; set; }

        public string address { get; set; }

        public bool status { get; set; }

        public int answerType { get; set; }

        public bool DeleteStatus { get; set; }


        [ForeignKey("fk_JobCategoryID")]
        public Tbl_jobCategory JobCategories { get; set; }

        [ForeignKey("fk_subjectID")]
        public Tbl_subject Subjects { get; set; }

        [ForeignKey("fk_postID")]
        public Tbl_post Posts { get; set; }

        public virtual ICollection<Tbl_DeclarationOfReadiness> Declarations { get; set; }


        public virtual ICollection<Tbl_savedQuestionnaire> SavedQuestionnaires { get; set; }
    }
}
