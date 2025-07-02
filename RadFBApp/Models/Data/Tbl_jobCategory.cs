namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_jobCategory
    {
        public Tbl_jobCategory()
        {
            this.EmploymentAdvPosts = new HashSet<Tbl_EmploymentAdvPost>();
            this.Questions = new HashSet<Tbl_Question>();
            this.QuestionFilters = new HashSet<Tbl_questionFilter>();
            this.Questionnaires = new HashSet<Tbl_questionnaire>();
            this.Users = new HashSet<Tbl_RadFBUsers>();
            this.QuestionnaireTemplates = new HashSet<Tbl_questionnaireTemplate>();
        }

        [Key]
        public long jobCategoryID { get; set; }

        public string PrJobCategoryTitle { get; set; }

        public string EnJobCategoryTitle { get; set; }

        public long fk_guildID { get; set; }

        [ForeignKey("fk_guildID")]
        public Tbl_guild Guilds { get; set; }

        public virtual ICollection<Tbl_EmploymentAdvPost> EmploymentAdvPosts { get; set; }

        public virtual ICollection<Tbl_Question> Questions { get; set; }

        public virtual ICollection<Tbl_questionFilter> QuestionFilters { get; set; }

        public virtual ICollection<Tbl_questionnaire> Questionnaires { get; set; }

        public virtual ICollection<Tbl_RadFBUsers> Users { get; set; }

        public virtual ICollection<Tbl_questionnaireTemplate> QuestionnaireTemplates { get; set; }
    }
}
