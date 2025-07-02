namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_UserWorkExperience
    {
        public Tbl_UserWorkExperience()
        {
            this.UserWorkExperienceStamps = new HashSet<Tbl_UserWorkExperienceStamp>();
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

        [ForeignKey("fk_UserID")]
        public Tbl_RadFBUsers Users { get; set; }

        public virtual ICollection<Tbl_UserWorkExperienceStamp> UserWorkExperienceStamps { get; set; }
    }
}
