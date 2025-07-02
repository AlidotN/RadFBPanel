namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Tbl_subject
    {
        public Tbl_subject()
        {
            this.Questions = new HashSet<Tbl_Question>();
            this.Questionnaires = new HashSet<Tbl_questionnaire>();
            this.QuestionFilters = new HashSet<Tbl_questionFilter>();
            this.QuestionnaireFilters = new HashSet<Tbl_questionnaireFilter>();
            this.SavedTopics = new HashSet<Tbl_savedTopics>();
        }

        [Key]
        public long subjectID { get; set; }

        public string FaTitle { get; set; }

        public string EnTitle { get; set; }

        public virtual ICollection<Tbl_questionFilter> QuestionFilters { get; set; }

        public virtual ICollection<Tbl_Question> Questions { get; set; }

        public virtual ICollection<Tbl_questionnaire> Questionnaires { get; set; }

        public virtual ICollection<Tbl_questionnaireFilter> QuestionnaireFilters { get; set; }

        public virtual ICollection<Tbl_savedTopics> SavedTopics { get; set; }
    }
}
