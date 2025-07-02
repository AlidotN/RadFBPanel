namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Tbl_Introduction
    {
        [Key]
        public long IntroductionID { get; set; }

        public string FaText { get; set; }

        public string EnText { get; set; }

        public string FaPic { get; set; }

        public string EnPic { get; set; }

        public bool DeleteStatus { get; set; }
    }
}
