namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_DeclarationOfReadiness
    {
        [Key]
        public long DeclarationOfReadinessID { get; set; }

        public long fk_volunteerUserID { get; set; }

        public long fk_questionnaireID { get; set; }

        public bool DeleteStatus { get; set; }



        [ForeignKey("fk_volunteerUserID")]
        public Tbl_RadFBUsers Users { get; set; }


        [ForeignKey("fk_questionnaireID")]
        public Tbl_questionnaire Questionnaires { get; set; }

    }
}
