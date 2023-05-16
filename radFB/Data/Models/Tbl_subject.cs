namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Tbl_subject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_subject()
        {
            Tbl_Question = new HashSet<Tbl_Question>();
            Tbl_questionnaire = new HashSet<Tbl_questionnaire>();
            Tbl_questionFilter = new HashSet<Tbl_questionFilter>();
            Tbl_questionnaireFilter = new HashSet<Tbl_questionnaireFilter>();
            Tbl_savedTopics = new HashSet<Tbl_savedTopics>();
        }

        [Key]
        public long subjectID { get; set; }

        public string FaTitle { get; set; }

        public string EnTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_questionFilter> Tbl_questionFilter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Question> Tbl_Question { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_questionnaire> Tbl_questionnaire { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_questionnaireFilter> Tbl_questionnaireFilter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_savedTopics> Tbl_savedTopics { get; set; }
    }
}
