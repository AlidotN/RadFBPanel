namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_postChanged
    {
        [Key]
        public long postChangedID { get; set; }

        public string postChangedPic { get; set; }

        public string postChangedExplain { get; set; }

        public string postChangedDate { get; set; }

        public string postChangedTime { get; set; }

        public bool postChangedStatus { get; set; }

        public bool DeleteStatus { get; set; }

        public long fk_userID { get; set; }

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }

    }
}
