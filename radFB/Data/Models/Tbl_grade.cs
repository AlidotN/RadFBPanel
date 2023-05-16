namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Tbl_grade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_grade()
        {
            Tbl_EmploymentAdvPost = new HashSet<Tbl_EmploymentAdvPost>();
            Tbl_UserEducationalBackground = new HashSet<Tbl_UserEducationalBackground>();
        }

        [Key]
        public long gradeID { get; set; }

        public string PrGradeTitle { get; set; }

        public string EnGradeTitle { get; set; }

        public bool DeleteStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_EmploymentAdvPost> Tbl_EmploymentAdvPost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UserEducationalBackground> Tbl_UserEducationalBackground { get; set; }
    }
}
