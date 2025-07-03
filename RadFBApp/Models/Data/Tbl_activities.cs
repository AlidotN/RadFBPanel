namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_activities
    {
        [Key]
        public long activityID { get; set; }

        public string activityTitle { get; set; }

        public bool DeleteStatus { get; set; }

        public long fk_userID { get; set; }

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }

    }
}
