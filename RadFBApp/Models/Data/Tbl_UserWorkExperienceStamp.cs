namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_UserWorkExperienceStamp
    {
        [Key]
        public long UserWorkExperienceStampID { get; set; }

        public long fk_UserWorkExperienceID { get; set; }

        public long fk_UserID { get; set; }

        public long fk_stampedUSerID { get; set; }

        public bool DeleteStatus { get; set; }

        [ForeignKey("fk_UserID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_UserWorkExperienceID")]
        public Tbl_UserWorkExperience UserWorkExperiences { get; set; }

    }
}
