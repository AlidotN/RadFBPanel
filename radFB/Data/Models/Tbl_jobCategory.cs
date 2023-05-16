namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_jobCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_jobCategory()
        {
            Tbl_EmploymentAdvPost = new HashSet<Tbl_EmploymentAdvPost>();
            Tbl_Question = new HashSet<Tbl_Question>();
            Tbl_questionFilter = new HashSet<Tbl_questionFilter>();
            Tbl_questionnaire = new HashSet<Tbl_questionnaire>();
            Tbl_RadFBUsers = new HashSet<Tbl_RadFBUsers>();
        }

        [Key]
        public long jobCategoryID { get; set; }

        public string PrJobCategoryTitle { get; set; }

        public string EnJobCategoryTitle { get; set; }

        public long fk_guildID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_EmploymentAdvPost> Tbl_EmploymentAdvPost { get; set; }

        public virtual Tbl_guild Tbl_guild { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Question> Tbl_Question { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_questionFilter> Tbl_questionFilter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_questionnaire> Tbl_questionnaire { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_RadFBUsers> Tbl_RadFBUsers { get; set; }
    }
}
