namespace radFB.db
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

        public virtual Tbl_questionnaire Tbl_questionnaire { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
