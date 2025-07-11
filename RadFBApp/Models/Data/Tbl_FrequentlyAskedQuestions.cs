namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_FrequentlyAskedQuestions
    {
        [Key]
        public long FrequentlyAskedQuestionsID { get; set; }

        public string prQuestion { get; set; }

        public string prAnswer { get; set; }

        public string EnQuestion { get; set; }

        public string EnAnswer { get; set; }

        public bool status { get; set; }

        public long? fk_SubjectID { get; set; }

        public bool DeleteStatus { get; set; }

        [ForeignKey("fk_SubjectID")]
        public Tbl_FrequentlyAskedQuestionsSubject FrequentlyAskedQuestionsSubjects { get; set; }

    }
}
