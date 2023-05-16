namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_UserWorkExperience
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_UserWorkExperience()
        {
            Tbl_UserWorkExperienceStamp = new HashSet<Tbl_UserWorkExperienceStamp>();
        }

        [Key]
        public long UserEduBackID { get; set; }

        public string InstituteName { get; set; }

        public string FromDate { get; set; }

        public string UpToDate { get; set; }

        public string companyLogo { get; set; }

        public string post { get; set; }

        public string description { get; set; }

        public long fk_UserID { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UserWorkExperienceStamp> Tbl_UserWorkExperienceStamp { get; set; }
    }
}
