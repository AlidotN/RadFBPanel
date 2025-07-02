namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Tbl_UserRegistrationCourses
    {
        [Key]
        public long UserRegistrationCoursesID { get; set; }

        public long fk_RegisteredUserID { get; set; }

        public long fk_posterID { get; set; }

        public bool UserRegistrationStatus { get; set; }

        public bool DeleteStatus { get; set; }

        [ForeignKey("fk_RegisteredUserID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_posterID")]
        public Tbl_poster Posters { get; set; }
    }
}
