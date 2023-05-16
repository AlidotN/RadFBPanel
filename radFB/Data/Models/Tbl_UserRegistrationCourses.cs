namespace radFB.db
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

        public virtual Tbl_poster Tbl_poster { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
