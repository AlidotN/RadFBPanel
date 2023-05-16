namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Question()
        {
            Tbl_AnswerToQuestion = new HashSet<Tbl_AnswerToQuestion>();
            Tbl_savedQuestion = new HashSet<Tbl_savedQuestion>();
        }

        [Key]
        public long QuestionID { get; set; }

        public long fk_JobCategoryID { get; set; }

        public long fk_subjectID { get; set; }

        public long fk_postID { get; set; }

        public bool DeleteStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_AnswerToQuestion> Tbl_AnswerToQuestion { get; set; }

        public virtual Tbl_jobCategory Tbl_jobCategory { get; set; }

        public virtual Tbl_post Tbl_post { get; set; }

        public virtual Tbl_subject Tbl_subject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_savedQuestion> Tbl_savedQuestion { get; set; }
    }
}
