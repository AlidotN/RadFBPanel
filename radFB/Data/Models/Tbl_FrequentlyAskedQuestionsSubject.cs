namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_FrequentlyAskedQuestionsSubject
    {
        [Key]
        public long FrequentlyAskedQuestionsSubjectID { get; set; }

        public string FaTitle { get; set; }

        public string EnTitle { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual Tbl_FrequentlyAskedQuestions Tbl_FrequentlyAskedQuestions { get; set; }
    }
}
