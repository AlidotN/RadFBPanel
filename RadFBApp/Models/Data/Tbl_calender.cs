namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_calender
    {
        [Key]
        public long calenderID { get; set; }

        public string calenderTitle { get; set; }

        public string calenderStartDate { get; set; }

        public string calenderEndDate { get; set; }

        public bool DeleteStatus { get; set; }

        public long fk_userID { get; set; }

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }

    }
}
