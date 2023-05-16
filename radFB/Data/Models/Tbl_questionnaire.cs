namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    public partial class Tbl_questionnaire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_questionnaire()
        {
            Tbl_DeclarationOfReadiness = new HashSet<Tbl_DeclarationOfReadiness>();
            Tbl_savedQuestionnaire = new HashSet<Tbl_savedQuestionnaire>();
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



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_DeclarationOfReadiness> Tbl_DeclarationOfReadiness { get; set; }

        public virtual Tbl_subject Tbl_subject { get; set; }

        public virtual Tbl_jobCategory Tbl_jobCategory { get; set; }

        public virtual Tbl_post Tbl_post { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_savedQuestionnaire> Tbl_savedQuestionnaire { get; set; }
    }
}
