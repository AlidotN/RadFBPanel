namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Tbl_posterFilter
    {
        [Key]
        public long posterID { get; set; }

        public string posterTitle { get; set; }

        public string posterSubject { get; set; }

        public string posterContacts { get; set; }

        public string posterAddress { get; set; }

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

        public bool DeleteStatus { get; set; }

        [ForeignKey("fk_genderID")]
        public Tbl_gender Genders { get; set; }

        [ForeignKey("fk_countryID")]
        public Tbl_countries Countries { get; set; }

    }
}
