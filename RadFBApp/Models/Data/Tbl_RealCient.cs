namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_RealCient
    {
        [Key]
        public long RealClientID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string birthday { get; set; }

        public string aboutMe { get; set; }

        public string suggestSAlary { get; set; }

        public bool companyDesire { get; set; }

        public int fk_GenderID { get; set; }

        public long fk_mssID { get; set; }

        public int fk_CooperationID { get; set; }

        public bool DeleteStatus { get; set; }

        public int Fk_maritalstatus { get; set; }

        public long fk_UserID { get; set; }

        [ForeignKey("fk_UserID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("Fk_maritalstatus")]
        public maritalStatus MaritalStatus { get; set; }

        [ForeignKey("fk_CooperationID")]
        public Tbl_CooperationType CooperationTypes { get; set; }

        [ForeignKey("fk_mssID")]
        public Tbl_militaryServiceSituation MilitaryStatus { get; set; }

        [ForeignKey("fk_GenderID")]
        public Tbl_gender Genders { get; set; }

    }
}
