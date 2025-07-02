namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_FrequentlyAskedQuestionsSubject
    {
        public Tbl_FrequentlyAskedQuestionsSubject()
        {
            this.FrequentlyAskedQuestions = new HashSet<Tbl_FrequentlyAskedQuestions>();
        }
        [Key]
        public long FrequentlyAskedQuestionsSubjectID { get; set; }

        public string FaTitle { get; set; }

        public string EnTitle { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual ICollection<Tbl_FrequentlyAskedQuestions> FrequentlyAskedQuestions { get; set; }
    }
}
