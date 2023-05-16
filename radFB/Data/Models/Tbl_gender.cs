namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_gender
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_gender()
        {
            Tbl_EmploymentAdvPost = new HashSet<Tbl_EmploymentAdvPost>();
            Tbl_poster = new HashSet<Tbl_poster>();
            Tbl_posterFilter = new HashSet<Tbl_posterFilter>();
            //Tbl_questionnaire = new HashSet<Tbl_questionnaire>();
            Tbl_RealCient = new HashSet<Tbl_RealCient>();
        }

        [Key]
        public int GenderID { get; set; }

        public string PrGenderTitle { get; set; }

        public string EnGenderTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_EmploymentAdvPost> Tbl_EmploymentAdvPost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_poster> Tbl_poster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_posterFilter> Tbl_posterFilter { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Tbl_questionnaire> Tbl_questionnaire { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_RealCient> Tbl_RealCient { get; set; }
    }
}
