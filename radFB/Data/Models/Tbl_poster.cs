namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   
    public partial class Tbl_poster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_poster()
        {
            Tbl_UserRegistrationCourses = new HashSet<Tbl_UserRegistrationCourses>();
        }

        [Key]
        public long posterID { get; set; }

        public string posterTitle { get; set; }

        public string posterSubject { get; set; }

        public string posterContacts { get; set; }

        public string posterAddress { get; set; }

        public string posterPhoneNumber { get; set; }

        public string posterDegree { get; set; }

        public string posterPrerequisites { get; set; }

        public string posterOtherThings { get; set; }

        public int fk_countryID { get; set; }

        public string posterCity { get; set; }

        public string posterStartDate { get; set; }

        public string posterEndDate { get; set; }

        public bool OnlineOflineStatus { get; set; }

        public int fk_genderID { get; set; }

        public int PosterCapacity { get; set; }

        public string posterCoust { get; set; }

        public string posterType { get; set; }

        public long fk_posterTemplateID { get; set; }

        public string daysOfWeek { get; set; }

        public string timesOfDay { get; set; }

        public bool DeleteStatus { get; set; }

        public long fk_userID { get; set; }

        public bool posterStatus { get; set; }

        public virtual Tbl_countries Tbl_countries { get; set; }

        public virtual Tbl_gender Tbl_gender { get; set; }

        public virtual Tbl_posterTemplate Tbl_posterTemplate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UserRegistrationCourses> Tbl_UserRegistrationCourses { get; set; }
    }
}
